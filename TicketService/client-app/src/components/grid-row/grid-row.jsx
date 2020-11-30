import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Link } from 'react-router-dom';

export default class GridRow extends Component {

    render() {
        const { id, ...itemData } = this.props;
        const gridCol = Object.entries(itemData).map(([, value]) => { return <td>{value}</td> })
        //itemData.map(([, value]) => { return <td>{value}</td> })
        return (
            <tr key={id}>
                {gridCol}
                <td><Link to={`/Listings/${id}`} className="btn btn-success">123</Link></td>
            </tr>
        )
    }
}