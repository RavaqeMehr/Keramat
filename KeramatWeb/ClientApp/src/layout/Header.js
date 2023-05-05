import React from 'react';
import { useProSidebar } from 'react-pro-sidebar';
import { Link } from 'react-router-dom';
import { Navbar, NavbarBrand, NavbarText } from 'reactstrap';
import { appName } from './../consts';
import { useCurrentRoute } from './../helpers/RoutesHelpers';
import { useSelector } from 'react-redux';

const Header = () => {
	const { collapseSidebar } = useProSidebar();
	var currentRoute = useCurrentRoute();
	const { appInfo } = useSelector((x) => x.general);

	return (
		<Navbar color='light' light>
			{/* <NavbarToggler
				onClick={() => {
					collapseSidebar();
				}}
				className='mx-2'
			/> */}

			<NavbarBrand tag={Link} to='/'>
				{appInfo.charityName}
			</NavbarBrand>
			<NavbarText className='text-dark'>{currentRoute?.name}</NavbarText>
			<NavbarText>{appName}</NavbarText>
		</Navbar>
	);
};

export default Header;
