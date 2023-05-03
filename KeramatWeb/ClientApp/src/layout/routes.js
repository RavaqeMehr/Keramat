import Home from '../views/Home';
import FamiliesList from '../views/ValiNematan/FamiliesList';
import FamilyForm from '../views/ValiNematan/FamilyForm';

const routes = [
	{ path: '/', name: 'کرامت', element: Home, exact: true },
	{ path: '/vali-nematan/families', name: 'ولی‌نعمتان', element: FamiliesList, exact: true },
	{ path: '/vali-nematan/families/:id', name: 'فرم خانواده', element: FamilyForm },
];

export default routes;
