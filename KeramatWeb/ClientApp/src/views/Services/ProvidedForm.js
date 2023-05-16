import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { useNavigate, useParams } from 'react-router-dom';
import { Alert, Button } from 'reactstrap';
import InputSelect from '../../components/form/InputSelect';
import InputText from '../../components/form/InputText';
import MyForm from '../../components/form/MyForm';
import MyAccordion from '../../components/ui/MyAccordion';
import Recivers from './components/Recivers';

const ProvidedForm = () => {
	const navigate = useNavigate();
	const { id } = useParams();
	const { serviceSubjects } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			serviceSubjectId: null,
			description: '',
		},
	});

	useEffect(() => {
		if (id > 0) {
			formSet((old) => ({ ...old, loading: true }));
			axios
				.get('Services/ProvidedSingle', { params: { id } })
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
		if (id == 0) {
			axios
				.post('Services/AddProvided', form.items)
				.then((response) => response.data)
				.then((data) => {
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(console.error);
		} else {
			axios
				.put('Services/EditProvided', { id, ...form.items })
				.then((response) => response.data)
				.then((data) => {
					// navigate(`./../`, { relative: true });
				})
				.catch(console.error);
		}
	};

	const remove = () => {
		axios
			.delete('Services/RemoveProvided', { params: { id } })
			.then((x) => x.data.data)
			.then((x) => {
				if (x) {
					navigate(`./../`, { relative: true });
				}
			})
			.catch((e) => console.error);
	};

	const formCmp = (
		<MyForm
			title={`${id == 0 ? 'افزودن' : 'ویرایش'} خدمت ارائه‌شده`}
			onSubmit={submit}
			loading={form.loading}>
			<InputText id='id' label='کد' readOnly value={id} />
			<InputSelect
				id='serviceSubjectId'
				label='موضوع خدمت'
				value={'' + form.items.serviceSubjectId}
				onChange={(val) =>
					formSet((old) => ({ ...old, items: { ...old.items, serviceSubjectId: Number(val) } }))
				}
				items={serviceSubjects.map((x) => ({ id: x.id, text: x.title }))}
			/>
			<InputText
				multiLine
				id='description'
				label='ملاحظات'
				value={form.items.description}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
			/>
		</MyForm>
	);
	if (id == 0) {
		return formCmp;
	}

	return (
		<MyAccordion headers={['فرم', 'دریافت‌کنندگان', 'حذف']} defaultOpenIndex={id == 0 ? 0 : -1}>
			{formCmp}
			<Recivers providedId={id} />
			<>
				<Alert color='warning' className='text-center'>
					توجه داشته باشید که عملیات حذف، برگشت‌پذیر نیست و تنها زمانی امکان حذف وجود دارد که اطلاعات
					وابسطه‌ای وجود نداشته باشد.
				</Alert>
				<Alert color='info' className='text-center'>
					پیشنهاد می‌شود جهت حفظ تاریخچه و استخراج آمارهای صحیح از عملکرد،اطلاعات را حذف نکنید.
				</Alert>
				<Button color='danger' onClick={remove}>
					حذف
				</Button>
			</>
		</MyAccordion>
	);
};

export default ProvidedForm;
