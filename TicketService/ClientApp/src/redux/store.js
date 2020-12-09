import reducer from './reducer';
import ticketReduser from './ticket/'
import { createStore, combineReducers } from 'redux';

const commonReducer = combineReducers({
    reducerOld: reducer,
    ticket: ticketReduser
})
const store = createStore(commonReducer);

export default store;