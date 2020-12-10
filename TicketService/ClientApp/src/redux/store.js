import reducer from './reducer';
import ticketReduser from './ticket/'
import { createStore, combineReducers } from 'redux';
import {reducer as reducerForm} from 'redux-form';

const commonReducer = combineReducers({
    reducerOld: reducer,
    ticket: ticketReduser,
    form: reducerForm
})
const store = createStore(commonReducer);

export default store;