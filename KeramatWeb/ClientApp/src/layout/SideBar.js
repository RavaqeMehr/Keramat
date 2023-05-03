import { useState, useEffect } from 'react';
import { Menu, MenuItem, Sidebar, SubMenu } from 'react-pro-sidebar';
import React, { Link } from 'react-router-dom';
import _Navs from './_Navs';

const SideBar = () => {
	const [opens, opensSet] = useState({});

	return (
		<Sidebar rtl>
			<Menu
				menuItemStyles={{
					subMenuContent: {
						background: '#FBFBFB',
						marginRight: '1em',
						borderRightWidth: 1,
						borderRightColor: 'black',
						borderRightStyle: 'dashed',
					},
				}}>
				{_Navs.map((x, i) =>
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
				)}
			</Menu>
		</Sidebar>
	);
};

export default SideBar;

const MItem = ({ title, to }) => <MenuItem component={<Link to={to} />}> {title}</MenuItem>;

const MSubMenu = ({ title, items, open = false, onOpenChange }) => {
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

	return (
		<SubMenu label={title} onOpenChange={onOpenChange} open={open}>
			{items.map((x, i) =>
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
			)}
		</SubMenu>
	);
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
