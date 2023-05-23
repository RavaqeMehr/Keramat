import React from 'react';
import { useProSidebar } from 'react-pro-sidebar';
import { useSelector } from 'react-redux';
import { Link } from 'react-router-dom';
import { Navbar, NavbarBrand, NavbarText } from 'reactstrap';
import { appName } from './../consts';
import { useCurrentRoute } from './../helpers/RoutesHelpers';

const Header = () => {
	const { collapseSidebar } = useProSidebar();
	var currentRoute = useCurrentRoute();
	const { appInfo } = useSelector((x) => x.general);

	return (
		<Navbar color='light' light>
			<NavbarBrand tag={Link} to='/'>
				{appInfo.charityName}
			</NavbarBrand>
			<NavbarText className='text-dark'>{currentRoute?.route.name}</NavbarText>
			<NavbarText>
				{appName} <small>{appInfo.appVersion}</small>
			</NavbarText>
		</Navbar>
	);
};

export default Header;
