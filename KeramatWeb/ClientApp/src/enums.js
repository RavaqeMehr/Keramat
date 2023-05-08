const enumItem = (key, val, text) => ({ key, val, text });

export const _LiveStatus = [
	enumItem('NotSet', -1, 'نامشخص'),
	enumItem('Live', 0, 'زنده'),
	enumItem('Coma', 1, 'کما'),
	enumItem('Dead', 2, 'فوت‌شده'),
	enumItem('Martyr', 3, 'شهید'),
];

export const _Gender = [
	enumItem('NotSet', -1, 'نامشخص'),
	enumItem('Male', 0, 'مذکر'),
	enumItem('Female', 1, 'مونث'),
	enumItem('Intersex', 2, 'دوجنسه'),
];

export const _MaritalStatus = [
	enumItem('NotSet', -1, 'نامشخص'),
	enumItem('Single', 0, 'مجرد'),
	enumItem('Married', 1, 'متاهل'),
	enumItem('Widow', 2, 'بیوه'),
	enumItem('Divorced', 3, 'مطلقه'),
];
