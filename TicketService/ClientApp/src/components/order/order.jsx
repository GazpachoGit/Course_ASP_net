import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import ListingGrid from '../listing-grid'
import ListingDetails from '../listing-details'

export default class Listing extends Component {


    state = {
        Orders: [
            { id: 1, buyer: 'Ivan', price: 1000, eventName: 'Anna Karenina', date: '2020-12-08' },
            { id: 2, buyer: 'Egor', price: 3000, eventName: 'Anna Karenina', date: '2020-12-10' },
            { id: 3, buyer: 'Misha', price: 2000, eventName: 'Anna Karenina', date: '2020-12-15' }
        ]
    };
    render() {
        const { Orders } = this.state;
        return (
            <div>
                <h2>My Listings</h2>
                <ListingGrid gridData={Orders} displayProp={['eventName', 'date', 'price']} />
            </div>
        );
    }
}