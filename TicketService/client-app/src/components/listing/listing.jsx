import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import ListingGrid from '../listing-grid'
import ListingDetails from '../listing-details'

export default class Listing extends Component {


    state = {
        MyListingArr: [
            {
                id: 1,
                ListingName: 'Moscow',
                ListingBody:
                    [{ Id: '1', EventId: '1', EventName: 'Anna Karenina', Date: '2020-12-08', Price: 1500 },
                    { Id: '2', EventId: '1', EventName: 'Anna Karenina', Date: '2020-12-08', Price: 2000 },
                    { Id: '3', EventId: '2', EventName: 'Revisor', Date: '2020-11-08', Price: 2500 },
                    { Id: '4', EventId: '2', EventName: 'Revisor', Date: '2020-11-08', Price: 3000 }]
            },
            {
                id: 2,
                ListingName: 'Ufa',
                ListingBody:
                    [{ Id: '1', EventId: '1', EventName: 'Graf Orlov', Date: '2020-12-10', Price: 1500 },
                    { Id: '2', EventId: '1', EventName: 'Graf Orlov', Date: '2020-12-10', Price: 2000 },
                    { Id: '3', EventId: '2', EventName: 'Caesar', Date: '2020-11-10', Price: 2500 },
                    { Id: '4', EventId: '2', EventName: 'Caesar', Date: '2020-11-10', Price: 3000 }]
            }
        ]
    };
    render() {
        const { MyListingArr } = this.state;
        return (
            <div>
                <h2>My Listings</h2>
                <ListingGrid gridData={MyListingArr} displayProp={['id', 'ListingName']} />
            </div>
        );
    }
}