import { NotificationManager } from 'react-notifications';

export const apiError = (e) => {
	console.log(e);
	let message = e.response.data.Message;
	try {
		const json = JSON.parse(message);
		message = json.Exception ?? message;
	} catch (error) {}
	console.log(e);

	notif(message, 'خطا!', 'error', 10000);
};

/**
 *
 * @param  {('info'|'success'|'warning'|'error')} type
 */
export const notif = (message, title, type = 'info', duration = 5000) => {
	switch (type) {
		case 'info':
			NotificationManager.info(message, title, duration);
			break;
		case 'success':
			NotificationManager.success(message, title, duration);
			break;
		case 'warning':
			NotificationManager.warning(message, title, duration);
			break;
		case 'error':
			NotificationManager.error(message, title, duration);
			break;
	}
};
