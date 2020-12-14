import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import Modal from 'react-modal';

import * as actions from '../../redux/custom-error/actions'

Modal.setAppElement('#root');

const customStyles = {
    content: {
        top: '50%',
        left: '50%',
        width: '400px',
        minHeight: '200px',
        marginRight: '-50%',
        transform: 'translate(-50%, -50%)'
    }
};
class ErrorModal extends Component {

    render() {
        const { isErrorModalOpen, error, closeErrorModal } = this.props;
        return (
            <div>
                <Modal isOpen={isErrorModalOpen} style={customStyles}>
                    <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'baseline' }}>
                        <div><h1>Error is rised</h1></div>
                        <div><button className="btn btn-dark" onClick={closeErrorModal} >close</button></div>
                    </div>
                    <div>{error}</div>
                </Modal>
            </div>
        );
    }
}
const mapStateToProps = (state) => {
    return {
        isErrorModalOpen: state.customErr.isErrorModalOpen,
        error: state.customErr.errorBody
    };
};
export default connect(mapStateToProps, actions)(ErrorModal);