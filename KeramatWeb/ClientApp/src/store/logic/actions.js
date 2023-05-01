import axios from 'axios';

export const updateLogics = () => {
	return async (dispatch) => {
		dispatch(updateAppInfo());
		dispatch(updateConnectors());
	};
};

export const UPDATE_FAMILY_LEVELS = 'LOGIC::UPDATE_FAMILY_LEVELS';
export const updateAppInfo = () => {
	return async (dispatch) => {
		axios
			.get('ValiNematan/FamilyLevels')
			.then((response) => response.data)
			.then((data) => {
				dispatch({ type: UPDATE_FAMILY_LEVELS, data: data.data });
			})
			.catch(console.error);
	};
};

export const UPDATE_CONNECTORS = 'LOGIC::UPDATE_CONNECTORS';
export const updateConnectors = () => {
	return async (dispatch) => {
		axios
			.get('ValiNematan/Connectors')
			.then((response) => response.data)
			.then((data) => {
				dispatch({ type: UPDATE_CONNECTORS, data: data.data });
			})
			.catch(console.error);
	};
};
