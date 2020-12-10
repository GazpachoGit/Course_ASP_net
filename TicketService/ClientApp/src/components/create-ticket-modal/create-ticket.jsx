import React, { Component } from 'react';
import { connect } from 'react-redux';
import Modal from 'react-modal';
import * as actions from '../../redux/ticket/actions';
import CreateTicketForm from '../create-ticket-form/'


Modal.setAppElement('#root');

const customStyles = {
    content : {
      top: '50%',
      left: '50%',
      width: '400px',
      height: '500px',
      marginRight: '-50%',
      transform: 'translate(-50%, -50%)'
    }
  };
class CreateTicketModal extends Component {
    
    render() {
        const {isModalOpened, closeModal} = this.props;
        return (
            <div>
                <Modal isOpen={isModalOpened} style={customStyles}>
                    <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'baseline'}}>
                    <div><h1>Create ticket</h1></div>
                    <div><button className="btn btn-dark" onClick={closeModal}>close</button></div>
                    </div>                                                         
                    <CreateTicketForm/>
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