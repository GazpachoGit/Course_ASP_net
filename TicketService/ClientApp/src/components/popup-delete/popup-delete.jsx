import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import Modal from 'react-modal';
import { closeDelModal, deleteTicket } from '../../redux/ticket/actions'
import { removeTicket } from '../../API/store.jsx'
import { useHistory } from 'react-router-dom';

import './popup-delete.css'

Modal.setAppElement('#root');

const PopupDelete = ({ id, tId, ListingBody, deleteTicket, closeModal, isModalDelOpened }) => {
    const history = useHistory();
    const ticket = ListingBody.find(({ id }) => id == tId);
    const customStyles = {
        content: {
            top: '50%',
            left: '50%',
            width: '400px',
            height: '300px',
            marginRight: '-50%',
            transform: 'translate(-50%, -50%)'
        }
    };
    return (
        <Modal isOpen={isModalDelOpened} style={customStyles}>
            {isModalDelOpened &&
                <div>
                    <h3>Are you shure you want to delete ticket?</h3>
                    <p>Event name: {ticket.eventName}</p>
                    <p>Event date: {ticket.date}</p>
                    <p>Event price: {ticket.price}</p>
                </div>
            }
            <div className="delete-buttons">
                <button className="btn delete-btn" onClick={() => {
                    deleteTicket(id, tId);
                }}>delete</button>
                <button className="btn" onClick={closeModal}>cancel</button>
            </div>
        </Modal>
    )
}
const mapStateToProps = (state) => {
    return {
        ListingBody: state.ticket.ListingBody,
        isModalDelOpened: state.ticket.isModalDelOpened,
        id: state.ticket.deleteId,
        tId: state.ticket.deleteTId,
    };
};
const mapDispatchToProps = (dispatch) => {
    return {
        deleteTicket: (id, tId) => dispatch(deleteTicket(id, tId)),
        closeModal: () => dispatch(closeDelModal())
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(PopupDelete);