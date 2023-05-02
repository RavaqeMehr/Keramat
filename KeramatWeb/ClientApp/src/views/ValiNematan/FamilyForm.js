import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import InputText from '../../components/form/InputText';
import MyForm from '../../components/form/MyForm';
import { useSelector } from 'react-redux';
import InputSelect from '../../components/form/InputSelect';
import axios from 'axios';

const FamilyForm = () => {
	const navigate = useNavigate();
	const { id } = useParams();
	const { familyLevels, connectors } = useSelector((x) => x.logic);

	const [form, formSet] = useState({
		loading: true,
		items: {
			title: '',
			address: '',
			levelId: 0,
			description: '',
			contactPersonName: '',
			contactPersonPhone: '',
			contactPersonDescription: '',
			connectorId: 0,
		},
	});

	useEffect(() => {
		if (id > 0) {
			formSet((old) => ({ ...old, loading: true }));
			axios
				.get('ValiNematan/Single', { params: { id } })
				.then((response) => response.data)
				.then((data) => {
					formSet((old) => ({ ...old, items: data.data, loading: false }));
				})
				.catch(console.error)
				.finally(() => formSet((old) => ({ ...old, loading: false })));
		} else {
			formSet((old) => ({ ...old, loading: false }));
		}
	}, []);

	const submit = () => {
		console.log('submit');

		const dto = {
			...form.items,
			levelId: +form.items.levelId > 0 ? form.items.levelId : null,
			connectorId: +form.items.connectorId > 0 ? form.items.connectorId : null,
		};

		if (id == 0) {
			axios
				.post('ValiNematan/Add', dto)
				.then((response) => response.data)
				.then((data) => {
					navigate(`../${data.data}`, { replace: true, relative: true });
				})
				.catch(console.error);
		} else {
			axios
				.put('ValiNematan/Edit', { id, ...dto })
				.then((response) => response.data)
				.then((data) => {
					navigate(`../`, { relative: true });
				})
				.catch(console.error);
		}
	};

	return (
		<>
			<MyForm title={`${id == 0 ? 'افزودن' : 'ویرایش'} خانواده`} onSubmit={submit} loading={form.loading}>
				<InputText id='id' label='کد' readOnly value={id} />
				<InputText
					id='title'
					label='عنوان'
					value={form.items.title}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, title: val } }))}
				/>
				<InputText
					id='address'
					label='آدرس'
					value={form.items.address}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, address: val } }))}
				/>
				<InputSelect
					id='levelId'
					label='سطح'
					value={'' + form.items.levelId}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, levelId: Number(val) } }))}
					items={familyLevels.map((x) => ({ id: x.id, text: `${x.title} [${x.level}]` }))}
				/>
				<InputText
					multiLine
					id='description'
					label='ملاحظات'
					value={form.items.description}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, description: val } }))}
				/>
				<InputText
					id='contactPersonName'
					label='نام'
					description='رابط خانواده'
					value={form.items.contactPersonName}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, contactPersonName: val } }))}
				/>
				<InputText
					id='contactPersonPhone'
					label='تلفن'
					description='رابط خانواده'
					value={form.items.contactPersonPhone}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, contactPersonPhone: val } }))}
				/>
				<InputText
					multiLine
					id='contactPersonDescription'
					label='ملاحظات'
					description='رابط خانواده'
					value={form.items.contactPersonDescription}
					onChange={(val) =>
						formSet((old) => ({ ...old, items: { ...old.items, contactPersonDescription: val } }))
					}
				/>
				<InputSelect
					id='connectorId'
					label='معرف'
					value={'' + form.items.connectorId}
					onChange={(val) =>
						formSet((old) => ({ ...old, items: { ...old.items, connectorId: Number(val) } }))
					}
					items={connectors.map((x) => ({ id: x.id, text: `${x.Name}` }))}
				/>
			</MyForm>
		</>
	);
};

export default FamilyForm;
