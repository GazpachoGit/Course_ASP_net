import {getListings} from '../API/store.jsx'
// const initialState = {
//         MyListingArr: [
//             {
//                 id: 1,
//                 ListingName: 'Moscow',
//                 ListingDesc: 'Пак билетов на популярные спектакли в мск',
//                 ListingBody:
//                 [{ id: '1', EventId: '1',VenueName: 'Театр оперетты', EventName: 'Anna Karenina', Date: '2020-12-08', Price: 1500 },
//                 { id: '2', EventId: '1',VenueName: 'Театр оперетты', EventName: 'Anna Karenina', Date: '2020-12-08', Price: 2000 },
//                     { id: '3', EventId: '2',VenueName: 'Театр оперетты', EventName: 'Revisor', Date: '2020-11-08', Price: 2500 },
//                     { id: '4', EventId: '2',VenueName: 'Театр оперетты', EventName: 'Revisor', Date: '2020-11-08', Price: 3000 }]
//             },
//             {
//                 id: 2,
//                 ListingName: 'Ufa',
//                 ListingDesc: 'Набор билетов на катки города',
//                 ListingBody:
//                     [{ id: '1', EventId: '3',VenueName: 'Каток навигатор', EventName: 'Graf Orlov', Date: '2020-12-10', Price: 1500 },
//                     { id: '2', EventId: '4',VenueName: 'Каток Измайлово', EventName: 'Graf Orlov', Date: '2020-12-10', Price: 2000 },
//                     { id: '3', EventId: '5',VenueName: 'Каток Сокольники', EventName: 'Caesar', Date: '2020-11-10', Price: 2500 },
//                     { id: '4', EventId: '6',VenueName: 'Каток сад Баумана', EventName: 'Caesar', Date: '2020-11-10', Price: 3000 }]
//             }
//         ]
//     };
const initialState = {   
    MyListingArr:[] 
}

  const reducer = (state = initialState, action) => {
    switch (action.type) {
        case 'getDetails':
        {
            return state.MyListingArr[0].ListingBody;           
        }
        case 'deleteTicket':
            {
                let otherListing = state.MyListingArr.filter(({id}) => id != action.payload.listingId);
                let selectedListing = state.MyListingArr.find(({id}) => id == action.payload.listingId);
                selectedListing.ListingBody = selectedListing.ListingBody.filter(({id}) => id != action.payload.ticketId);
                // возвращает чушь
                //return state.MyListingArr[action.payload.listingId].ListingBody.filter(({id}) => id != 1);
                return {...state,
                     MyListingArr: [selectedListing ,...otherListing]}
            }
            case 'getListings': {
                const data = await getListings();
                return {...state, MyListingArr: data};
            } 
        default:
            return state;        
    }
}

export default reducer;