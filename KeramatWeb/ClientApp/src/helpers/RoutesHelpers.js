import { matchRoutes, useLocation } from 'react-router-dom';
import routes from './../layout/routes';

export const useCurrentRoute = () => {
	const location = useLocation();
	try {
		const [{ route }] = matchRoutes(routes, location);
		return { route, location };
	} catch (error) {
		return null;
	}
};
