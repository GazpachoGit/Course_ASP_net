export const OPEN_MODAL = 'createTicket/OPEN_MODAL';
export const CLOSE_MODAL = 'createTicket/CLOSE_MODAL';
export const OPEN_DEL_MODAL = 'deleteTicket/OPEN_MODAL';
export const CLOSE_DEL_MODAL = 'deleteTicket/CLOSE_MODAL';

const initialState = {
    isModalOpened: false,
    isModalDelOpened: false,
    deleteId: null,
    deleteTId: null
}

const ticketReduser = (state = initialState, action) => {
    switch(action.type) {
        case OPEN_MODAL:
            return {...state, isModalOpened: !state.isModalOpened}
        case CLOSE_MODAL:
            return {...state, isModalOpened: !state.isModalOpened}
        case OPEN_DEL_MODAL: 
            return {...state, isModalDelOpened: !state.isModalDelOpened, deleteId: action.payload.id, deleteTId: action.payload.tId}
        case CLOSE_DEL_MODAL: 
            return {...state, isModalDelOpened: !state.isModalDelOpened}
        default: 
            return state;
    }
}

export default ticketReduser;