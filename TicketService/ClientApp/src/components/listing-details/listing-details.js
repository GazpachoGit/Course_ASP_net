import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import './listing-details.css'
import Preloader from '../preloader/'

import { connect } from 'react-redux';
import { getTickets, } from '../../API/store.jsx'
import * as actions from '../../redux/ticket/actions'

class ListingDetails extends Component {

    componentDidMount() {
        this.props.readListingId(this.props.id);
        this.props.loadTickets(this.props.id);
    }
    
    render() {
        
       const { id, ListingBody, MyListingArr, openModal, openDelModal, isticketsLoading } = this.props;
       const selectedListing = MyListingArr.find(({id: itemId}) => itemId == id);
        const ticketData = ListingBody.map((item) => (
            <tr className="table-row">                
            <td>{item.eventName}</td>
            <td>{item.venueName}</td>
            <td>{item.date}</td>
            <td>{item.price}</td>
            <td><button className="btn btn-dark"><i className="fa fa-trash" onClick={() => openDelModal(id, item.id)}></i></button></td>
            </tr>))
        return(
            <div className="details-container">
                {isticketsLoading ? <Preloader/> : 
                    <div className="details-main">
                    <h1>Details of listing: {selectedListing.ListingName}</h1>
                    <h3>Description: <span className="description-text">{selectedListing.ListingDesc}</span></h3>
                    <div >
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
                            <button style={{marginBottom: '30px'}} onClick={openModal} className="btn btn-dark add-button">+ Add ticket</button>
                        </div>                                                 
                    </div>                        
                </div>
                }
                
            </div>
        
        
        )
    }
}

const mapStateToProps = (state) => {
    return {
        ListingBody: state.ticket.ListingBody,
        MyListingArr: state.listing.MyListingArr,
        isticketsLoading: state.ticket.isticketsLoading
    };
};

export default connect(mapStateToProps, actions)(ListingDetails);