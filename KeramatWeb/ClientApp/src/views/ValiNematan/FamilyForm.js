import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import InputText from '../../components/form/InputText';
import MyForm from '../../components/form/MyForm';
import { useSelector } from 'react-redux';
import InputSelect from '../../components/form/InputSelect';
import axios from 'axios';
import InputSwitch from '../../components/form/InputSwitch';
import MyAccordion from '../../components/ui/MyAccordion';
import FamilyNeeds from './components/FamilyNeeds';
import FamilyMembers from './components/FamilyMembers';
import { Alert, Button } from 'reactstrap';
import FamilyRecivedServices from './components/FamilyRecivedServices';

const FamilyForm = () => {
	const navigate = useNavigate();
	const { id } = useParams();
	const { familyLevels, connectors } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			title: '',
			address: '',
			levelId: 1,
			description: '',
			contactPersonName: '',
			contactPersonPhone: '',
			contactPersonDescription: '',
			connectorId: 1,
			finished: false,
		},
	});

	useEffect(() => {
		if (id > 0) {
			formSet((old) => ({ ...old, loading: true }));
			axios
				.get('ValiNematan/Single', { params: { id } })
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, items: data.data, loading: false }));
				})
				.catch(console.error)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, [id]);

	const submit = () => {
		console.log('submit');

		const dto = {
			...form.items,
			levelId: +form.items.levelId > 0 ? form.items.levelId : null,
			connectorId: +form.items.connectorId > 0 ? form.items.connectorId : null,
		};

		if (id == 0) {
			axios
				.post('ValiNematan/Add', dto)
				.then((response) => response.data)
				.then((data) => {
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(console.error);
		} else {
			axios
				.put('ValiNematan/Edit', { id, ...dto })
				.then((response) => response.data)
				.then((data) => {
					navigate(`./../`, { relative: true });
				})
				.catch(console.error);
		}
	};

	const remove = () => {
		axios
			.delete('ValiNematan/Remove', { params: { id } })
			.then((x) => x.data.data)
			.then((x) => {
				if (x) {
					navigate(`./../`, { relative: true });
				}
			})
			.catch((e) => console.error);
	};

	const formCmp = (
		<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} خانواده`} onSubmit={submit} loading={form.loading}>
			<InputText id='id' label='کد' readOnly value={id} />
			{id > 0 ? (
				<InputSwitch
					id='finished'
					label='مختومه'
					description='به معنای پایان تحت پوشش بودن'
					check={form.items.finished}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, finished: val } }))}
				/>
			) : null}
			<InputText
				id='title'
				label='عنوان'
				value={form.items.title}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, title: val } }))}
			/>
			<InputText
				id='address'
				label='آدرس'
				value={form.items.address}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, address: val } }))}
			/>
			<InputSelect
				id='levelId'
				label='سطح'
				value={'' + form.items.levelId}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, levelId: Number(val) } }))}
				items={familyLevels.map((x) => ({ id: x.id, text: `${x.title} [${x.level}]` }))}
			/>
			<InputText
				multiLine
				id='description'
				label='ملاحظات'
				value={form.items.description}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
			/>
			<InputText
				id='contactPersonName'
				label='نام'
				description='رابط خانواده'
				value={form.items.contactPersonName}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, contactPersonName: val } }))}
			/>
			<InputText
				id='contactPersonPhone'
				label='تلفن'
				description='رابط خانواده'
				value={form.items.contactPersonPhone}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, contactPersonPhone: val } }))}
			/>
			<InputText
				multiLine
				id='contactPersonDescription'
				label='ملاحظات'
				description='رابط خانواده'
				value={form.items.contactPersonDescription}
				onChange={(val) =>
					formSet((old) => ({ ...old, items: { ...old.items, contactPersonDescription: val } }))
				}
			/>
			<InputSelect
				id='connectorId'
				label='معرف'
				value={'' + form.items.connectorId}
				onChange={(val) =>
					formSet((old) => ({ ...old, items: { ...old.items, connectorId: val ? Number(val) : 0 } }))
				}
				items={connectors.map((x) => ({ id: x.id, text: `${x.name}` }))}
			/>
		</MyForm>
	);
	if (id == 0) {
		return formCmp;
	}

	return (
		<MyAccordion
			headers={['فرم', 'اعضا', 'نیازها', 'خدمات ارائه‌شده', 'حذف']}
			defaultOpenIndex={id == 0 ? 0 : -1}>
			{formCmp}
			<FamilyNeeds familyId={id} />
			<FamilyMembers familyId={id} />
			<FamilyRecivedServices familyId={id} />
			<>
				<Alert color='warning' className='text-center'>
					توجه داشته باشید که عملیات حذف، برگشت‌پذیر نیست و تنها زمانی امکان حذف وجود دارد که اطلاعات
					وابسطه‌ای وجود نداشته باشد.
				</Alert>
				<Alert color='info' className='text-center'>
					پیشنهاد می‌شود جهت حفظ تاریخچه هر خانواده و استخراج آمارهای صحیح از عملکرد، حتی پس از اتمام
					خدمات‌دهی، خانواده‌ها را حذف نکنید.
				</Alert>
				<Button color='danger' onClick={remove}>
					حذف
				</Button>
			</>
		</MyAccordion>
	);
};

export default FamilyForm;
