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
import FamilyMemberNeedSubjectsList from '../views/ValiNematan/FamilyMemberNeedSubjectsList';
import FamilyMemberNeedSubjectForm from '../views/ValiNematan/FamilyMemberNeedSubjectForm';
import FamilyMemberSpecialDiseaseSubjectsList from '../views/ValiNematan/FamilyMemberSpecialDiseaseSubjectsList';
import FamilyMemberSpecialDiseaseSubjectForm from '../views/ValiNematan/FamilyMemberSpecialDiseaseSubjectForm';
import FamilyMemberRelationsList from './../views/ValiNematan/FamilyMemberRelationsList';
import FamilyMemberRelationForm from './../views/ValiNematan/FamilyMemberRelationForm';
import FamilyMemberForm from '../views/ValiNematan/FamilyMemberForm';
import Sesseions from './../views/Manage/Sesseions';
import ChangesLog from '../views/Manage/ChangesLog';
import Settings from './../views/Manage/Settings';
import Donation from './../views/Donation';
import AboutApp from './../views/About/AboutApp';
import AboutIssues from './../views/About/AboutIssues';
import AboutTools from './../views/About/AboutTools';

const routes = [
	{ path: '/', name: 'کرامت', element: Home, exact: true },
	{ path: '/exit', name: 'خروج', element: Exit, exact: true },
	{ path: '/donation', name: 'حمایت مالی از پروژه', element: Donation, exact: true },
	///////////
	{ path: '/vali-nematan/families', name: 'ولی‌نعمتان', element: FamiliesList, exact: true },
	{ path: '/vali-nematan/families/:id', name: 'فرم خانواده', element: FamilyForm, exact: true },
	{ path: '/vali-nematan/families/:familyId/:id', name: 'فرم عضو خانواده', element: FamilyMemberForm },
	///////////
	{ path: '/vali-nematan/levels', name: 'سطح‌های خانواده', element: FamailiLevelsList, exact: true },
	{ path: '/vali-nematan/levels/:id', name: 'فرم سطح خانواده', element: FamailiLevelForm },
	///////////
	{ path: '/vali-nematan/connectors', name: 'معرف‌های خانواده', element: ConnectorsList, exact: true },
	{ path: '/vali-nematan/connectors/:id', name: 'فرم رابط خانواده', element: ConnectorForm },
	{
		path: '/vali-nematan/family-needs',
		name: 'نیازهای خانواده',
		element: FamilyNeedSubjectsList,
		exact: true,
	},
	{ path: '/vali-nematan/family-needs/:id', name: 'فرم نیاز خانواده', element: FamilyNeedSubjectForm },
	///////////
	{
		path: '/vali-nematan/member-needs',
		name: 'نیازهای اعضای خانواده',
		element: FamilyMemberNeedSubjectsList,
		exact: true,
	},
	{
		path: '/vali-nematan/member-needs/:id',
		name: 'فرم نیاز اعضای خانواده',
		element: FamilyMemberNeedSubjectForm,
	},
	///////////
	{
		path: '/vali-nematan/special-disease',
		name: 'بیماری‌های خاص',
		element: FamilyMemberSpecialDiseaseSubjectsList,
		exact: true,
	},
	{
		path: '/vali-nematan/special-disease/:id',
		name: 'فرم بیماری خاص',
		element: FamilyMemberSpecialDiseaseSubjectForm,
	},
	///////////
	{
		path: '/vali-nematan/relations',
		name: 'نسبت‌های خانوادگی',
		element: FamilyMemberRelationsList,
		exact: true,
	},
	{
		path: '/vali-nematan/relations/:id',
		name: 'فرم نسبت خانوادگی',
		element: FamilyMemberRelationForm,
	},
	///////////
	{ path: '/manage/sessions', name: 'نشست‌ها', element: Sesseions, exact: true },
	{ path: '/manage/changes-log/:id?', name: 'لاگ تغییرات', element: ChangesLog },
	{ path: '/manage/settings', name: 'تنظیمات', element: Settings, exact: true },
	///////////
	{ path: '/about/app', name: 'معرفی اپلیکیشن', element: AboutApp, exact: true },
	{ path: '/about/issues', name: 'گزارش خطا', element: AboutIssues, exact: true },
	{ path: '/about/tools', name: 'ابزارهای شخص ثالث', element: AboutTools, exact: true },
];

export default routes;
