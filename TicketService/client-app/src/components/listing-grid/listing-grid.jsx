import react, { Component } from 'react';
import ReactDOM from 'react-dom';
import GridRow from '../grid-row'


export default class ListingGrid extends Component {

    render() {
        const { gridData, displayProp } = this.props;
        //gridData.map((item) => {return {...displayProp} = item})
        const displayData = gridData.map((item) => {
            let obj = {};
            displayProp.forEach(el => {
                obj[el] = item[el];
            });
            return obj
        });
        const gridItems = displayData.map((item) => { return <GridRow {...item} /> })
        const gridHeaders = displayProp.filter((item) => item !== 'id').map((value) => { return <th>{value}</th> });
        return (
            <div>
                <table className="table">
                    <thead>
                        <tr>
                            {gridHeaders}
                        </tr>
                    </thead>
                    <tbody>
                        {gridItems}
                    </tbody>
                </table>
            </div>
        );
    }
}