import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Link } from 'react-router-dom';
import './grid-row.css'
import { connect } from 'react-redux';

export default class GridRow extends Component {

    render() {
        const { id, ...itemData } = this.props;
        const gridCol = Object.entries(itemData).map(([, value]) => { return <div>{value}</div> })
        //itemData.map(([, value]) => { return <td>{value}</td> })
        return (
            <li key={id} className="list-group-item">
                <div className="store-list-item">
                    {gridCol}
                    <div className="btn-cell"><Link to={`/Listings/${id}`} className="btn btn-dark">Details</Link></div>
                </div>
            </li>
        )
    }
}
