import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { ReduxActions } from '../store';

const AfterConfig = () => {
	const dispatch = useDispatch();

	useEffect(() => {
		const asyncer = async () => {
			dispatch(await ReduxActions.generalActions.updateAppInfo());
			dispatch(await ReduxActions.logicActions.updateLogics());
		};
		asyncer();
	}, []);

	return null;
};

export default AfterConfig;
