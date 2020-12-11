import {OPEN_MODAL, CLOSE_MODAL, CLOSE_DEL_MODAL, OPEN_DEL_MODAL} from './index'

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

// export const addTicket = (ticket) => ({
//     type: ADD_TICKET,
//     payload: ticket
// })