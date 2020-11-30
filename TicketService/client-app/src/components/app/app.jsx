import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';

import Listing from '../listing'
import ListingDetails from '../listing-details';

export default class App extends Component {

    render() {
        return (
            <div>
                <Router>
                    <h1>Brocker App</h1>
                    <nav className="navbar navbar-expand-lg navbar-light bg-light">
                        <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
                            <div className="navbar-nav">
                                <Link to="/Listings" exact className="nav-item nav-link">My Listings</Link>
                                <Link to="/Orders" className="nav-item nav-link">My orders</Link>
                            </div>
                        </div>
                    </nav>
                    <div>
                        <Route path="/Listings" component={Listing} />
                        <Route path="/Listings/:id" render={({ match }) => {
                            const { id } = match.params;
                            return <ListingDetails id={id} />
                        }} />
                    </div>
                </Router>
            </div>


        )
    }
}