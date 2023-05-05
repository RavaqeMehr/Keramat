import axios from 'axios';
import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Alert, Button } from 'reactstrap';
import ScreenCenter from '../components/ui/ScreenCenter';
import { ReduxActions } from '../store';

const Exit = () => {
	const dispatch = useDispatch();
	const { exited } = useSelector((x) => x.general);

	const exit = () => {
		try {
			axios.delete('Home/Exit');
		} catch (error) {
		} finally {
			dispatch(ReduxActions.generalActions.exit());
		}
	};
	if (!exited) {
		return (
			<>
				<Alert color='info' className='text-center'>
					پیشنهاد می‌شود جهت حفظ اطمینان از ذخیره صحیح آخرین تغییرات در بانک اطلاعاتی، پس از اتمام کار، از
					طریق دکمه زیر از اپلیکیشن خارج شوید.
				</Alert>
				<Button block color='danger' onClick={exit}>
					خروج
				</Button>
			</>
		);
	} else {
		return <AfterExit />;
	}
};

export default Exit;

export const AfterExit = () => (
	<ScreenCenter>
		<Alert color='success' className='text-center'>
			حالا با خیال راحت مرورگر خود را ببندید!
		</Alert>
	</ScreenCenter>
);
