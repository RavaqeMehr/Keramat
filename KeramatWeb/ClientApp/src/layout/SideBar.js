import { useState, useEffect, useRef } from 'react';
import { Menu, MenuItem, Sidebar, SubMenu } from 'react-pro-sidebar';
import React, { Link } from 'react-router-dom';
import _Navs from './_Navs';

const SideBar = () => {
	return (
		<Sidebar rtl className='d-print-none'>
			<Menu
				menuItemStyles={{
					subMenuContent: {
						background: '#0000000f',
						marginRight: '1em',
						borderRightWidth: 1,
						borderRightColor: 'black',
						borderRightStyle: 'dashed',
					},
				}}>
				<MSubMenu open items={_Navs} isRoot />
			</Menu>
		</Sidebar>
	);
};

export default SideBar;

const MItem = ({ title, to }) => <MenuItem component={<Link to={to} />}> {title}</MenuItem>;

const MSubMenu = ({ title, items, open = false, onOpenChange, isRoot = false }) => {
	const [active, activeSet] = useState(-1);

	useEffect(() => {
		if (!open) {
			activeSet(-1);
		}
	}, [open]);

	const openHandler = (opened, i) => {
		const prevActive = active;
		activeSet(opened ? i : -1);

		if (opened) {
			if (prevActive != i) {
				// fix bug of sub menu height
				if (subMenuRef?.current) {
					const child2 = subMenuRef?.current.children[1];
					if (child2.classList.contains('ps-submenu-content')) {
						child2.style.height = 'auto';
					}
				}
			}
		}
	};

	const subMenuRef = useRef();

	const children = items.map((x, i) =>
		x.to ? (
			<MItem key={i} {...x} />
		) : (
			<MSubMenu key={i} {...x} open={active == i} onOpenChange={(e) => openHandler(e, i)} />
		)
	);

	if (isRoot) {
		return <>{children}</>;
	} else {
		return (
			<SubMenu label={title} onOpenChange={onOpenChange} open={open} ref={subMenuRef}>
				{children}
			</SubMenu>
		);
	}
};
