export const OPEN_MODAL = 'createTicket/OPEN_MODAL';
export const CLOSE_MODAL = 'createTicket/CLOSE_MODAL';
export const OPEN_DEL_MODAL = 'deleteTicket/OPEN_MODAL';
export const CLOSE_DEL_MODAL = 'deleteTicket/CLOSE_MODAL';
export const GET_EVENTLIST = 'createTicket/GET_EVENTLIST';
export const GET_VENUELIST = 'createTicket/GET_VENUELIST';
export const GET_CITYLIST = 'createTicket/GET_CITYLIST';
export const TICKETS_LOADING = 'ticketList/TICKETS_LOADING';
export const TICKETS_LOADED = 'ticketList/TICKETS_LOADED';

const initialState = {
    isModalOpened: false,
    isModalDelOpened: false,
    deleteId: null,
    deleteTId: null,
    eventList: [],
    venueList:[],
    cityList:[],
    isticketsLoading: false
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
            return {...state, isModalDelOpened: !state.isModalDelOpened};
        case  GET_EVENTLIST: 
            return {...state, eventList: action.payload};
        case GET_VENUELIST:
            return {...state, venueList: action.payload}
        case GET_CITYLIST:
            return {...state, cityList: action.payload}
        case TICKETS_LOADING:
            return {...state, isticketsLoading: true}
        case TICKETS_LOADED:
            return {...state, isticketsLoading: false}
             
        default: 
            return state;
    }
}

export default ticketReduser;