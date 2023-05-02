import './NavMenu.css';

import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Collapse, Navbar, NavbarBrand, NavbarToggler } from 'reactstrap';
import _Navs from './_Navs';
import NavLink from './components/NavLink';
import NavDropDown from './components/NavDropDown';

const NavMenu = (props) => {
	const [collapsed, colapsedSet] = useState(false);

	return (
		<header>
			<Navbar
				className='navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3'
				container
				light>
				<NavbarBrand tag={Link} to='/'>
					کرامت
				</NavbarBrand>
				<NavbarToggler onClick={() => colapsedSet((old) => !old)} className='ms-2' />
				<Collapse className='d-sm-inline-flex flex-sm-row-reverse' isOpen={!collapsed} navbar>
					<ul className='navbar-nav flex-grow'>
						{_Navs.map((x, i) => (x.to ? <NavLink key={i} {...x} /> : <NavDropDown key={i} {...x} />))}
					</ul>
				</Collapse>
			</Navbar>
		</header>
	);
};

export default NavMenu;
