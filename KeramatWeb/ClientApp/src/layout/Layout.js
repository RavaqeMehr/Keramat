import React from 'react';
import { Container } from 'reactstrap';
import Header from './Header';
import './Layout.css';
import SideBar from './SideBar';

const Layout = (props) => {
	return (
		<div style={{ display: 'flex', minHeight: '100vh' }}>
			<SideBar />
			<div style={{ display: 'block', flex: 1, height: '100%' }}>
				<Header />
				<Container tag='main' className='py-3'>
					{props.children}
				</Container>
			</div>
		</div>
	);
};

export default Layout;
