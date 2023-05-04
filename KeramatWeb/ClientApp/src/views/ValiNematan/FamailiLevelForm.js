import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import MyForm from '../../components/form/MyForm';
import InputText from '../../components/form/InputText';
import { normalizeNumberInt } from '../../helpers/Utils';
import { ReduxActions } from '../../store';
import axios from 'axios';

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
		</>
	);
};

export default FamailiLevelForm;
