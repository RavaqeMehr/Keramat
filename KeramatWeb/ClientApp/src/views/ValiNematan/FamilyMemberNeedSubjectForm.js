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
import MemberUsesTable from './components/MemberUsesTable';

const FamilyMemberNeedSubjectForm = () => {
	const navigate = useNavigate();
	const dispatch = useDispatch();
	const { id } = useParams();
	const { familyMemberNeedSubjects } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			title: '',
			description: '',
		},
	});

	useEffect(() => {
		if (id > 0) {
			const thisItem = familyMemberNeedSubjects.find((x) => x.id == id);
			formSet((old) => ({
				...old,
				loading: false,
				items: { title: thisItem.title, description: thisItem.description },
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
				.post('ValiNematan/AddFamilyMemberNeedSubject', dto)
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateFamilyMemberNeedSubjects());
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(console.error);
		} else {
			axios
				.put('ValiNematan/EditFamilyMemberNeedSubject', { id, ...dto })
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateFamilyMemberNeedSubjects());
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
			.get('ValiNematan/FamilyMemberNeedSubjectUsesList', { params: { id, page } })
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

	const remove = () => {
		axios
			.delete('ValiNematan/RemoveFamilyMemberNeedSubject', { params: { id } })
			.then((x) => x.data.data)
			.then(async (x) => {
				if (x) {
					dispatch(await ReduxActions.logicActions.updateFamilyMemberNeedSubjects());
					navigate(`./../`, { relative: true });
				}
			})
			.catch((e) => console.error);
	};

	return (
		<>
			<MyAccordion headers={['فرم', 'لیست وابسطه', 'حذف']}>
				<MyForm
					title={`${id == 0 ? 'افزودن' : 'ویرایش'} نیاز اعضای خانواده`}
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
						multiLine
						id='description'
						label='ملاحظات'
						value={form.items.description}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
					/>
				</MyForm>
				{id == '0' ? null : (
					<MemberUsesTable
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

export default FamilyMemberNeedSubjectForm;
