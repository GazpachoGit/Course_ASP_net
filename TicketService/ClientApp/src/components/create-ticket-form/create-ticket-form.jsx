import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';
import Dropdown from 'react-dropdown';
import DropdownList from 'react-widgets/lib/DropdownList'
import { connect } from 'react-redux';

import { getEvents, getCities, getVenues } from '../../API/store';
import { loadEventList, loadCityList, loadVenueList } from '../../redux/ticket/actions';

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
        const { handleSubmit, eventList, cityList, venueList } = this.props;
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
        const required = value => value ? undefined : 'Required';
        return (
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor={"name"}>City</label>
                    <Field name={"name"} component={DropdownList} data={cityList} valueField="cityId" textField="name"
                        onSelect={({ cityId }) => loadVenues(cityId)} />
                </div>
                <div>
                    <label htmlFor={"name"}>Venue</label>
                    <Field name={"name"} component={DropdownList} data={venueList} valueField="id" textField="name"
                        onSelect={({ id }) => loadEvents(id)} />
                </div>
                <div>
                    <label htmlFor={"name"}>Event</label>
                    <Field name={"name"} validate={required} component={DropdownList} data={eventList} valueField="eventId" textField="name" />
                </div>
                <div className="form-group">
                    <lable htmlFor={"price"}>Price</lable>
                    <Field className="form-control" validate={required} name={"price"} component={"input"} type={"text"} />
                </div>
                <div>
                    <button type={"submit"} className="btn btn-dark">submit</button>
                </div>
            </form>)
    }
}


const mapStateToProps = state => ({
    eventList: state.ticket.eventList,
    cityList: state.ticket.cityList,
    venueList: state.ticket.venueList
})

CreateTicketForm = connect(
    mapStateToProps, { loadEventList, loadCityList, loadVenueList }
)(CreateTicketForm);

export default reduxForm({ form: "create_ticket" })(CreateTicketForm);