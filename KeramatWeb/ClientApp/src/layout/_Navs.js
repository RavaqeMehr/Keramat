const _Navs = [
	{
		title: 'پیش‌خان',
		to: '/',
	},
	// {
	// 	component: NavDropDown,
	// 	title: 'ولی‌نعمتان',
	// 	items: [
	// 		{
	// 			component: NavLink,
	// 			title: 'الف',
	// 			to: '/',
	// 		},
	// 		{
	// 			component: NavDropDown,
	// 			title: 'سطح 2',
	// 			items: [
	// 				{
	// 					component: NavLink,
	// 					title: 'الف',
	// 					to: '/',
	// 				},
	// 				{
	// 					component: NavLink,
	// 					title: 'ب',
	// 					to: '/',
	// 				},
	// 				{
	// 					component: NavLink,
	// 					title: 'جیم3',
	// 					to: '/',
	// 				},
	// 			],
	// 		},
	// 		{
	// 			component: NavLink,
	// 			title: 'ب',
	// 			to: '/',
	// 		},
	// 		{
	// 			component: NavLink,
	// 			title: 'جیم3',
	// 			to: '/',
	// 		},
	// 	],
	// },
	{
		title: 'ولی‌نعمتان',
		items: [
			{ title: 'خانواده‌ها', to: '/vali-nematan' },
			{ title: 'سطح‌ها', to: '/vali-nematan-levels' },
			{
				title: 'ولی‌نعمتان',
				items: [
					{ title: 'خانواده‌ها', to: '/vali-nematan' },
					{ title: 'سطح‌ها', to: '/vali-nematan-levels' },
				],
			},
		],
	},
];

export default _Navs;
