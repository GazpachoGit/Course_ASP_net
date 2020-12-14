export const ERROR_OPEN = 'error/ERROR_OPEN';
export const ERROR_CLOSE = 'error/ERROR_CLOSE';

const initialState = {
    isErrorModalOpen: false,
    errorBody: ''
}

const errorReduser = (state = initialState, action) => {
    switch(action.type) {
        case ERROR_OPEN:
            return {...state, isErrorModalOpen: true, errorBody: action.payload.message}
        case ERROR_CLOSE:
            return {...state, isErrorModalOpen: false, errorBody: ''}
        default: 
            return state;
        }    
}

export default errorReduser;