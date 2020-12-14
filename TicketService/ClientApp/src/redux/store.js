import reducer from './reducer';
import ticketReduser from './ticket/'
import { createStore, combineReducers, applyMiddleware } from 'redux';
import {reducer as reducerForm} from 'redux-form';
import thunk from 'redux-thunk';

const commonReducer = combineReducers({
    reducerOld: reducer,
    ticket: ticketReduser,
    form: reducerForm
})
const store = createStore(commonReducer, applyMiddleware(thunk));

export default store;