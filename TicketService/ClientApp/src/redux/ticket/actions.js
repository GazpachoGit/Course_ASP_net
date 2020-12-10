import {OPEN_MODAL, CLOSE_MODAL} from './index'

export const openModal =  () => ({
    type: OPEN_MODAL
})

export const closeModal = () => ({
    type: CLOSE_MODAL
})

// export const addTicket = (ticket) => ({
//     type: ADD_TICKET,
//     payload: ticket
// })