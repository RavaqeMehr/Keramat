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
import { apiError } from './../../helpers/NotifHelper';

const FamailiLevelForm = () => {
	const navigate = useNavigate();
	const dispatch = useDispatch();
	const { id } = useParams();
	const { familyLevels } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			title: '',
			level: '0',
			description: '',
		},
	});

	useEffect(() => {
		if (id > 0) {
			const thisItem = familyLevels.find((x) => x.id == id);
			formSet((old) => ({
				...old,
				loading: false,
				items: { title: thisItem?.title, description: thisItem?.description, level: thisItem?.level },
			}));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, [id]);

	useEffect(() => {
		if (id > 0) {
			const thisItem = familyLevels.find((x) => x.id == id);
			formSet((old) => ({
				...old,
				loading: false,
				items: { title: thisItem?.title, description: thisItem?.description, level: thisItem?.level },
			}));
		}
	}, [familyLevels]);

	const submit = () => {
		const dto = {
			...form.items,
		};

		if (id == 0) {
			axios
				.post('ValiNematan/AddFamilyLevel', dto)
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateFamilyLevels());
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(apiError);
		} else {
			axios
				.put('ValiNematan/EditFamilyLevel', { id, ...dto })
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateFamilyLevels());
					navigate(`./../`, { relative: true });
				})
				.catch(apiError);
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
			.get('ValiNematan/FamilyLevelUsesList', { params: { id, page } })
			.then((x) => x.data.data)
			.then((x) => {
				const { items, ...pagination } = x;
				tblSet((old) => ({ ...old, loading: false, data: items, pagination: pagination }));
			})
			.catch(apiError)
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		GetPage(1);
	}, [id]);

	const remove = () => {
		axios
			.delete('ValiNematan/RemoveFamilyLevel', { params: { id } })
			.then((x) => x.data.data)
			.then(async (x) => {
				if (x) {
					dispatch(await ReduxActions.logicActions.updateFamilyLevels());
					navigate(`./../`, { relative: true });
				}
			})
			.catch(apiError);
	};

	return (
		<>
			<MyAccordion headers={['فرم', 'لیست وابسطه', 'حذف']}>
				<MyForm
					title={`${id == 0 ? 'افزودن' : 'ویرایش'} سطح خانواده`}
					onSubmit={submit}
					loading={form.loading}>
					<InputText id='id' label='کد' readOnly value={id} />
					<InputText
						id='title'
						label='عنوان'
						value={form.items.title}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, title: val } }))}
					/>
					<InputText
						id='level'
						label='سطح'
						value={form.items.level}
						onChange={(val) =>
							formSet((old) => ({ ...old, items: { ...old.items, level: '' + normalizeNumberInt(val) } }))
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

export default FamailiLevelForm;
