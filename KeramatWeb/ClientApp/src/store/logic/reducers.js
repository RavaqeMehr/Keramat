import * as actions from './actions';

const initialState = {
	familyLevels: [],
	connectors: [],
};

export default (state = initialState, { type, ...rest }) => {
	switch (type) {
		case actions.UPDATE_FAMILY_LEVELS:
			return {
				...state,
				familyLevels: rest.data,
			};
		case actions.UPDATE_CONNECTORS:
			return {
				...state,
				connectors: rest.data,
			};

		default:
			return state;
	}
};
