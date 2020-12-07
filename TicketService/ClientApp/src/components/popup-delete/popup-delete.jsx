import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import { deleteTicket } from '../../redux/actions';
import { useHistory } from 'react-router-dom';

import './popup-delete.css'

const PopupDelete = ({ id, tId, MyListingArr, deleteTicket }) => {
    const history = useHistory();
    const ticket = MyListingArr.find(({ id: lId }) => lId == id).ListingBody.find(({ id }) => id == tId);
    return (
        <div className="delete-popup-back">
            <div className="delete-popup">
                <div>
                    <h3>Are you shure you want to delete ticket?</h3>
                    <p>Event name: {ticket.EventName}</p>
                    <p>Event date: {ticket.Date}</p>
                    <p>Event price: {ticket.Price}</p>

                </div>
                <div className="delete-buttons">
                    <button className="btn delete-btn" onClick={() => {
                        deleteTicket(id, tId);
                        history.push(`/Listings/${id}`);
                    }}>delete</button>
                    <button className="btn" onClick={() => history.goBack()}>cancel</button>
                </div>
            </div>
        </div>

    )
}
const mapStateToProps = (state) => {
    return {
        MyListingArr: state.MyListingArr
    };
};
const mapDispatchToProps = (dispatch) => {
    return {
        deleteTicket: (id, tId) => dispatch(deleteTicket(id, tId))
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(PopupDelete);