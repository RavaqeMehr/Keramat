import React from 'react';
import { Spinner } from 'reactstrap';

const Loading = () => (
	<div className='d-flex align-items-center justify-content-center p-5'>
		<Spinner color='success' />
	</div>
);

export default Loading;
