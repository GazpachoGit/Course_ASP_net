import { getTickets } from '../../API/store.jsx'

export const getDetails = () => ({ type: 'getDetails' });

export const loadListings = (data) => (
    {
    type: 'loadListings',
    payload: data
    })

export const loadingListings = () => ({
    type: 'listingLoading'
})
export const loadedListings = () => ({
    type: 'listingLoaded'
})



