import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import ReduxThunk from 'redux-thunk';

import * as generalActions from './general/actions';
import generalReducer from './general/reducers';

export const ReduxReducers = combineReducers({
	general: generalReducer,
});

export const ReduxActions = {
	generalActions,
};

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
export const store = createStore(
	ReduxReducers,
	/* preloadedState, */ composeEnhancers(applyMiddleware(ReduxThunk))
);
