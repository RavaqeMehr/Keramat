import React from 'react';
import { apiUrl } from '../consts';
import { useSelector } from 'react-redux';

const Home = () => {
	const { appInfo } = useSelector((x) => x.general);
	return (
		<div
			style={{
				display: 'flex',
				flexDirection: 'column',
				justifyContent: 'center',
				alignItems: 'center',
			}}>
			<img src='assets/images/emam-hasan.jpg' alt='السلام علیک یا حسن بن علی المجتبی' />
			<h5 className='mt-2'>{appInfo.charityName}</h5>
			<h6>{appInfo.charitySlogan}</h6>
		</div>
	);
};

export default Home;
