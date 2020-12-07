import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import GridRow from '../grid-row'


export default class ListingGrid extends Component {

    render() {
        const { gridData, displayProp } = this.props;
        const displayData = gridData.map((item) => {
            let obj = {};
            displayProp.forEach(el => {
                if (el.includes('.')) {
                    var prpArr = el.split('.');
                    obj[prpArr[1]] = item[prpArr[0]][prpArr[1]];
                } else {
                    obj[el] = item[el];
                }

            });
            return obj
        });
        const gridItems = displayData.map((item) => { return <GridRow {...item} /> })
        //const gridHeaders = displayProp.filter((item) => item !== 'id').map((value) => { return <th>{value}</th> });
        return (
            <div className="container">
                <ul class="list-group">
                    {gridItems}
                </ul>
            </div>
        );
    }
}