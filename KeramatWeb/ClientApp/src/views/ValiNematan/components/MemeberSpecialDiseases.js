import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { Button } from 'reactstrap';
import InputSelect from '../../../components/form/InputSelect';
import InputText from '../../../components/form/InputText';
import MyForm from '../../../components/form/MyForm';
import MyTable from '../../../components/table/MyTable';
import MyTableSortable from '../../../components/table/MyTableSortable';

const MemeberSpecialDiseases = ({ familyId, familyMemberId }) => {
	const { familyMemberSpecialDiseaseSubjects } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		show: false,
		insert: true,
		loading: false,
		items: {
			id: 0,
			familyMemberSpecialDiseaseSubjectId: null,
			description: '',
		},
	});

	const toggleForm = () => {
		if (remainingSpecialDiseases.length > 0) {
			formSet((old) => ({
				...old,
				show: !old.show,
				insert: true,
				loading: false,
				items: {
					id: 0,
					familyMemberSpecialDiseaseSubjectId: remainingSpecialDiseases[0].id,
					description: '',
				},
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
				familyMemberSpecialDiseaseSubjectId: x.familyMemberSpecialDiseaseSubjectId,
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
				familyMemberSpecialDiseaseSubjectId:
					+form.items.familyMemberSpecialDiseaseSubjectId > 0
						? form.items.familyMemberSpecialDiseaseSubjectId
						: null,
			};

			axios
				.post('ValiNematan/AddFamilyMemberSpecialDisease', dto)
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, show: false }));
					loadTable();
				})
				.catch(console.error)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		} else {
			const dto = {
				id: form.items.id,
				description: form.items.description,
			};

			axios
				.put('ValiNematan/EditFamilyMemberSpecialDisease', dto)
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, show: false }));
					loadTable();
				})
				.catch(console.error)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		}
	};

	const remove = () => {
		axios
			.delete('ValiNematan/RemoveFamilyMemberSpecialDisease', { params: { id: form.items.id } })
			.then((response) => response.data)
			.then((data) => {
				formSet((old) => ({ ...old, show: false }));
				loadTable();
			})
			.catch(console.error)
			.finally(() => formSet((old) => ({ ...old, loading: false })));
	};

	const saveReOrder = () => {
		const sortedIds = tbl.data.map((x) => x.id);
		axios
			.put('ValiNematan/ReOrderFamilyMemberSpecialDiseases', { sortedIds })
			.then((response) => response.data)
			.then((data) => {
				loadTable();
			})
			.catch(console.error);
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
			.get('ValiNematan/FamilyMemberSpecialDiseases', { params: { familyMemberId } })
			.then((x) => x.data.data)
			.then((x) => {
				tblSet((old) => ({ ...old, loading: false, data: x, beforeSort: x, needSaveReOrder: false }));
			})
			.catch((e) => {})
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		loadTable();
	}, []);

	const remainingSpecialDiseases = familyMemberSpecialDiseaseSubjects.filter((x) =>
		tbl.data ? tbl.data.findIndex((t) => t.familyMemberSpecialDiseaseSubjectId == x.id) == -1 : true
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
							id='familyMemberSpecialDiseaseSubjectId'
							label='موضوع نیاز'
							value={'' + form.items.familyMemberSpecialDiseaseSubjectId}
							onChange={(val) =>
								formSet((old) => ({
									...old,
									items: { ...old.items, familyMemberSpecialDiseaseSubjectId: val ? Number(val) : 0 },
								}))
							}
							items={remainingSpecialDiseases.map((x) => ({ id: x.id, text: `${x.title}` }))}
						/>
					) : (
						<InputText
							readOnly
							label='موضوع نیاز'
							value={
								familyMemberSpecialDiseaseSubjects.find(
									(x) => x.id == form.items.familyMemberSpecialDiseaseSubjectId
								).title
							}
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
				rowRenderer={(x) => rowRenderer(x, familyMemberSpecialDiseaseSubjects)}
				onRowClick={rowClick}
				onSortEnd={onSortEnd}
			/>
			{tbl.needSaveReOrder ? (
				<Button color='info' onClick={saveReOrder} className='mx-1'>
					ذخیره تغییر ترتیب
				</Button>
			) : null}
			{remainingSpecialDiseases.length > 0 ? (
				<Button color='success' onClick={toggleForm} className='mx-1'>
					افزودن
				</Button>
			) : null}
		</>
	);
};

export default MemeberSpecialDiseases;

const cols = ['عنوان', 'ملاحظات'];
const rowRenderer = (x, familyMemberSpecialDiseaseSubjects) => (
	<>
		<td>
			{familyMemberSpecialDiseaseSubjects.find((f) => f.id == x.familyMemberSpecialDiseaseSubjectId).title}
		</td>
		<td>{x.description}</td>
	</>
);
