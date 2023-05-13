const _Navs = [
	{
		title: 'پیش‌خان',
		to: '/',
	},
	{
		title: 'ولی‌نعمتان',
		items: [
			{ title: 'خانواده‌ها', to: '/vali-nematan/families' },
			{
				title: 'مرتبط با خانواده',
				items: [
					{ title: 'سطح‌ها', to: '/vali-nematan/levels' },
					{ title: 'معرف‌ها', to: '/vali-nematan/connectors' },
					{ title: 'نیازهای خانواده', to: '/vali-nematan/family-needs' },
				],
			},
			{
				title: 'مرتبط با اعضای خانواده',
				items: [
					{ title: 'نیازهای اعضا', to: '/vali-nematan/member-needs' },
					{ title: 'بیماری‌های خاص', to: '/vali-nematan/special-disease' },
					{ title: 'نسبت‌های خانوادگی', to: '/vali-nematan/relations' },
				],
			},
		],
	},
	{
		title: 'خیرات',
		items: [
			{ title: 'نیکوکاران', to: '/kheyrat/nikoo-karan' },
			{ title: 'دریافتی‌ها', to: '/kheyrat/reciveds' },
		],
	},
	{
		title: 'خدمات',
		items: [
			{ title: 'موضوعات', to: '/services/subjects' },
			{ title: 'ارائه‌شده', to: '/services/provided' },
		],
	},
	{
		title: 'مدیریت',
		items: [
			{ title: 'نشست‌ها', to: '/manage/sessions' },
			{ title: 'لاگ تغییرات', to: '/manage/changes-log' },
			{ title: 'تنظیمات', to: '/manage/settings' },
		],
	},
	{
		title: 'درباره',
		items: [
			{ title: 'اپلیکیشن', to: '/about/app' },
			{ title: 'گزارش خطا', to: '/about/issues' },
		],
	},
	{
		title: 'حمایت مالی از پروژه',
		to: '/donation',
	},
	{
		title: 'خروج',
		to: '/exit',
	},
];

export default _Navs;
