import './Layout.css';
import React from 'react';
import NavMenu from './NavMenu';
import { Container } from 'reactstrap';

const Layout = (props) => {
	return (
		<div>
			<NavMenu />
			<Container tag='main'>{props.children}</Container>
		</div>
	);
};

export default Layout;
