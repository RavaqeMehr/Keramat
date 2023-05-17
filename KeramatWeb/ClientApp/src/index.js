import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { createRoot } from 'react-dom/client';
import { ProSidebarProvider } from 'react-pro-sidebar';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import Configs from './configs';
import 'react-notifications/lib/notifications.css';

import { store } from './store';
import { NotificationContainer } from 'react-notifications';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
	<Provider store={store}>
		<ProSidebarProvider>
			<BrowserRouter basename={baseUrl}>
				<Configs />
				<App />
				<NotificationContainer />
			</BrowserRouter>
		</ProSidebarProvider>
	</Provider>
);
