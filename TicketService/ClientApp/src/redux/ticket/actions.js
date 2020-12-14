import {OPEN_MODAL,
        CLOSE_MODAL,
        CLOSE_DEL_MODAL,
        OPEN_DEL_MODAL,
        GET_EVENTLIST,
        GET_VENUELIST,
        GET_CITYLIST,
        TICKETS_LOADED,
        TICKETS_LOADING,
        UPDATE_TICKETS,
        READ_LISTING_ID} from './index'
import {openErrorModal} from '../custom-error/actions'
import {createTicket, getTickets, removeTicket} from '../../API/store';

export const openModal =  () => ({
    type: OPEN_MODAL
})

export const closeModal = () => ({
    type: CLOSE_MODAL
})
export const openDelModal = (id, tId) => ({
    type: OPEN_DEL_MODAL,
    payload: {id, tId}
})
export const closeDelModal = () => ({
    type: CLOSE_DEL_MODAL
})
export const loadEventList = (list) => ({
    type: GET_EVENTLIST,
    payload: list
});
export const loadVenueList = (list) => ({
    type: GET_VENUELIST,
    payload: list
});
export const loadCityList = (list) => ({
    type: GET_CITYLIST,
    payload: list
});
export const loadingTickets = () => ({
    type: TICKETS_LOADING
});
export const loadedTickets = () => ({
    type: TICKETS_LOADED
});
export const updateTickets = (data) => ({   
    type: UPDATE_TICKETS,
    payload: data
})
export const readListingId = (id) => ({
    type:  READ_LISTING_ID,
    payload: Number(id)
})
export const deleteTicket = (id, tId) => {
    return async (dispatch) => {
        dispatch(closeDelModal());
        await removeTicket(tId);
        dispatch(loadTickets(id));
    }
}

export const loadTickets = (id) => {
    return async (dispatch) => {
        dispatch(loadingTickets());
        const res =  await getTickets(id);
        dispatch(updateTickets(res.data));
        dispatch(loadedTickets());
    }
}

 export const addTicket = (ticket) => {
     return async (dispatch) => {
         try {
            await createTicket(ticket);           
            await dispatch(loadTickets(ticket.listingId));
         } catch(err) {
            dispatch(openErrorModal(err));
         } finally {
            dispatch(closeModal());
         }               
 }
}  
 