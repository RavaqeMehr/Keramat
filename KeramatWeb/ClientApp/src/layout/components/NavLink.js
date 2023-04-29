import React from 'react';
import { Link } from 'react-router-dom';
import { NavItem as NavItemOrginal, NavLink as NavLinkOrginal } from 'reactstrap';

const NavLink = ({ title, to }) => {
	return (
		<NavItemOrginal>
			<NavLinkOrginal tag={Link} className='text-dark' to={to}>
				{title}
			</NavLinkOrginal>
		</NavItemOrginal>
	);
};

export default NavLink;
