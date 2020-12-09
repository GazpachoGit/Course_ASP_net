export const OPEN_MODAL = 'createTicket/OPEN_MODAL';
export const CLOSE_MODAL = 'createTicket/CLOSE_MODAL';

const initialState = {
    isModalOpened: false
}

const ticketReduser = (state = initialState, action) => {
    switch(action.type) {
        case OPEN_MODAL:
            return {...state, isModalOpened: !state.isModalOpened}
        case CLOSE_MODAL:
            return {...state, isModalOpened: !state.isModalOpened}

        default: 
        return state;
    }
}

export default ticketReduser;