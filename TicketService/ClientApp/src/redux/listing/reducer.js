
const initialState = {
    isListingLoading: false,   
    MyListingArr: [],
}

  const reducer = (state = initialState, action) => {
    switch (action.type) {

        case 'loadListings': {
                return { ...state, MyListingArr: action.payload }
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