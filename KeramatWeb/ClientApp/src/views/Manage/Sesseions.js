import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Badge } from 'reactstrap';
import MyDateTime from '../../components/dateTime/MyDateTime';
import MyTable from '../../components/table/MyTable';
import { duration2String, NumberWithCommas } from '../../helpers/Utils';

const Sesseions = () => {
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
			.get('Manage/Sessions', { params: { page } })
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
				title='لیست نشست‌ها'
				cols={cols}
				rows={tbl.data}
				pagination={tbl.pagination}
				loading={tbl.loading}
				rowRenderer={rowRenderer}
				onPageClick={(x) => GetPage(x)}
				onRowClick={(x) => navigate(`./../changes-log/${x.id}`, { relative: true })}
			/>
		</>
	);
};

export default Sesseions;

const cols = ['کد', 'شروع', 'پایان', 'مدت', 'تغییرات'];

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>
			<MyDateTime dateTime={x.startDate} />
		</td>
		<td>
			{x.durationSeconds > 0 ? (
				<MyDateTime dateTime={x.endDate} />
			) : (
				<Badge color='warning'>پایان ثبت نشده</Badge>
			)}
		</td>
		<td>
			{x.durationSeconds > 0 ? <Badge color='info'>{`${duration2String(x.durationSeconds)}`}</Badge> : null}
		</td>
		<td>{NumberWithCommas(x.changesCount)}</td>
	</>
);
