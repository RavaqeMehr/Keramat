import React from 'react';
import { useProSidebar } from 'react-pro-sidebar';
import { Container } from 'reactstrap';
import './Layout.css';
import NavMenu from './NavMenu';
import SideBar from './SideBar';

const Layout = (props) => {
	const { collapseSidebar } = useProSidebar();

	return (
		<div style={{ display: 'flex', minHeight: '100vh' }}>
			<SideBar />
			<div style={{ display: 'block', flex: 1, height: '100%' }}>
				<NavMenu />
				<Container tag='main'>{props.children}</Container>
			</div>
		</div>
	);
};

export default Layout;
