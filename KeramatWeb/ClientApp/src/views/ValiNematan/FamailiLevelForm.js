import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import MyForm from '../../components/form/MyForm';
import InputText from '../../components/form/InputText';
import { normalizeNumberInt } from '../../helpers/Utils';
import { ReduxActions } from '../../store';
import axios from 'axios';
import MyTable from '../../components/table/MyTable';

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
				items: { title: thisItem.title, description: thisItem.description, level: thisItem.level },
			}));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, []);

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
				.catch(console.error);
		} else {
			axios
				.put('ValiNematan/EditFamilyLevel', { id, ...dto })
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateFamilyLevels());
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
			.get('ValiNematan/FamilyLevelUsesList', { params: { id, page } })
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
	}, []);

	return (
		<>
			<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} سطح خانواده`} onSubmit={submit} loading={form.loading}>
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

			<MyTable
				title='لیست خانواده‌های این سطح'
				cols={cols}
				rows={tbl.data}
				pagination={tbl.pagination}
				loading={tbl.loading}
				rowRenderer={rowRenderer}
				onPageClick={(x) => GetPage(x)}
				onRowClick={(x) => navigate(`./../../families/${x.id}`, { relative: true })}
			/>
		</>
	);
};

export default FamailiLevelForm;

const cols = ['کد', 'عنوان', 'درج'];

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>{x.title}</td>
		<td>{x.addDate}</td>
	</>
);
