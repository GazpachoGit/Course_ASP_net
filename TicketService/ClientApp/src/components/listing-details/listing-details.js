import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import {Link} from 'react-router-dom';
import './listing-details.css'

import { connect } from 'react-redux';
import {loadTickets} from '../../redux/actions';
import {openModal} from '../../redux/ticket/actions'
import { getTickets } from '../../API/store.jsx'

class ListingDetails extends Component {

    componentDidMount() {
        getTickets(this.props.id).then((res) => {
            const data = res.data;
            this.props.loadTickets(data);
        });
    }
    
    render() {
        
        //<button className="btn" onClick={() => deleteTicket(id, item.id)}>
        const { id, ListingBody, MyListingArr, openModal } = this.props;
       const selectedListing = MyListingArr.find(({id: itemId}) => itemId == id);
        //const {ListingBody} = selectedListing;   */   
        const ticketData = ListingBody.map((item) => (
            <tr className="table-row">                
            <td>{item.eventName}</td>
            <td>{item.venueName}</td>
            <td>{item.date}</td>
            <td>{item.price}</td>
            <td><Link className="btn btn-dark" to={`/Listings/${id}/tickets/${item.id}/delete`}><i className="fa fa-trash"></i></Link></td>
            </tr>))
        //<button onClick={() => deleteTicket(id, ticketId)}>delete</button> 
        return(
            <div className="details-container">
                <div className="details-main">
                    <h1>Details of listing: {selectedListing.ListingName}</h1>
                    <h3>Description: <span className="description-text">{selectedListing.ListingDesc}</span></h3>
                    <div>
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                    <th scope="col">Event Name</th>
                                    <th scope="col">Venue Name</th>
                                    <th scope="col">Date</th>
                                    <th scope="col">Price</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {ticketData} 
                                </tbody>
                            </table>    
                        <div className="add-container">
                            <button onClick={openModal} className="btn btn-dark add-button">+ Add ticket</button>
                        </div>                                                 
                    </div>                        
                </div>
            </div>
        
        
        )
    }
}

const mapStateToProps = (state) => {
    return {
        ListingBody: state.reducerOld.ListingBody,
        MyListingArr: state.reducerOld.MyListingArr
    };
};

export default connect(mapStateToProps, {openModal, loadTickets})(ListingDetails);