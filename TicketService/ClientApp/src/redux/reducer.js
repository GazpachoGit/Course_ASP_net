
const initialState = {
    isListingLoading: false,   
    MyListingArr: [],
    ListingBody: []
}

  const reducer = (state = initialState, action) => {
    switch (action.type) {

        case 'deleteTicket':
            {               
            return {...state,
                ListingBody: state.ListingBody.filter(t => t.id != action.payload)}
            }
        case 'loadListings': {
                return { ...state, MyListingArr: action.payload }
        }
        case 'loadTickets': {
            return { ...state, ListingBody: action.payload }
        }
        case 'listingLoading':
            return {...state, isListingLoading: true}
        case 'listingLoaded':
            return {...state, isListingLoading: false}  
        default:
            return state;        
    }
}

export default reducer;