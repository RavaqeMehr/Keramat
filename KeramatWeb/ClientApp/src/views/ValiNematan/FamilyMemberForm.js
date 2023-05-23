import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { useNavigate, useParams } from 'react-router-dom';
import { Alert, Button } from 'reactstrap';
import MyAccordion from '../../components/ui/MyAccordion';
import * as enums from '../../enums';
import InputSelect from './../../components/form/InputSelect';
import InputSwitch from './../../components/form/InputSwitch';
import InputText from './../../components/form/InputText';
import MyForm from './../../components/form/MyForm';
import { apiError } from './../../helpers/NotifHelper';
import MemeberNeeds from './components/MemeberNeeds';
import MemeberSpecialDiseases from './components/MemeberSpecialDiseases';

const FamilyMemberForm = () => {
	const navigate = useNavigate();
	const { id, familyId } = useParams();
	const { familyMemberRelations } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			// ==> all
			familyMemberRelationId: null,
			gender: -1,
			name: '',
			lastName: '',
			fathersName: '',
			nationalCode: '',
			phone: '',
			maritalStatus: -1,
			birthDateStr: '',
			isBirthDateImprecise: false,
			liveStatus: -1,
			deathDateStr: '',
			isDeathDateImprecise: false,
			description: '',

			// ==> get
			age: 0,

			// ==> insert
			familyId: familyId,

			// ==> update
			id: id,

			// ==> get & update
			job: '',
			jobPhone: '',
			jobAddress: '',
			jobDescription: '',
		},
	});

	useEffect(() => {
		formSet((old) => ({
			...old,
			items: {
				...old.items,
				familyMemberRelationId:
					old.items.familyMemberRelationId == null && familyMemberRelations.length > 0
						? familyMemberRelations[0].id
						: old.items.familyMemberRelationId ?? null,
				gender: old.items.gender ?? enums._Gender[0].val,
				maritalStatus: old.items.maritalStatus ?? enums._MaritalStatus[0].val,
				liveStatus: old.items.liveStatus ?? enums._LiveStatus[0].val,
			},
		}));
	}, [familyMemberRelations]);

	useEffect(() => {
		if (id > 0) {
			formSet((old) => ({ ...old, loading: true }));
			axios
				.get('ValiNematan/MemberSingle', { params: { id } })
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, items: { ...old.items, ...data.data }, loading: false }));
				})
				.catch(apiError)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, [id, familyId]);

	useEffect(() => {
		formSet((old) => ({ ...old, items: { ...old.items, id: Number(id), familyId: Number(familyId) } }));
	}, [id, familyId]);

	const submit = () => {
		if (id == 0) {
			axios
				.post('ValiNematan/AddMember', form.items)
				.then((response) => response.data)
				.then((data) => {
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(apiError);
		} else {
			axios
				.put('ValiNematan/EditMember', form.items)
				.then((response) => response.data)
				.then((data) => {
					navigate(`./../`, { relative: true });
				})
				.catch(apiError);
		}
	};

	const remove = () => {
		axios
			.delete('ValiNematan/RemoveMember', { params: { id } })
			.then((x) => x.data.data)
			.then((x) => {
				if (x) {
					navigate(`./../`, { relative: true });
				}
			})
			.catch(apiError);
	};

	const [deathDateInputMode, deathDateInputModeSet] = useState({ mode: -1, text: '' });
	useEffect(() => {
		const notLives = ['Dead', 'Martyr'];
		const __x = enums._LiveStatus
			.filter((a) => notLives.some((b) => b == a.key))
			.map((x) => x.val)
			.indexOf(form.items.liveStatus);

		deathDateInputModeSet({ mode: __x, text: __x == 0 ? 'وفات' : 'شهادت' });
	}, [form]);

	const formCmp = (
		<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} عضو`} onSubmit={submit} loading={form.loading}>
			<InputText id='id' label='کد' readOnly value={id} />
			<InputSelect
				id='familyMemberRelationId'
				label='نسبت'
				value={'' + form.items.familyMemberRelationId}
				onChange={(val) =>
					formSet((old) => ({ ...old, items: { ...old.items, familyMemberRelationId: Number(val) } }))
				}
				items={familyMemberRelations.map((x) => ({ id: x.id, text: x.title }))}
			/>
			<InputSelect
				id='gender'
				label='جنسیت'
				value={'' + form.items.gender}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, gender: Number(val) } }))}
				items={enums._Gender.map((x) => ({ id: x.val, text: x.text }))}
			/>
			<InputText
				id='name'
				label='نام'
				value={form.items.name}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, name: val } }))}
			/>
			<InputText
				id='lastName'
				label='نام خانوادگی'
				value={form.items.lastName}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, lastName: val } }))}
			/>
			<InputText
				id='fathersName'
				label='نام پدر'
				value={form.items.fathersName}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, fathersName: val } }))}
			/>
			<InputText
				id='nationalCode'
				label='کد ملی'
				value={form.items.nationalCode}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, nationalCode: val } }))}
			/>
			<InputText
				id='phone'
				label='تلفن'
				value={form.items.phone}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, phone: val } }))}
			/>
			<InputSelect
				id='maritalStatus'
				label='وضعیت تاهل'
				value={'' + form.items.maritalStatus}
				onChange={(val) =>
					formSet((old) => ({ ...old, items: { ...old.items, maritalStatus: Number(val) } }))
				}
				items={enums._MaritalStatus.map((x) => ({ id: x.val, text: x.text }))}
			/>
			<InputText
				id='birthDateStr'
				label='تاریخ تولد'
				hint={
					form.items.isBirthDateImprecise
						? 'یا فقط سال شمسی و یا به صورت کامل وارد شود.'
						: 'به صورت کامل : 1402/03/15'
				}
				maxLength={10}
				value={form.items.birthDateStr}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, birthDateStr: val } }))}
			/>
			<InputSwitch
				id='isBirthDateImprecise'
				label='آیا تاریخ تولد حدودی وارد شده؟'
				hint='تعیین دقیق یا حدودی بودت تاریخ تولد'
				check={form.items.isBirthDateImprecise}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, isBirthDateImprecise: val } }))}
			/>
			<InputSelect
				id='liveStatus'
				label='وضعیت حیات'
				value={'' + form.items.liveStatus}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, liveStatus: Number(val) } }))}
				items={enums._LiveStatus.map((x) => ({ id: x.val, text: x.text }))}
			/>
			{deathDateInputMode.mode >= 0 ? (
				<>
					<InputText
						id='deathDateStr'
						label={`تاریخ ${deathDateInputMode.text}`}
						hint={
							form.items.isDeathDateImprecise
								? 'یا فقط سال شمسی و یا به صورت کامل وارد شود.'
								: 'به صورت کامل : 1402/03/15'
						}
						maxLength={10}
						value={form.items.deathDateStr}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, deathDateStr: val } }))}
					/>
					<InputSwitch
						id='isDeathDateImprecise'
						label={`آیا تاریخ ${deathDateInputMode.text} حدودی وارد شده؟`}
						hint={`تعیین دقیق یا حدودی بودت تاریخ ${deathDateInputMode.text}`}
						check={form.items.isDeathDateImprecise}
						onChange={(val) =>
							formSet((old) => ({ ...old, items: { ...old.items, isDeathDateImprecise: val } }))
						}
					/>
				</>
			) : null}

			<InputText
				multiLine
				id='description'
				label='ملاحظات'
				value={form.items.description}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
			/>

			{id == 0 ? null : (
				<>
					<InputText
						id='job'
						label='شغل'
						value={form.items.job}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, job: val } }))}
					/>
					<InputText
						id='jobPhone'
						label='تلفن محل کار'
						value={form.items.jobPhone}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, jobPhone: val } }))}
					/>
					<InputText
						id='jobAddress'
						label='آدرس محل کار'
						value={form.items.jobAddress}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, jobAddress: val } }))}
					/>
					<InputText
						multiLine
						id='jobDescription'
						label='ملاحظات شغل'
						value={form.items.jobDescription}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, jobDescription: val } }))}
					/>
				</>
			)}
		</MyForm>
	);

	if (id == 0) {
		return formCmp;
	}
	return (
		<MyAccordion headers={['فرم', 'نیازها', 'بیماری‌های خاص', 'حذف']} defaultOpenIndex={id == 0 ? 0 : -1}>
			{formCmp}
			<MemeberNeeds familyId={familyId} familyMemberId={id} />
			<MemeberSpecialDiseases familyId={familyId} familyMemberId={id} />
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
