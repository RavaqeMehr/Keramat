import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import MyTable from '../../../components/table/MyTable';
import MyDateTime from './../../../components/dateTime/MyDateTime';
import { apiError } from './../../../helpers/NotifHelper';

const FamilyRecivedServices = ({ familyId }) => {
	const navigate = useNavigate();

	const [tbl, tblSet] = useState({
		page: 1,
		loading: true,
		data: null,
		pagination: null,
	});

	const GetPage = (page) => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('Services/ProvidedToFamily', { params: { page, id: familyId } })
			.then((x) => x.data.data)
			.then((x) => {
				const { items, ...pagination } = x;
				tblSet((old) => ({ ...old, loading: false, data: items, pagination: pagination }));
			})
			.catch(apiError)
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		GetPage(1);
	}, []);

	return (
		<MyTable
			title='لیست خدمات ارائه‌شده'
			cols={cols}
			rows={tbl.data}
			pagination={tbl.pagination}
			loading={tbl.loading}
			rowRenderer={rowRenderer}
			onPageClick={(x) => GetPage(x)}
			onRowClick={(x) => navigate(`./../../../services/provided/${x.serviceProvidedId}`, { relative: true })}
		/>
	);
};

export default FamilyRecivedServices;

const cols = ['کد', 'عنوان خدمت', 'شرح خدمت', 'ملاحظات خانواده', 'زمان'];

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>{x.serviceSubjectTitle}</td>
		<td>{x.description}</td>
		<td>{x.serviceProvidedDescription}</td>
		<td>
			<MyDateTime dateTime={x.date} />
		</td>
	</>
);
