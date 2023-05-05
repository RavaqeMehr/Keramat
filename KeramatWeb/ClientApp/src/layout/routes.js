import Home from '../views/Home';
import Exit from '../views/Exit';
import FamailiLevelForm from '../views/ValiNematan/FamailiLevelForm';
import FamailiLevelsList from '../views/ValiNematan/FamailiLevelsList';
import FamiliesList from '../views/ValiNematan/FamiliesList';
import FamilyForm from '../views/ValiNematan/FamilyForm';
import ConnectorsList from './../views/ValiNematan/ConnectorsList';
import ConnectorForm from './../views/ValiNematan/ConnectorForm';
import FamilyNeedSubjectsList from './../views/ValiNematan/FamilyNeedSubjectsList';
import FamilyNeedSubjectForm from './../views/ValiNematan/FamilyNeedSubjectForm';

const routes = [
	{ path: '/', name: 'کرامت', element: Home, exact: true },
	{ path: '/exit', name: 'خروج', element: Exit, exact: true },
	{ path: '/vali-nematan/families', name: 'ولی‌نعمتان', element: FamiliesList, exact: true },
	{ path: '/vali-nematan/families/:id', name: 'فرم خانواده', element: FamilyForm },
	{ path: '/vali-nematan/levels', name: 'سطح‌های خانواده', element: FamailiLevelsList, exact: true },
	{ path: '/vali-nematan/levels/:id', name: 'فرم سطح خانواده', element: FamailiLevelForm },
	{ path: '/vali-nematan/connectors', name: 'رابط‌های خانواده', element: ConnectorsList, exact: true },
	{ path: '/vali-nematan/connectors/:id', name: 'فرم رابط خانواده', element: ConnectorForm },
	{
		path: '/vali-nematan/family-needs',
		name: 'نیازهای خانواده',
		element: FamilyNeedSubjectsList,
		exact: true,
	},
	{ path: '/vali-nematan/family-needs/:id', name: 'فرم نیاز خانواده', element: FamilyNeedSubjectForm },
];

export default routes;
