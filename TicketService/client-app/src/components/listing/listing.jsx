import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import ListingGrid from '../listing-grid'
import ListingDetails from '../listing-details'

import { connect } from 'react-redux';
import * as actions from '../../redux/actions';



class Listing extends Component {

    render() {
        const { MyListingArr } = this.props;
        return (
            <div>
                <h2>My Listings</h2>
                <ListingGrid gridData={MyListingArr} displayProp={['id', 'ListingName']} />
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
