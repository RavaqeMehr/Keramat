import React, { useEffect, useState } from 'react';
import MyTable from './../../../components/table/MyTable';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { Offcanvas, OffcanvasHeader, OffcanvasBody, Button, Row, Col } from 'reactstrap';
import InputText from './../../../components/form/InputText';
import { NumberWithCommas } from './../../../helpers/Utils';
import InputSearch from './../../../components/form/InputSearch';
import { apiError } from './../../../helpers/NotifHelper';

const Recivers = ({ providedId }) => {
	const navigate = useNavigate();

	const [tbl, tblSet] = useState({
		page: 1,
		loading: true,
		data: null,
		pagination: null,
		activeId: 0,
		activeDescription: '',
		activeFamilyId: 0,
	});

	const GetPage = (page) => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('Services/Recivers', { params: { page, id: providedId } })
			.then((x) => x.data.data)
			.then((x) => {
				const { items, ...pagination } = x;
				tblSet((old) => ({ ...old, loading: false, data: items, pagination: pagination }));
			})
			.catch(apiError)
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	const [families, familiesSet] = useState([]);

	useEffect(() => {
		GetFamiliesStatus();
		tblSet({
			page: 1,
			loading: true,
			data: null,
			pagination: null,
			activeId: 0,
			activeDescription: '',
			activeFamilyId: 0,
		});
		GetPage(1);
	}, [providedId]);

	const GetFamiliesStatus = () => {
		axios
			.get('Services/FamiliesStatus', { params: { id: providedId } })
			.then((x) => x.data.data)
			.then((x) => {
				familiesSet(x);
			})
			.catch((e) => {
				apiError(e);
				familiesSet([]);
			});
	};

	const addFamily = () => {
		formSet((old) => ({ ...old, loading: true }));
		axios
			.post('Services/AddReciver', { serviceProvidedId: providedId, ...form.items })
			.then((response) => response.data)
			.then((data) => {
				GetPage(1);
				let thisFamily = families.find((x) => x.id == form.items.familyId);
				thisFamily.serviced = true;
				familiesSet((old) => [thisFamily, ...families.filter((x) => x.id != form.items.familyId)]);
				formSet((old) => ({ loading: false, showForm: false, items: { ...old.items, familyId: -1 } }));
			})
			.catch(apiError)
			.finally(formSet((old) => ({ ...old, loading: false })));
	};

	const editFamily = (e) => {
		axios
			.put('Services/EditReciver', { id: tbl.activeId, description: tbl.activeDescription })
			.then((response) => response.data)
			.then((data) => {
				tblSet((old) => ({ ...old, activeId: -1, activeDescription: '' }));
				GetPage(tbl.page);
			})
			.catch(apiError);
	};

	const removeFamily = (e) => {
		axios
			.delete('Services/RemoveReciver', { params: { id: tbl.activeId } })
			.then((response) => response.data)
			.then((data) => {
				tblSet((old) => ({ ...old, activeId: -1, activeDescription: '' }));
				GetPage(tbl.page);
				let thisFamily = families.find((x) => x.id == tbl.activeFamilyId);
				thisFamily.serviced = false;
				familiesSet((old) => [thisFamily, ...families.filter((x) => x.id != tbl.activeFamilyId)]);
			})
			.catch(apiError);
	};

	const cancelEdit = (e) => {
		e.stopPropagation();
		tblSet((old) => ({ ...old, activeId: -1 }));
	};

	const [form, formSet] = useState({
		loading: true,
		items: {
			familyId: -1,
			description: '',
		},
		showForm: false,
		search: '',
	});

	return (
		<>
			<MyTable
				title='لیست دریافت‌کنندگان'
				cols={cols}
				rows={tbl.data}
				pagination={tbl.pagination}
				loading={tbl.loading}
				rowRenderer={(x) => rowRenderer(x, tbl, tblSet, editFamily, removeFamily, cancelEdit)}
				onPageClick={(x) => GetPage(x)}
				onRowClick={(x) =>
					tblSet((old) => ({
						...old,
						activeId: x.id,
						activeDescription: x.description,
						activeFamilyId: x.familyId,
					}))
				}
			/>
			<Button color='success' onClick={(x) => formSet((old) => ({ ...old, showForm: !old.showForm }))}>
				افزودن
			</Button>

			<Offcanvas
				direction='bottom'
				style={{ height: '75vh' }}
				fade={false}
				isOpen={form.showForm}
				toggle={() => formSet((old) => ({ ...old, showForm: !old.showForm }))}>
				<OffcanvasHeader toggle={() => formSet((old) => ({ ...old, showForm: !old.showForm }))}>
					افزودن دریافت‌کننده
					<Button color='success' className='mx-3' disabled={form.items.familyId < 0} onClick={addFamily}>
						ثبت
					</Button>
				</OffcanvasHeader>
				<OffcanvasBody>
					<InputText
						multiLine
						id='description'
						label='ملاحظات'
						description='فقط در صورت نیاز به توضیخ، این قسمت را پر کنید'
						value={form.items.description}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
					/>

					<MyTable
						title='لیست خانواده‌های دریافت‌نکرده'
						cols={cols2}
						rows={families.filter((x) => !x.serviced).filter((x) => x.title.indexOf(form.search) > -1)}
						rowRenderer={(x) => rowRenderer2(x, form.items.familyId)}
						onRowClick={(x) => formSet((old) => ({ ...old, items: { ...old.items, familyId: x.id } }))}
						search={
							<InputSearch
								label='جستجو'
								value={form.search}
								onChange={(val) => formSet((old) => ({ ...old, search: val }))}
							/>
						}
					/>
				</OffcanvasBody>
			</Offcanvas>
		</>
	);
};

export default Recivers;

const cols = ['کد', 'عنوان', 'ملاحظات'];

const rowRenderer = (x, tbl, tblSet, editFamily, removeFamily, cancelEdit) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>{x.familyTitle}</td>
		<td>
			{tbl.activeId != x.id ? (
				x.description
			) : (
				<>
					<InputText
						multiLine
						id='description'
						value={tbl.activeDescription}
						onChange={(val) => tblSet((old) => ({ ...old, activeDescription: val }))}
					/>

					<Button color='success' size='sm' className='mx-1' onClick={editFamily}>
						ثبت
					</Button>
					<Button color='danger' size='sm' className='mx-1' onClick={removeFamily}>
						حذف
					</Button>
					<Button color='secondary' size='sm' className='mx-1' onClick={cancelEdit}>
						انصراف
					</Button>
				</>
			)}
		</td>
	</>
);

const cols2 = ['کد', 'عنوان', 'اعضاء'];

const rowRenderer2 = (x, familyId) => (
	<>
		<th className={familyId == x.id ? 'bg-warning' : undefined} scope='row'>
			{x.id}
		</th>
		<td className={familyId == x.id ? 'bg-warning' : undefined}>{x.title}</td>
		<td className={familyId == x.id ? 'bg-warning' : undefined}>{NumberWithCommas(x.membersCount)}</td>
	</>
);
