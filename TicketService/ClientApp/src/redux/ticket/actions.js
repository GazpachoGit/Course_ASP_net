import {OPEN_MODAL,
        CLOSE_MODAL,
        CLOSE_DEL_MODAL,
        OPEN_DEL_MODAL,
        GET_EVENTLIST,
        GET_VENUELIST,
        GET_CITYLIST,
        TICKETS_LOADED,
        TICKETS_LOADING} from './index'

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

// export const addTicket = (ticket) => ({
//     type: ADD_TICKET,
//     payload: ticket
// })