import * as actions from './actions';

const initialState = {
	appInfo: null,
	exited: false,
};

export default (state = initialState, { type, ...rest }) => {
	switch (type) {
		case actions.UPDATE_APP_INFO:
			return {
				...state,
				appInfo: rest.data,
			};
		case actions.EXIT:
			return {
				...state,
				exited: true,
			};

		default:
			return state;
	}
};
