import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate, useParams } from 'react-router-dom';
import { Alert, Button } from 'reactstrap';
import InputText from '../../components/form/InputText';
import MyForm from '../../components/form/MyForm';
import MyTable from '../../components/table/MyTable';
import MyAccordion from '../../components/ui/MyAccordion';
import { ReduxActions } from '../../store';
import { NumberWithCommas } from './../../helpers/Utils';
import MyDateTime from './../../components/dateTime/MyDateTime';

const SubjectForm = () => {
	const navigate = useNavigate();
	const dispatch = useDispatch();
	const { id } = useParams();
	const { serviceSubjects } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			title: '',
			description: '',
		},
	});

	useEffect(() => {
		if (id > 0) {
			const thisItem = serviceSubjects.find((x) => x.id == id);
			formSet((old) => ({
				...old,
				loading: false,
				items: { title: thisItem?.title, description: thisItem?.description },
			}));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, [id]);

	useEffect(() => {
		if (id > 0) {
			const thisItem = serviceSubjects.find((x) => x.id == id);
			formSet((old) => ({
				...old,
				loading: false,
				items: { title: thisItem?.title, description: thisItem?.description },
			}));
		}
	}, [serviceSubjects]);

	const submit = () => {
		if (id == 0) {
			axios
				.post('Services/AddSubject', form.items)
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateServiceSubjects());
					navigate(`./../${data.data}`, { replace: true, relative: true });
				})
				.catch(console.error);
		} else {
			axios
				.put('Services/EditSubject', { id, ...form.items })
				.then((response) => response.data)
				.then(async (data) => {
					dispatch(await ReduxActions.logicActions.updateServiceSubjects());
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
			.get('Services/SubjectsUsesList', { params: { id, page } })
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
			.delete('Services/RemoveSubject', { params: { id } })
			.then((x) => x.data.data)
			.then(async (x) => {
				if (x) {
					dispatch(await ReduxActions.logicActions.updateServiceSubjects());
					navigate(`./../`, { relative: true });
				}
			})
			.catch((e) => console.error);
	};

	const formCmp = (
		<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} موضوع خدمت`} onSubmit={submit} loading={form.loading}>
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
	);

	if (id == 0) {
		return formCmp;
	}

	return (
		<>
			<MyAccordion headers={['فرم', 'لیست وابسطه', 'حذف']}>
				{formCmp}
				<MyTable
					title='لیست وابسطه'
					cols={cols}
					rows={tbl.data}
					pagination={tbl.pagination}
					loading={tbl.loading}
					rowRenderer={(x) => (
						<>
							<th scope='row'>{x.id}</th>
							<td>{x.description}</td>
							<td>{NumberWithCommas(x.reciversCount)}</td>
							<td>
								<MyDateTime dateTime={x.date} />
							</td>
						</>
					)}
					onPageClick={GetPage}
					onRowClick={(x) => navigate(`./../../provided/${x.id}`, { relative: true })}
				/>
				<>
					<Alert color='warning' className='text-center'>
						توجه داشته باشید که عملیات حذف، برگشت‌پذیر نیست و تنها زمانی امکان حذف وجود دارد که اطلاعات
						وابسطه‌ای وجود نداشته باشد.
					</Alert>
					<Button color='danger' onClick={remove}>
						حذف
					</Button>
				</>
			</MyAccordion>
		</>
	);
};

export default SubjectForm;

const cols = ['کد', 'شرح', 'دریافت‌کنندگان', 'زمان'];
