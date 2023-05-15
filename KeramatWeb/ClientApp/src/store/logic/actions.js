import axios from 'axios';

export const updateLogics = () => {
	return async (dispatch) => {
		dispatch(updateFamilyLevels());
		dispatch(updateConnectors());
		dispatch(updateFamilyNeedSubjects());
		dispatch(updateFamilyMemberNeedSubjects());
		dispatch(updateFamilyMemberSpecialDiseaseSubjects());
		dispatch(updateFamilyMemberRelations());
		dispatch(updateServiceSubjects());
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

export const UPDATE_FAMILY_MEMBER_NEED_SUBJECTS = 'LOGIC::UPDATE_FAMILY_MEMBER_NEED_SUBJECTS';
export const updateFamilyMemberNeedSubjects = () => {
	return async (dispatch) => {
		axios
			.get('ValiNematan/FamilyMemberNeedSubjects')
			.then((response) => response.data)
			.then((data) => {
				dispatch({ type: UPDATE_FAMILY_MEMBER_NEED_SUBJECTS, data: data.data });
			})
			.catch(console.error);
	};
};

export const UPDATE_FAMILY_MEMBER_SPECIAL_DISEASE_SUBJECTS =
	'LOGIC::UPDATE_FAMILY_MEMBER_SPECIAL_DISEASE_SUBJECTS';
export const updateFamilyMemberSpecialDiseaseSubjects = () => {
	return async (dispatch) => {
		axios
			.get('ValiNematan/FamilyMemberSpecialDiseaseSubjects')
			.then((response) => response.data)
			.then((data) => {
				dispatch({ type: UPDATE_FAMILY_MEMBER_SPECIAL_DISEASE_SUBJECTS, data: data.data });
			})
			.catch(console.error);
	};
};

export const UPDATE_FAMILY_MEMBER_RELATIONS = 'LOGIC::UPDATE_FAMILY_MEMBER_RELATIONS';
export const updateFamilyMemberRelations = () => {
	return async (dispatch) => {
		axios
			.get('ValiNematan/FamilyMemberRelations')
			.then((response) => response.data)
			.then((data) => {
				dispatch({ type: UPDATE_FAMILY_MEMBER_RELATIONS, data: data.data });
			})
			.catch(console.error);
	};
};

export const UPDATE_SERVICE_SUBJECTS = 'LOGIC::UPDATE_SERVICE_SUBJECTS';
export const updateServiceSubjects = () => {
	return async (dispatch) => {
		axios
			.get('Services/Subjects')
			.then((response) => response.data)
			.then((data) => {
				dispatch({ type: UPDATE_SERVICE_SUBJECTS, data: data.data });
			})
			.catch(console.error);
	};
};
