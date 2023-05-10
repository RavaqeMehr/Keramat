import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import axios from 'axios';
import { ReduxActions } from './../../store/index';
import MyForm from '../../components/form/MyForm';
import InputText from './../../components/form/InputText';

const Settings = () => {
	const dispatch = useDispatch();
	const { appInfo } = useSelector((x) => x.general);

	const [form, formSet] = useState({
		loading: false,
		items: {
			charityName: appInfo.charityName,
			charitySlogan: appInfo.charitySlogan,
		},
	});

	useEffect(() => {
		formSet((old) => ({
			...old,
			items: { charityName: appInfo.charityName, charitySlogan: appInfo.charitySlogan },
		}));
	}, [appInfo]);

	const submit = () => {
		formSet((old) => ({
			...old,
			loading: true,
		}));
		axios
			.put('Manage/Settings', form.items)
			.then((response) => response.data)
			.then((data) => {
				dispatch(ReduxActions.generalActions.updateAppInfo());
			})
			.catch(console.error)
			.finally(() =>
				formSet((old) => ({
					...old,
					loading: false,
				}))
			);
	};

	return (
		<>
			<MyForm title='ویرایش تنظیمات' onSubmit={submit} loading={form.loading}>
				<InputText
					id='charityName'
					label='عنوان خیره'
					value={form.items.charityName}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, charityName: val } }))}
				/>
				<InputText
					id='charitySlogan'
					label='شعار خیریه'
					value={form.items.charitySlogan}
					onChange={(val) => formSet((old) => ({ ...old, items: { ...old.items, charitySlogan: val } }))}
				/>
			</MyForm>
		</>
	);
};

export default Settings;
