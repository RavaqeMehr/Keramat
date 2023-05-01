import React from 'react';
import Loading from './Loading';
import { Spinner } from 'reactstrap';

const BlurLayer = ({ show = true }) => {
	if (show) {
		return (
			<div
				style={{
					position: 'absolute',
					top: 0,
					bottom: 0,
					left: 0,
					right: 0,
					zIndex: 100,
					display: 'flex',
					justifyContent: 'center',
					alignItems: 'center',
				}}>
				<div
					style={{
						position: 'absolute',
						top: 0,
						bottom: 0,
						left: 0,
						right: 0,
						zIndex: 100,
						filter: 'blur(8px)',
						WebkitFilter: 'blur(8px)',
						backgroundColor: 'rgba(255,255,255,0.8)',
					}}></div>
				<div className='d-flex align-items-center justify-content-center p-5' style={{ zIndex: 101 }}>
					<Spinner color='success' />
				</div>
			</div>
		);
	} else {
		return null;
	}
};

export default BlurLayer;
