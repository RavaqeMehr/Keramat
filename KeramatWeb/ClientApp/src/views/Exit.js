import React, { useState } from 'react';
import { Alert, Button } from 'reactstrap';
import axios from 'axios';

const Exit = () => {
	const [step, stepSet] = useState(0);
	const exit = () => {
		try {
			axios.delete('Home/Exit');
		} catch (error) {
		} finally {
			stepSet(1);
		}
	};
	if (step == 0) {
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
		return (
			<Alert color='success' className='text-center'>
				حالا با خیال راحت مرورگر خود را ببندید!
			</Alert>
		);
	}
};

export default Exit;
