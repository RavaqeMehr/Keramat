import Home from '../views/Home';
import FamailiLevelForm from '../views/ValiNematan/FamailiLevelForm';
import FamailiLevelsList from '../views/ValiNematan/FamailiLevelsList';
import FamiliesList from '../views/ValiNematan/FamiliesList';
import FamilyForm from '../views/ValiNematan/FamilyForm';

const routes = [
	{ path: '/', name: 'کرامت', element: Home, exact: true },
	{ path: '/vali-nematan/families', name: 'ولی‌نعمتان', element: FamiliesList, exact: true },
	{ path: '/vali-nematan/families/:id', name: 'فرم خانواده', element: FamilyForm },
	{ path: '/vali-nematan/levels', name: 'سطح‌های خانواده', element: FamailiLevelsList, exact: true },
	{ path: '/vali-nematan/levels/:id', name: 'فرم سطح خانواده', element: FamailiLevelForm },
];

export default routes;
