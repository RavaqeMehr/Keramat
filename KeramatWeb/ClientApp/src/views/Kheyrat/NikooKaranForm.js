import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { useNavigate, useParams } from 'react-router-dom';
import { Alert, Button } from 'reactstrap';
import InputText from '../../components/form/InputText';
import MyForm from '../../components/form/MyForm';
import MyAccordion from '../../components/ui/MyAccordion';
import RecivedsList from './RecivedsList';
import { apiError } from './../../helpers/NotifHelper';

const NikooKaranForm = () => {
	const navigate = useNavigate();
	const { id } = useParams();
	const { familyLevels, connectors } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			fullName: '',
			phone: '',
			address: '',
			description: '',
			job: '',
			jobDescription: '',
			jobAddress: '',
			jobPhone: '',
		},
	});

	useEffect(() => {
		if (id > 0) {
			formSet((old) => ({ ...old, loading: true }));
			axios
				.get('Kheyrat/NikooKar', { params: { id } })
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, items: data.data, loading: false }));
				})
				.catch(apiError)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, [id]);

	const submit = () => {
		if (id == 0) {
			axios
				.post('Kheyrat/AddNikooKar', form.items)
				.then((response) => response.data)
				.then((data) => {
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(apiError);
		} else {
			axios
				.put('Kheyrat/EditNikooKar', { id, ...form.items })
				.then((response) => response.data)
				.then((data) => {
					navigate(`./../`, { relative: true });
				})
				.catch(apiError);
		}
	};

	const remove = () => {
		axios
			.delete('Kheyrat/RemoveNikooKar', { params: { id } })
			.then((x) => x.data.data)
			.then((x) => {
				if (x) {
					navigate(`./../`, { relative: true });
				}
			})
			.catch(apiError);
	};

	const formCmp = (
		<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} نیکوکار`} onSubmit={submit} loading={form.loading}>
			<InputText id='id' label='کد' readOnly value={id} />
			<InputText
				id='fullName'
				label='نام کامل'
				value={form.items.fullName}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, fullName: val } }))}
			/>
			<InputText
				id='phone'
				label='تلفن'
				value={form.items.phone}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, phone: val } }))}
			/>
			<InputText
				id='address'
				label='آدرس'
				value={form.items.address}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, address: val } }))}
			/>
			<InputText
				multiLine
				id='description'
				label='ملاحظات'
				value={form.items.description}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
			/>
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
		</MyForm>
	);
	if (id == 0) {
		return formCmp;
	}

	return (
		<MyAccordion headers={['فرم', 'کمک‌های اهدایی', 'حذف']} defaultOpenIndex={id == 0 ? 0 : -1}>
			{formCmp}
			<RecivedsList nikooKarId={id} />
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

export default NikooKaranForm;
