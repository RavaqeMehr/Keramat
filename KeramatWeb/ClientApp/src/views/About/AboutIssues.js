import React from 'react';
import { Alert } from 'reactstrap';

const AboutIssues = () => {
	return (
		<>
			<Alert color='info' className='text-center'>
				اگر در حین استفاده از این پروژه با خطایی روبرو شدید، جهت گزارش و رفع ایرادات آن لازم است در{' '}
				<a href='https://github.com/RavaqeMehr/Keramat/issues' target='_Blank'>
					این صفحه
				</a>{' '}
				مشکل به وجود آمده را گزارش کنید.
			</Alert>
			<Alert color='warning' className='text-center'>
				در صورت نداشتن حساب کاربری در گیت‌هاب، ابتدا به صورت رایگان در آن عضو شوید.
			</Alert>
		</>
	);
};

export default AboutIssues;
