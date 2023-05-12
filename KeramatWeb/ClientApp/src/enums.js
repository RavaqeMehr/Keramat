const enumItemMaker = (key, val, text) => ({ key, val, text });

export const _LiveStatus = [
	enumItemMaker('NotSet', -1, 'نامشخص'),
	enumItemMaker('Live', 0, 'زنده'),
	enumItemMaker('Coma', 1, 'کما'),
	enumItemMaker('Dead', 2, 'فوت‌شده'),
	enumItemMaker('Martyr', 3, 'شهید'),
];

export const _Gender = [
	enumItemMaker('NotSet', -1, 'نامشخص'),
	enumItemMaker('Male', 0, 'مذکر'),
	enumItemMaker('Female', 1, 'مونث'),
	enumItemMaker('Intersex', 2, 'دوجنسه'),
];

export const _MaritalStatus = [
	enumItemMaker('NotSet', -1, 'نامشخص'),
	enumItemMaker('Single', 0, 'مجرد'),
	enumItemMaker('Married', 1, 'متاهل'),
	enumItemMaker('Widow', 2, 'بیوه'),
	enumItemMaker('Divorced', 3, 'مطلقه'),
];

export const _ChangeType = [
	enumItemMaker('Add', 1, 'افزودن'),
	enumItemMaker('Edit', 2, 'ویرایش'),
	enumItemMaker('Delete', 3, 'حذف'),
];

export const _EnitityType = [
	enumItemMaker('NotSet', -1, 'نامشخص'),

	enumItemMaker('Family', 100, 'خانواده'),
	enumItemMaker('FamilyLevel', 101, 'سطح خانواده'),
	enumItemMaker('FamilyNeed', 102, 'نیاز خانواده'),
	enumItemMaker('FamilyNeedSubject', 103, 'موضوع نیاز خانواده'),
	enumItemMaker('Connector', 104, 'معرف'),

	enumItemMaker('FamilyMember', 110, 'عضو'),
	enumItemMaker('FamilyMemberNeed', 111, 'نیاز عضو'),
	enumItemMaker('FamilyMemberNeedSubject', 112, 'موضوع نیاز عضو'),
	enumItemMaker('FamilyMemberRelation', 113, 'نسبت خانوادگی'),
	enumItemMaker('FamilyMemberSpecialDisease', 114, 'بیماری خاص عضو'),
	enumItemMaker('FamilyMemberSpecialDiseaseSubject', 115, 'موضوع بیماری خاص عضو'),

	enumItemMaker('NikooKar', 130, 'نیکوکار'),
	enumItemMaker('Kheyr', 131, 'خیرات'),
];
