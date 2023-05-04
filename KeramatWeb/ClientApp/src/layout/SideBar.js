import { useState, useEffect } from 'react';
import { Menu, MenuItem, Sidebar, SubMenu } from 'react-pro-sidebar';
import React, { Link } from 'react-router-dom';
import _Navs from './_Navs';

const SideBar = () => {
	return (
		<Sidebar rtl>
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
	const [opens, opensSet] = useState({});

	useEffect(() => {
		if (!open) {
			opensSet((old) => {
				let newOpens = {};
				Object.keys(old).forEach((v) => (newOpens[v] = false));
				return newOpens;
			});
		}
	}, [open]);

	const children = items.map((x, i) =>
		x.to ? (
			<MItem key={i} {...x} />
		) : (
			<MSubMenu
				key={i}
				{...x}
				open={opens[i] ?? false}
				onOpenChange={(e) => globalOpenHandler(i, e, opens, opensSet)}
			/>
		)
	);

	if (isRoot) {
		return <>{children}</>;
	} else {
		return (
			<SubMenu label={title} onOpenChange={onOpenChange} open={open}>
				{children}
			</SubMenu>
		);
	}
};

const globalOpenHandler = (key, isOpen, opens, opensSet) => {
	if (isOpen) {
		opensSet((old) => {
			let newOpens = {};
			Object.keys(old).forEach((v) => (newOpens[v] = false));
			newOpens['' + key] = true;
			return newOpens;
		});
	} else {
		opensSet((old) => ({ ...old, ['' + key]: false }));
	}
};
