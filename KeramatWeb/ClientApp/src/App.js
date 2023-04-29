import React from 'react';
import Layout from './layout/Layout';
import routes from './layout/routes';
import { Routes, Route } from 'react-router-dom';
import { useSelector } from 'react-redux';
import LoadingCenter from './components/general/LoadingCenter';

const App = () => {
	const { appInfo } = useSelector((x) => x.general);

	return appInfo ? (
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
