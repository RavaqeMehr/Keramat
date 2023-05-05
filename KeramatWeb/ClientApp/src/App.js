import React from 'react';
import Layout from './layout/Layout';
import routes from './layout/routes';
import { Routes, Route } from 'react-router-dom';
import { useSelector } from 'react-redux';
import LoadingCenter from './components/general/LoadingCenter';
import { AfterExit } from './views/Exit';

const App = () => {
	const { appInfo, exited } = useSelector((x) => x.general);

	return exited ? (
		<AfterExit />
	) : appInfo ? (
		<Layout>
			<Routes>
				{routes.map((route, index) => {
					const { element, ...rest } = route;
					return <Route key={index} Component={element} {...rest} />;
				})}
			</Routes>
		</Layout>
	) : (
		<LoadingCenter />
	);
};

export default App;
