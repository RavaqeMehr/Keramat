import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { Button } from 'reactstrap';
import InputSelect from '../../../components/form/InputSelect';
import InputText from '../../../components/form/InputText';
import MyForm from '../../../components/form/MyForm';
import MyTable from '../../../components/table/MyTable';

const FamilyNeeds = ({ familyId }) => {
	const { familyNeedSubjects } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		show: false,
		insert: true,
		loading: false,
		items: {
			id: 0,
			familyNeedSubjectId: null,
			description: '',
		},
	});

	const toggleForm = () => {
		if (remainingNeeds.length > 0) {
			formSet((old) => ({
				...old,
				show: !old.show,
				insert: true,
				loading: false,
				items: { id: 0, familyNeedSubjectId: remainingNeeds[0].id, description: '' },
			}));
		}
	};

	const rowClick = (x) => {
		formSet((old) => ({
			...old,
			show: true,
			insert: false,
			loading: false,
			items: { id: x.id, familyNeedSubjectId: x.familyNeedSubjectId, description: x.description },
		}));
	};

	const formSubmit = () => {
		formSet((old) => ({ ...old, loading: true }));

		if (form.insert) {
			const dto = {
				familyId: familyId,
				description: form.items.description,
				familyNeedSubjectId: +form.items.familyNeedSubjectId > 0 ? form.items.familyNeedSubjectId : null,
			};

			axios
				.post('ValiNematan/AddFamilyNeed', dto)
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
				.put('ValiNematan/EditFamilyNeed', dto)
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
			.delete('ValiNematan/RemoveFamilyNeed', { params: { id: form.items.id } })
			.then((response) => response.data)
			.then((data) => {
				formSet((old) => ({ ...old, show: false }));
				loadTable();
			})
			.catch(console.error)
			.finally(() => formSet((old) => ({ ...old, loading: false })));
	};

	const [tbl, tblSet] = useState({
		loading: true,
		data: null,
	});

	const loadTable = () => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('ValiNematan/FamilyNeeds', { params: { familyId } })
			.then((x) => x.data.data)
			.then((x) => {
				tblSet((old) => ({ ...old, loading: false, data: x }));
			})
			.catch((e) => {})
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		loadTable();
	}, []);

	const remainingNeeds = familyNeedSubjects.filter((x) =>
		tbl.data ? tbl.data.findIndex((t) => t.familyNeedSubjectId == x.id) == -1 : true
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
							id='familyNeedSubjectId'
							label='موضوع نیاز'
							value={'' + form.items.familyNeedSubjectId}
							onChange={(val) =>
								formSet((old) => ({
									...old,
									items: { ...old.items, familyNeedSubjectId: val ? Number(val) : 0 },
								}))
							}
							items={remainingNeeds.map((x) => ({ id: x.id, text: `${x.title}` }))}
						/>
					) : (
						<InputText
							readOnly
							label='موضوع نیاز'
							value={familyNeedSubjects.find((x) => x.id == form.items.familyNeedSubjectId).title}
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

			<MyTable
				title='لیست نیازها'
				cols={cols}
				rows={tbl.data}
				loading={tbl.loading}
				rowRenderer={(x) => rowRenderer(x, familyNeedSubjects)}
				onRowClick={rowClick}
			/>
			{remainingNeeds.length > 0 ? (
				<Button color='success' onClick={toggleForm}>
					افزودن
				</Button>
			) : null}
		</>
	);
};

export default FamilyNeeds;

const cols = ['ترتیب', 'عنوان', 'ملاحظات'];
const rowRenderer = (x, familyNeedSubjects) => (
	<>
		<th scope='row'></th>
		<td>{familyNeedSubjects.find((f) => f.id == x.familyNeedSubjectId).title}</td>
		<td>{x.description}</td>
	</>
);
