import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Badge, Button } from 'reactstrap';
import MyTable from '../../components/table/MyTable';
import { apiError } from './../../helpers/NotifHelper';

const FamiliesList = () => {
	const navigate = useNavigate();

	const [tbl, tblSet] = useState({
		search: '',
		page: 1,
		loading: true,
		cols: null,
		data: null,
		pagination: null,
	});

	const GetPage = (page) => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('ValiNematan/List', { params: { search: tbl.search, page: page } })
			.then((x) => x.data.data)
			.then((x) => {
				const { items, ...pagination } = x;
				tblSet((old) => ({ ...old, loading: false, cols: cols, data: items, pagination: pagination }));
			})
			.catch(apiError)
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		GetPage(1);
	}, []);

	return (
		<>
			<MyTable
				title='لیست خانواده‌ها'
				cols={tbl.cols}
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

export default FamiliesList;

const cols = ['کد', 'نام', 'سطح', 'اعضاء', 'درج'];

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>
			{x.title} {x.finished ? <Badge color='danger'>مختومه</Badge> : null}
		</td>
		<td>{x.level}</td>
		<td>{x.membersCount}</td>
		<td>{x.addDate}</td>
	</>
);
