import React from 'react';
import { Spinner } from 'reactstrap';

const LoadingCenter = () => (
	<div style={{ height: '100vh' }} className='d-flex align-items-center justify-content-center'>
		<Spinner color='success' />
	</div>
);

export default LoadingCenter;
