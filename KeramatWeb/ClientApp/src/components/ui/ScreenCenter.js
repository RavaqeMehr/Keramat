import React from 'react';

const ScreenCenter = (props) => (
	<div style={{ height: '100vh' }} className='d-flex align-items-center justify-content-center'>
		{props.children}
	</div>
);

export default ScreenCenter;
