import * as actions from './actions';

const initialState = {
	appInfo: null,
};

export default (state = initialState, { type, ...rest }) => {
	switch (type) {
		case actions.UPDATE_APP_INFO:
			return {
				...state,
				appInfo: rest.data,
			};

		default:
			return state;
	}
};
