import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Dropdown, DropdownMenu, DropdownToggle, DropdownItem, Collapse } from 'reactstrap';
import NavLink from './NavLink';

const NavDropDown = ({ title, items = [], isRoot = true }) => {
	const [collapsed, colapsedSet] = useState(false);
	return (
		<Dropdown
			nav
			isOpen={collapsed}
			toggle={() => colapsedSet((old) => !old)}
			direction={isRoot ? 'down' : 'start'}>
			<DropdownToggle nav className='text-dark' caret>
				{title}
			</DropdownToggle>
			<Collapse className='d-sm-inline-flex flex-sm-row-reverse' isOpen={!collapsed} navbar>
				<DropdownMenu>
					{items.map((x, i) =>
						x.to ? (
							<NavLink key={i} title={x.title} to={x.to} />
						) : (
							<NavDropDown key={i} isRoot={false} title={x.title} items={x.items} />
						)
					)}
				</DropdownMenu>
			</Collapse>
		</Dropdown>
	);
};

export default NavDropDown;
