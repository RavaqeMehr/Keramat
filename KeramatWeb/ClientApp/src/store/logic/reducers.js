import * as actions from './actions';

const initialState = {
	familyLevels: [],
	connectors: [],
	familyNeedSubjects: [],
	familyMemberNeedSubjects: [],
	familyMemberSpecialDiseaseSubjects: [],
	familyMemberRelations: [],
	serviceSubjects: [],
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
		case actions.UPDATE_FAMILY_NEED_SUBJECTS:
			return {
				...state,
				familyNeedSubjects: rest.data,
			};
		case actions.UPDATE_FAMILY_MEMBER_NEED_SUBJECTS:
			return {
				...state,
				familyMemberNeedSubjects: rest.data,
			};
		case actions.UPDATE_FAMILY_MEMBER_SPECIAL_DISEASE_SUBJECTS:
			return {
				...state,
				familyMemberSpecialDiseaseSubjects: rest.data,
			};
		case actions.UPDATE_FAMILY_MEMBER_RELATIONS:
			return {
				...state,
				familyMemberRelations: rest.data,
			};
		case actions.UPDATE_SERVICE_SUBJECTS:
			return {
				...state,
				serviceSubjects: rest.data,
			};

		default:
			return state;
	}
};
