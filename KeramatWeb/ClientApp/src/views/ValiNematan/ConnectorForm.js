import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import MyForm from '../../components/form/MyForm';
import InputText from '../../components/form/InputText';
import { normalizeNumberInt } from '../../helpers/Utils';
import { ReduxActions } from '../../store';
import axios from 'axios';
import MyTable from '../../components/table/MyTable';
import MyAccordion from '../../components/ui/MyAccordion';
import { Button, Alert } from 'reactstrap';
import FamilyUsesTable from './components/FamilyUsesTable';

const ConnectorForm = () => {
	const navigate = useNavigate();
	const dispatch = useDispatch();
	const { id } = useParams();
	const { connectors } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			name: '',
			phone: '0',
			description: '',
		},
	});

	useEffect(() => {
		if (id > 0) {
			const thisItem = connectors.find((x) => x.id == id);
			formSet((old) => ({
				...old,
				loading: false,
				items: { name: thisItem?.name, description: thisItem?.description, phone: thisItem?.phone },
			}));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, [id]);

	useEffect(() => {
		if (id > 0) {
			const thisItem = connectors.find((x) => x.id == id);
			formSet((old) => ({
				...old,
				loading: false,
				items: { name: thisItem?.name, description: thisItem?.description, phone: thisItem?.phone },
			}));
		}
	}, [connectors]);

	const submit = () => {
		const dto = {
			...form.items,
		};

		if (id == 0) {
			axios
				.post('ValiNematan/AddConnector', dto)
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateConnectors());
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(console.error);
		} else {
			axios
				.put('ValiNematan/EditConnector', { id, ...dto })
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateConnectors());
					navigate(`./../`, { relative: true });
				})
				.catch(console.error);
		}
	};

	const [tbl, tblSet] = useState({
		search: '',
		page: 1,
		loading: true,
		data: null,
		pagination: null,
	});

	const GetPage = (page) => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('ValiNematan/ConnectorUsesList', { params: { id, page } })
			.then((x) => x.data.data)
			.then((x) => {
				const { items, ...pagination } = x;
				tblSet((old) => ({ ...old, loading: false, data: items, pagination: pagination }));
			})
			.catch((e) => {})
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		GetPage(1);
	}, [id]);

	const remove = () => {
		axios
			.delete('ValiNematan/RemoveConnector', { params: { id } })
			.then((x) => x.data.data)
			.then(async (x) => {
				if (x) {
					dispatch(await ReduxActions.logicActions.updateConnectors());
					navigate(`./../`, { relative: true });
				}
			})
			.catch((e) => console.error);
	};

	return (
		<>
			<MyAccordion headers={['فرم', 'لیست وابسطه', 'حذف']}>
				<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} رابط`} onSubmit={submit} loading={form.loading}>
					<InputText id='id' label='کد' readOnly value={id} />
					<InputText
						id='name'
						label='نام'
						value={form.items.name}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, name: val } }))}
					/>
					<InputText
						id='phone'
						label='تلفن'
						value={form.items.phone}
						onChange={(val) =>
							formSet((old) => ({ ...old, items: { ...old.items, phone: '' + normalizeNumberInt(val) } }))
						}
					/>

					<InputText
						multiLine
						id='description'
						label='ملاحظات'
						value={form.items.description}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
					/>
				</MyForm>
				{id == '0' ? null : (
					<FamilyUsesTable
						navigate={navigate}
						GetPage={GetPage}
						data={tbl.data}
						pagination={tbl.pagination}
						loading={tbl.loading}
					/>
				)}
				{id == '0' ? null : (
					<>
						<Alert color='warning' className='text-center'>
							توجه داشته باشید که عملیات حذف، برگشت‌پذیر نیست و تنها زمانی امکان حذف وجود دارد که اطلاعات
							وابسطه‌ای وجود نداشته باشد.
						</Alert>
						<Button color='danger' onClick={remove}>
							حذف
						</Button>
					</>
				)}
			</MyAccordion>
		</>
	);
};

export default ConnectorForm;
