import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { createRoot } from 'react-dom/client';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import Configs from './configs';

import { store } from './store';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
	<Provider store={store}>
		<BrowserRouter basename={baseUrl}>
			<Configs />
			<App />
		</BrowserRouter>
	</Provider>
);
