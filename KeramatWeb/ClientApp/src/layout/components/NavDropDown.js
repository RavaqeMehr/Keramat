import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Dropdown, DropdownMenu, DropdownToggle, DropdownItem } from 'reactstrap';

const NavDropDown = ({ title, items = [], isRoot = true }) => {
	const [open, openSet] = useState(false);
	return (
		<Dropdown nav isOpen={open} toggle={() => openSet((old) => !old)} direction={isRoot ? 'down' : 'start'}>
			<DropdownToggle nav className='text-dark' caret>
				{title}
			</DropdownToggle>
			<DropdownMenu>
				{items.map((x, i) => (
					<x.component key={i} {...x} isRoot={false} />
				))}
			</DropdownMenu>
		</Dropdown>
	);
};

export default NavDropDown;
