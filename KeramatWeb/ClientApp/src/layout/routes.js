import Home from '../views/Home';
import FamiliesList from '../views/ValiNematan/FamiliesList';

const routes = [
	{ path: '/', name: 'کرامت', element: Home, exact: true },
	{ path: '/vali-nematan', name: 'ولی‌نعمتان', element: FamiliesList, exact: true },
];

export default routes;
