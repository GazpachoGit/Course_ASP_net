import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';
import DropdownList from 'react-widgets/lib/DropdownList'
import RequiredField from './required-field/required-field';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';

import { getEvents, getCities, getVenues, createTicket } from '../../API/store';
import { loadEventList, loadCityList, loadVenueList, addTicket } from '../../redux/ticket/actions';

import './create-ticket-form.css';
import 'react-widgets/dist/css/react-widgets.css'





class CreateTicketForm extends Component {

    componentDidMount() {
        getCities()
            .then(({ data }) => {
                this.props.loadCityList(data);
            })
    }
    render() {
        const { handleSubmit, reset, eventList, cityList, venueList, ListingBody, addTicket } = this.props;

        const loadVenues = (val) => {
            getVenues({ Cities: [val] })
                .then(({ data }) => {
                    this.props.loadVenueList(data);
                })
        }
        const loadEvents = (val) => {
            getEvents({ Venues: [val] })
                .then(({ data }) => {
                    this.props.loadEventList(data);
                })
        }

        const renderDropdownList = ({ input, data, valueField, textField, meta: { touched, error, warning } }) =>
            <div>
                <DropdownList {...input}
                    data={data}
                    valueField={valueField}
                    textField={textField}
                    onChange={input.onChange} />
                <div className="validate-text">
                    {error}
                </div>
            </div>

        const submit = async (val) => {
            const ticket = { price: val.price, eventId: val.event.eventId, listingId: ListingBody[0].listingId };
            console.log(ticket);
            addTicket(ticket);
            // await createTicket({ price: Number(val.price), eventId: val.event.eventId, listingId: ListingBody[0].listingId });
            // this.props.closeModal();
        };
        return (
            <form onSubmit={handleSubmit(submit)}>
                <div>
                    <label htmlFor={"city"}>City</label>
                    <Field name={"city"} component={DropdownList} data={cityList} valueField="cityId" textField="name"
                        onSelect={({ cityId }) => loadVenues(cityId)} />
                </div>
                <div>
                    <label htmlFor={"venue"}>Venue</label>
                    <Field name={"venue"} component={DropdownList} data={venueList} textField="name"
                        onSelect={({ id }) => loadEvents(id)} />
                </div>
                <div>
                    <label htmlFor={"event"}>Event</label>
                    <Field name={"event"} component={renderDropdownList} data={eventList} valueField="name" textField="name" />
                </div>
                <div className="form-group">
                    <Field className="form-control" label="Price" name={"price"} component={RequiredField} type={"number"} />
                </div>
                <div style={{ display: 'flex', justifyContent: 'space-around' }}>
                    <button type="submit" className="btn btn-dark">submit</button>
                    <button type="button" className="btn btn-dark" onClick={reset}>clear</button>
                </div>
            </form>)
    }

}

const validate = (val) => {
    const errors = {}
    errors.event = val.event ? undefined : 'requered event';
    errors.price = val.price ? undefined : 'requered price';
    return errors;
};

const mapStateToProps = state => ({
    ListingBody: state.reducerOld.ListingBody,
    eventList: state.ticket.eventList,
    cityList: state.ticket.cityList,
    venueList: state.ticket.venueList
})

const mapDispatchToProps = (dispatch) => {
    return {
        addTicket: (t) => dispatch(addTicket(t)),
        loadEventList: (t) => dispatch(loadEventList(t)),
        loadCityList: (t) => dispatch(loadCityList(t)),
        loadVenueList: (t) => dispatch(loadVenueList(t)),
    }
}

CreateTicketForm = connect(
    mapStateToProps, mapDispatchToProps
)(CreateTicketForm);

export default reduxForm({ form: "create_ticket", validate })(CreateTicketForm);