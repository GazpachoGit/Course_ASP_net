import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import {Link} from 'react-router-dom';
import './listing-details.css'

import { connect } from 'react-redux';
import * as actions from '../../redux/actions';

class ListingDetails extends Component {
    
    render() {
          //<button className="btn" onClick={() => deleteTicket(id, item.id)}>
        const {id, MyListingArr, deleteTicket} = this.props;
        const selectedListing = MyListingArr.find(({id: itemId}) => itemId == id);
        const {ListingBody} = selectedListing;      
        const ticketData = ListingBody.map((item) => (
            <tr className="table-row">                
            <td>{item.EventName}</td>
            <td>{item.VenueName}</td>
            <td>{item.Date}</td>
            <td>{item.Price}</td>
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
                            <button className="btn btn-dark add-button">+ Add ticket</button>
                        </div>                                                 
                    </div>                        
                </div>
            </div>
        
        
        )
    }
}

const mapStateToProps = (state) => {
    return {
        MyListingArr: state.MyListingArr
    };
};

export default connect(mapStateToProps, actions)(ListingDetails);