import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Button } from 'reactstrap';
import MyTable from './../../components/table/MyTable';
import { NumberWithCommas } from './../../helpers/Utils';
import { apiError } from './../../helpers/NotifHelper';

const RecivedsList = ({ nikooKarId = null }) => {
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
			.get('Kheyrat/Kheyrat', { params: { nikooKarId, page } })
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
		<>
			<MyTable
				title='لیست خیرات دریافتی'
				cols={nikooKarId ? cols2 : cols}
				rows={tbl.data}
				pagination={tbl.pagination}
				loading={tbl.loading}
				rowRenderer={(x) => rowRenderer(x, nikooKarId)}
				onPageClick={(x) => GetPage(x)}
				onRowClick={(x) =>
					navigate(nikooKarId ? `./${x.id}` : `./../nikoo-karan/${x.nikooKarId}/${x.id}`, { relative: true })
				}
			/>
			{nikooKarId ? (
				<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })}>
					افزودن
				</Button>
			) : null}
		</>
	);
};

export default RecivedsList;

const cols = ['کد', 'نیکوکار', 'ارزش ریالی', 'زمان'];
const cols2 = ['کد', 'ارزش ریالی', 'زمان'];

const rowRenderer = (x, nikooKarId) => (
	<>
		<th scope='row'>{x.id}</th>
		{nikooKarId ? null : <td>{x.nikooKarId}</td>}
		<td>{NumberWithCommas(x.cashAndNotCashValues + 0)} ریال</td>
		<td>{x.dateStr}</td>
	</>
);
