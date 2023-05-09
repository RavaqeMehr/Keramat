import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { ReduxActions } from '../store';

import dayjs from 'dayjs';
import localeFa from 'dayjs/locale/fa';
import relativeTime from 'dayjs/plugin/relativeTime';
import jalaliday from 'jalaliday';

const AfterConfig = () => {
	const dispatch = useDispatch();

	useEffect(() => {
		const asyncer = async () => {
			dispatch(await ReduxActions.generalActions.updateAppInfo());
			dispatch(await ReduxActions.logicActions.updateLogics());
		};
		asyncer();

		dayjs.extend(relativeTime).extend(jalaliday).locale(localeFa);
	}, []);

	return null;
};

export default AfterConfig;
