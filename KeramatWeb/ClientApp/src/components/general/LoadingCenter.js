import React from 'react';
import { Spinner } from 'reactstrap';
import ScreenCenter from '../ui/ScreenCenter';

const LoadingCenter = () => (
	<ScreenCenter>
		<Spinner color='success' />
	</ScreenCenter>
);

export default LoadingCenter;
