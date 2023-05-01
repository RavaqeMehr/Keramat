import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import ReduxThunk from 'redux-thunk';

import * as generalActions from './general/actions';
import generalReducer from './general/reducers';

import * as logicActions from './logic/actions';
import logicReducer from './logic/reducers';

export const ReduxReducers = combineReducers({
	general: generalReducer,
	logic: logicReducer,
});

export const ReduxActions = {
	generalActions,
	logicActions,
};

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
export const store = createStore(
	ReduxReducers,
	/* preloadedState, */ composeEnhancers(applyMiddleware(ReduxThunk))
);
