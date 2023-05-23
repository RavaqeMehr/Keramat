import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { Button } from 'reactstrap';
import InputSelect from '../../../components/form/InputSelect';
import InputText from '../../../components/form/InputText';
import MyForm from '../../../components/form/MyForm';
import MyTableSortable from '../../../components/table/MyTableSortable';
import { apiError } from './../../../helpers/NotifHelper';

const MemeberNeeds = ({ familyId, familyMemberId }) => {
	const { familyMemberNeedSubjects } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		show: false,
		insert: true,
		loading: false,
		items: {
			id: 0,
			familyMemberNeedSubjectId: null,
			description: '',
		},
	});

	useEffect(() => {
		formSet((old) => ({
			...old,
			items: {
				...old.items,
				familyMemberNeedSubjectId:
					old.items.familyMemberNeedSubjectId == null && familyMemberNeedSubjects.length > 0
						? familyMemberNeedSubjects[0].id
						: old.items.familyMemberNeedSubjectId ?? null,
			},
		}));
	}, [familyMemberNeedSubjects]);

	const toggleForm = () => {
		if (remainingNeeds.length > 0) {
			formSet((old) => ({
				...old,
				show: !old.show,
				insert: true,
				loading: false,
				items: { id: 0, familyMemberNeedSubjectId: remainingNeeds[0].id, description: '' },
			}));
		}
	};

	const rowClick = (x) => {
		formSet((old) => ({
			...old,
			show: true,
			insert: false,
			loading: false,
			items: {
				id: x.id,
				familyMemberNeedSubjectId: x.familyMemberNeedSubjectId,
				description: x.description,
			},
		}));
	};

	const formSubmit = () => {
		formSet((old) => ({ ...old, loading: true }));

		if (form.insert) {
			const dto = {
				familyMemberId: familyMemberId,
				description: form.items.description,
				familyMemberNeedSubjectId:
					+form.items.familyMemberNeedSubjectId > 0 ? form.items.familyMemberNeedSubjectId : null,
			};

			axios
				.post('ValiNematan/AddFamilyMemberNeed', dto)
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, show: false }));
					loadTable();
				})
				.catch(apiError)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		} else {
			const dto = {
				id: form.items.id,
				description: form.items.description,
			};

			axios
				.put('ValiNematan/EditFamilyMemberNeed', dto)
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, show: false }));
					loadTable();
				})
				.catch(apiError)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		}
	};

	const remove = () => {
		axios
			.delete('ValiNematan/RemoveFamilyMemberNeed', { params: { id: form.items.id } })
			.then((response) => response.data)
			.then((data) => {
				formSet((old) => ({ ...old, show: false }));
				loadTable();
			})
			.catch(apiError)
			.finally(() => formSet((old) => ({ ...old, loading: false })));
	};

	const saveReOrder = () => {
		const sortedIds = tbl.data.map((x) => x.id);
		axios
			.put('ValiNematan/ReOrderFamilyMemberNeeds', { sortedIds })
			.then((response) => response.data)
			.then((data) => {
				loadTable();
			})
			.catch(apiError);
	};

	const [tbl, tblSet] = useState({
		loading: true,
		data: null,
		beforeSort: null,
		needSaveReOrder: false,
	});

	const onSortEnd = (sortedData) => {
		var o = tbl.beforeSort.reduce((a, b) => `${a},${b.id}`, '');
		var n = sortedData.reduce((a, b) => `${a},${b.id}`, '');

		tblSet((old) => ({ ...old, data: sortedData, needSaveReOrder: o != n }));
	};

	const loadTable = () => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('ValiNematan/FamilyMemberNeeds', { params: { familyMemberId } })
			.then((x) => x.data.data)
			.then((x) => {
				tblSet((old) => ({ ...old, loading: false, data: x, beforeSort: x, needSaveReOrder: false }));
			})
			.catch(apiError)
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		loadTable();
	}, []);

	const remainingNeeds = familyMemberNeedSubjects.filter((x) =>
		tbl.data ? tbl.data.findIndex((t) => t.familyMemberNeedSubjectId == x.id) == -1 : true
	);

	return (
		<>
			{form.show ? (
				<MyForm
					title={`${form.insert ? 'افزودن' : 'ویرایش'} نیاز`}
					onSubmit={formSubmit}
					extraButtons={
						form.insert ? null : (
							<Button color='danger' className='mx-1' onClick={remove}>
								حذف
							</Button>
						)
					}
					loading={form.loading}>
					{form.insert ? (
						<InputSelect
							id='familyMemberNeedSubjectId'
							label='موضوع نیاز'
							value={'' + form.items.familyMemberNeedSubjectId}
							onChange={(val) =>
								formSet((old) => ({
									...old,
									items: { ...old.items, familyMemberNeedSubjectId: val ? Number(val) : 0 },
								}))
							}
							items={remainingNeeds.map((x) => ({ id: x.id, text: `${x.title}` }))}
						/>
					) : (
						<InputText
							readOnly
							label='موضوع نیاز'
							value={familyMemberNeedSubjects.find((x) => x.id == form.items.familyMemberNeedSubjectId).title}
						/>
					)}

					<InputText
						multiLine
						id='description'
						label='ملاحظات'
						value={form.items.description}
						onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
					/>
				</MyForm>
			) : null}

			<MyTableSortable
				title='لیست نیازها'
				cols={cols}
				rows={tbl.data}
				loading={tbl.loading}
				rowRenderer={(x) => rowRenderer(x, familyMemberNeedSubjects)}
				onRowClick={rowClick}
				onSortEnd={onSortEnd}
			/>
			{tbl.needSaveReOrder ? (
				<Button color='info' onClick={saveReOrder} className='mx-1'>
					ذخیره تغییر ترتیب
				</Button>
			) : null}
			{remainingNeeds.length > 0 ? (
				<Button color='success' onClick={toggleForm} className='mx-1'>
					افزودن
				</Button>
			) : null}
		</>
	);
};

export default MemeberNeeds;

const cols = ['عنوان', 'ملاحظات'];
const rowRenderer = (x, familyMemberNeedSubjects) => (
	<>
		<td>{familyMemberNeedSubjects.find((f) => f.id == x.familyMemberNeedSubjectId).title}</td>
		<td>{x.description}</td>
	</>
);
