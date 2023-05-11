import React from 'react';
import { Alert } from 'reactstrap';

const AboutTools = () => {
	return (
		<>
			<Alert color='info' className='text-center'>
				با توجه به اینکه کرامت، یک پروژه Open Source است و از ابزارهای مختلفی در دل خود بهره می‌برد؛ جهت اطلاع
				از ابزارهای شخص ثالث مورد استفاده در پروژه، می‌توانید به{' '}
				<a href='https://github.com/RavaqeMehr/Keramat/network/dependencies' target='_Blank'>
					اینجا
				</a>{' '}
				مراجعه کنید.
			</Alert>
		</>
	);
};

export default AboutTools;
