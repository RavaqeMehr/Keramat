import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { useNavigate, useParams } from 'react-router-dom';
import { Alert, Button } from 'reactstrap';
import MyForm from '../../components/form/MyForm';
import MyAccordion from '../../components/ui/MyAccordion';
import RecivedsList from './RecivedsList';
import InputText from './../../components/form/InputText';
import { normalizeNumberInt, NumberWithCommas } from './../../helpers/Utils';
import { apiError } from './../../helpers/NotifHelper';

const RecivedsForm = () => {
	const navigate = useNavigate();
	const { nikooKarId, id } = useParams();

	const [form, formSet] = useState({
		loading: true,
		items: {
			cashValue: 0,
			cashDescription: '',
			notCashValue: 0,
			notCashDescription: '',
		},
		hints: {
			cash: null,
			notCash: null,
		},
	});

	useEffect(() => {
		if (id > 0) {
			formSet((old) => ({ ...old, loading: true }));
			axios
				.get('Kheyrat/Kheyr', { params: { id } })
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, items: data.data, loading: false }));
				})
				.catch(apiError)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, [nikooKarId, id]);

	const submit = () => {
		if (id == 0) {
			axios
				.post('Kheyrat/AddKheyr', { nikooKarId, ...form.items })
				.then((response) => response.data)
				.then((data) => {
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(apiError);
		} else {
			axios
				.put('Kheyrat/EditKheyr', { id, ...form.items })
				.then((response) => response.data)
				.then((data) => {
					navigate(`./..`, { relative: true });
				})
				.catch(apiError);
		}
	};

	const remove = () => {
		axios
			.delete('Kheyrat/RemoveKheyr', { params: { id } })
			.then((x) => x.data.data)
			.then((x) => {
				if (x) {
					navigate(`./..`, { relative: true });
				}
			})
			.catch(apiError);
	};

	const formCmp = (
		<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} نیکوکار`} onSubmit={submit} loading={form.loading}>
			<InputText id='id' label='کد' readOnly value={id} />

			<InputText
				id='cashValue'
				label='مبلغ کمک نقدی'
				description='به ریال'
				value={'' + form.items.cashValue}
				hint={form.hints.cash}
				onChange={(val) => {
					const _val = Math.max(0, normalizeNumberInt(val));
					formSet((old) => ({
						...old,
						items: { ...old.items, cashValue: _val },
						hints: { ...old.hints, cash: _val > 0 ? `${NumberWithCommas(_val / 10)} تومان` : null },
					}));
				}}
			/>
			<InputText
				multiLine
				id='cashDescription'
				label='شرح کمک نقدی'
				value={form.items.cashDescription}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, cashDescription: val } }))}
			/>

			<InputText
				id='notCashValue'
				label='ارزش کمک غیر نقدی نقدی'
				description='به ریال'
				value={'' + form.items.notCashValue}
				hint={form.hints.notCash}
				onChange={(val) => {
					const _val = Math.max(0, normalizeNumberInt(val));
					formSet((old) => ({
						...old,
						items: { ...old.items, notCashValue: _val },
						hints: { ...old.hints, notCash: _val > 0 ? `${NumberWithCommas(_val / 10)} تومان` : null },
					}));
				}}
			/>
			<InputText
				multiLine
				id='notCashDescription'
				label='شرح کمک غیر نقدی'
				value={form.items.notCashDescription}
				onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, notCashDescription: val } }))}
			/>
		</MyForm>
	);
	if (id == 0) {
		return formCmp;
	}

	return (
		<>
			<div className='mb-3 d-grid'>
				<Button
					color='success'
					className='me-auto'
					size='sm'
					onClick={() => navigate(`./..`, { relative: true })}>
					برگشت به صفحه نیکوکار
				</Button>
			</div>
			<MyAccordion headers={['فرم', 'حذف']} defaultOpenIndex={0}>
				{formCmp}
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
		</>
	);
};

export default RecivedsForm;
