import axios from 'axios';

export const updateLogics = () => {
	return async (dispatch) => {
		dispatch(updateFamilyLevels());
		dispatch(updateConnectors());
		dispatch(updateFamilyNeedSubjects());
	};
};

export const UPDATE_FAMILY_LEVELS = 'LOGIC::UPDATE_FAMILY_LEVELS';
export const updateFamilyLevels = () => {
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

export const UPDATE_FAMILY_NEED_SUBJECTS = 'LOGIC::UPDATE_FAMILY_NEED_SUBJECTS';
export const updateFamilyNeedSubjects = () => {
	return async (dispatch) => {
		axios
			.get('ValiNematan/FamilyNeedSubjects')
			.then((response) => response.data)
			.then((data) => {
				dispatch({ type: UPDATE_FAMILY_NEED_SUBJECTS, data: data.data });
			})
			.catch(console.error);
	};
};
