import { Menu, MenuItem, Sidebar, SubMenu } from 'react-pro-sidebar';
import React, { Link } from 'react-router-dom';
import _Navs from './_Navs';

const SideBar = () => {
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
				{_Navs.map((x, i) => (x.to ? <MItem key={i} {...x} /> : <MSubMenu key={i} {...x} />))}
			</Menu>
		</Sidebar>
	);
};

export default SideBar;

const MItem = ({ title, to }) => <MenuItem component={<Link to={to} />}> {title}</MenuItem>;

const MSubMenu = ({ title, items }) => (
	<SubMenu label={title}>
		{items.map((x, i) => (x.to ? <MItem key={i} {...x} /> : <MSubMenu key={i} {...x} />))}
	</SubMenu>
);
