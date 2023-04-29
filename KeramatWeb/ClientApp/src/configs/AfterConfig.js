import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { ReduxActions } from '../store';

const AfterConfig = () => {
	const dispatch = useDispatch();

	useEffect(() => {
		dispatch(ReduxActions.generalActions.updateAppInfo());
	}, []);

	return null;
};

export default AfterConfig;
