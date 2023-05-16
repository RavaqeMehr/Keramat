import React, { useEffect, useState } from 'react';
import { Badge, Button } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import MyTable from '../../components/table/MyTable';
import { NumberWithCommas } from './../../helpers/Utils';

const ProvidedList = () => {
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
			.get('Services/Provided', { params: { page } })
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

	return (
		<>
			<MyTable
				title='لیست خدمات ارائه‌شده'
				cols={cols}
				rows={tbl.data}
				pagination={tbl.pagination}
				loading={tbl.loading}
				rowRenderer={rowRenderer}
				onPageClick={(x) => GetPage(x)}
				onRowClick={(x) => navigate(`./${x.id}`, { relative: true })}
			/>
			<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })}>
				افزودن
			</Button>
		</>
	);
};

export default ProvidedList;

const cols = ['کد', 'نام', 'تلفن', 'تعداد خیرات', 'درج'];

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>{x.fullName}</td>
		<td>{x.phone}</td>
		<td>{NumberWithCommas(x.kheyratCount)}</td>
		<td>{x.addDateStr}</td>
	</>
);
