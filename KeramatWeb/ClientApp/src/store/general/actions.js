import axios from 'axios';

export const UPDATE_APP_INFO = 'GENERAL::UPDATE_APP_INFO';
export const updateAppInfo = () => {
	return async (dispatch) => {
		axios
			.get('Home/AppInfo')
			.then((response) => response.data)
			.then((data) => {
				dispatch({ type: UPDATE_APP_INFO, data: data.data });
			})
			.catch(console.error);
	};
};

export const EXIT = 'GENERAL::EXIT';
export const exit = () => {
	return async (dispatch) => {
		dispatch({ type: EXIT });
	};
};
