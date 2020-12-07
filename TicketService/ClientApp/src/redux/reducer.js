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


const initialState = {   
    MyListingArr: [1, 2],
    ListingBody: []
}

  const reducer = (state = initialState, action) => {
    switch (action.type) {

        case 'deleteTicket':
            {
                let otherListing = state.MyListingArr.filter(({id}) => id != action.payload.listingId);
                let selectedListing = state.MyListingArr.find(({id}) => id == action.payload.listingId);
                selectedListing.ListingBody = selectedListing.ListingBody.filter(({id}) => id != action.payload.ticketId);
                return {...state,
                     MyListingArr: [selectedListing ,...otherListing]}
            }
        case 'loadListings': {
                return { ...state, MyListingArr: action.payload }
        }
        case 'loadTickets': {
            return { ...state, ListingBody: action.payload }
        } 
        default:
            return state;        
    }
}

export default reducer;