import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { bindActionCreators } from 'redux';
import ListingGrid from '../listing-grid'
import ListingDetails from '../listing-details'

import { connect } from 'react-redux';
import * as actions from '../../redux/actions';
import { getListings } from '../../API/store.jsx'



class Listing extends Component {

    componentDidMount() {
        getListings().then((res) => {
            const data = res.data;
            this.props.loadListings(data);
        });
    }

    render() {
        const { MyListingArr } = this.props;
        return (
            <div>
                <h2>My Listings</h2>
                <ListingGrid gridData={MyListingArr} displayProp={['id', 'listingName']} />
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        MyListingArr: state.MyListingArr
    };
};

export default connect(mapStateToProps, actions)(Listing);
