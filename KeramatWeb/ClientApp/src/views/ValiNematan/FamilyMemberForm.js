import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useSelector } from 'react-redux';
import axios from 'axios';
import MyAccordion from '../../components/ui/MyAccordion';
import * as enums from '../../enums';
import MyForm from './../../components/form/MyForm';
import InputText from './../../components/form/InputText';
import { Alert, Button } from 'reactstrap';
import MemeberNeeds from './components/MemeberNeeds';
import MemeberSpecialDiseases from './components/MemeberSpecialDiseases';

const FamilyMemberForm = () => {
	const navigate = useNavigate();
	const { id, familyId } = useParams();
	const { familyMemberNeedSubjects, familyMemberSpecialDiseaseSubjects, familyMemberRelations } = useSelector(
		(x) => x.logic
	);

	const [form, formSet] = useState({
		loading: true,
		items: {
			// ==> all
			familyMemberRelationId: familyMemberRelations[0]?.id ?? 0,
			gender: -1,
			maritalStatus: -1,
			name: '',
			lastName: '',
			fathersName: '',
			phone: '',
			nationalCode: '',
			description: '',
			liveStatus: -1,
			birthDate: '',
			isBirthDateImprecise: false,
			deathDate: '',
			isDeathDateImprecise: false,

			// ==> insert
			familyId: familyId,

			// ==> update
			id: id,

			// ==> get & update
			job: '',
			jobDescription: '',
			jobAddress: '',
			jobPhone: '',
			age: 0,
		},
	});

	useEffect(() => {
		if (id > 0) {
			formSet((old) => ({ ...old, loading: true }));
			axios
				.get('ValiNematan/MemberSingle', { params: { id } })
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, items: data.data, loading: false }));
				})
				.catch(console.error)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
		console.log(form);
	}, []);

	const submit = () => {
		if (id > 0) {
		} else {
		}
	};
	const remove = () => {};

	const formCmp = (
		<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} عضو`} onSubmit={submit} loading={form.loading}>
			<InputText id='id' label='کد' readOnly value={id} />
		</MyForm>
	);

	if (id == 0) {
		return formCmp;
	}
	return (
		<MyAccordion headers={['فرم', 'نیازها', 'بیماری‌های خاص', 'حذف']} defaultOpenIndex={id == 0 ? 0 : -1}>
			{formCmp}
			<MemeberNeeds familyId={familyId} id={id} />
			<MemeberSpecialDiseases familyId={familyId} id={id} />
			<>
				<Alert color='warning' className='text-center'>
					توجه داشته باشید که عملیات حذف، برگشت‌پذیر نیست و تنها زمانی امکان حذف وجود دارد که اطلاعات
					وابسطه‌ای وجود نداشته باشد.
				</Alert>
				<Alert color='info' className='text-center'>
					پیشنهاد می‌شود جهت حفظ تاریخچه و استخراج آمارهای صحیح از عملکرد، حتی پس از اتمام خدمات‌دهی،
					خانواده‌ها و یا اعضای آن‌ها را حذف نکنید.
				</Alert>
				<Button color='danger' onClick={remove}>
					حذف
				</Button>
			</>
		</MyAccordion>
	);
};

export default FamilyMemberForm;
