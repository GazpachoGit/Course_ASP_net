import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import ListingGrid from '../listing-grid'

import { connect } from 'react-redux';
import * as actions from '../../redux/listing/actions';
import { getListings } from '../../API/store.jsx'
import Preloader from '../preloader/'

import './listing.css'


class Listing extends Component {

    componentDidMount() {
        this.props.loadingListings();
        getListings().then((res) => {
            const data = res.data;
            this.props.loadListings(data);
            this.props.loadedListings();
        });
    }

    render() {
        const { MyListingArr, isListingLoading } = this.props;
        return (
            <div >
                <h2>My Listings</h2>
                <div className="center">
                    {isListingLoading ? <Preloader /> :
                        <ListingGrid gridData={MyListingArr} displayProp={['id', 'listingName']} />}
                </div>
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        MyListingArr: state.listing.MyListingArr,
        isListingLoading: state.listing.isListingLoading
    };
};

export default connect(mapStateToProps, actions)(Listing);
