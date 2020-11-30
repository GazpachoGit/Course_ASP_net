import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import './listing-details.css'

export default class ListingDetails extends Component {

    render() {
        const {id} = this.props;
        return(
        <div className="details-main bg-laf"> details of {id}</div>
        )
    }
}