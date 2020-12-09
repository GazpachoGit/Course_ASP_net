import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import { deleteTicket } from '../../redux/actions';
import { removeTicket } from '../../API/store.jsx'
import { useHistory } from 'react-router-dom';

import './popup-delete.css'

const PopupDelete = ({ id, tId, ListingBody, deleteTicket }) => {
    const history = useHistory();
    const ticket = ListingBody.find(({ id }) => id == tId);
    return (
        <div className="delete-popup-back">
            <div className="delete-popup">
                <div>
                    <h3>Are you shure you want to delete ticket?</h3>
                    <p>Event name: {ticket.eventName}</p>
                    <p>Event date: {ticket.date}</p>
                    <p>Event price: {ticket.price}</p>

                </div>
                <div className="delete-buttons">
                    <button className="btn delete-btn" onClick={() => {
                        removeTicket(tId)
                            .then(deleteTicket(tId))
                            .then(history.push(`/Listings/${id}`)); 
                    }}>delete</button>
                    <button className="btn" onClick={() => history.goBack()}>cancel</button>
                </div>
            </div>
        </div>

    )
}
const mapStateToProps = (state) => {
    return {
        ListingBody: state.ListingBody
    };
};
const mapDispatchToProps = (dispatch) => {
    return {
        deleteTicket: (tId) => dispatch(deleteTicket(tId)),

    }
}
export default connect(mapStateToProps, mapDispatchToProps)(PopupDelete);