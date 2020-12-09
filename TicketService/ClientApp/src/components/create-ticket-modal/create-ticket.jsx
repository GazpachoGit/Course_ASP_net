import React, { Component } from 'react';
import { connect } from 'react-redux';
import Modal from 'react-modal';
import * as actions from '../../redux/ticket/actions';

Modal.setAppElement('#root');

class CreateTicketModal extends Component {
    render() {
        const {isModalOpened, closeModal} = this.props;
        return (
            <div>
                <Modal isOpen={isModalOpened}>                   
                    <h1>Hello</h1>
                    <button className="btn" onClick={closeModal}></button>
                </Modal>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        isModalOpened : state.ticket.isModalOpened
    };
}

export default connect(mapStateToProps, actions)(CreateTicketModal);