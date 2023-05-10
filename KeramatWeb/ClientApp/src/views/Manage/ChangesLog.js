import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Badge } from 'reactstrap';
import MyDateTime from '../../components/dateTime/MyDateTime';
import MyTable from '../../components/table/MyTable';
import { _ChangeType } from '../../enums';
import { duration2String, NumberWithCommas } from '../../helpers/Utils';
import { _EnitityType } from './../../enums';

const ChangesLog = () => {
	const navigate = useNavigate();
	const { id } = useParams();

	const [tbl, tblSet] = useState({
		page: 1,
		loading: true,
		data: null,
		pagination: null,
	});

	const GetPage = (page) => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('Manage/ChangesLog', { params: { page, appSessionId: id } })
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
	}, [id]);

	const [open, openSet] = useState(-1);

	return (
		<>
			<MyTable
				title='لیست نشست‌ها'
				cols={cols}
				rows={tbl.data}
				pagination={tbl.pagination}
				loading={tbl.loading}
				rowRenderer={(x) => rowRenderer(x, open == x.id)}
				onPageClick={(x) => GetPage(x)}
				onRowClick={(x) => openSet((old) => (old == x.id ? -1 : x.id))}
			/>
		</>
	);
};

export default ChangesLog;

const cols = ['کد', 'نشست', 'زمان', 'نوع', 'مورد', 'تغییرات'];

const rowRenderer = (x, open = false) =>
	open ? (
		<>
			<th scope='row' className='bg-warning'>
				{x.id}
				<br />
				{changeTypeBadge(x.changeType)}
			</th>
			<td colSpan={5} className='bg-warning'>
				{x.changedProps.map((c, i) => changePropItem(c))}
			</td>
		</>
	) : (
		<>
			<th scope='row'>{x.id}</th>
			<td>{x.appSessionId}</td>
			<td>
				<MyDateTime dateTime={x.date} showTime timeOnNewLine showTimeAgo={false} />
			</td>
			<td>{changeTypeBadge(x.changeType)}</td>
			<td>{entity(x)}</td>
			<td>{NumberWithCommas(x.changedPropsCount)}</td>
		</>
	);

const changeTypeColor = (changeType) => {
	const _type = _ChangeType.find((x) => x.val == changeType);
	return _type.key == 'Add' ? 'success' : _type.key == 'Edit' ? 'warning' : 'danger';
};

const changeTypeBadge = (changeType) => {
	const _type = _ChangeType.find((x) => x.val == changeType);
	const chars = ['', '+', '=', '-'];
	return (
		<Badge
			title={_type.text}
			color={changeTypeColor(changeType)}
			className={_type.key == 'Edit' ? 'text-dark' : undefined}>
			{/* {_type.text} */}
			<strong>{chars[changeType]}</strong>
		</Badge>
	);
};

const entity = (item) => {
	const _type = _EnitityType.find((x) => x.val == item.enitityType);

	return (
		<>
			<small>{_type.text} </small>
			<Badge title='کد' color='primary'>
				{item.entityId}
			</Badge>
			{item.root1Id ? (
				<Badge title='ریشه 1' color='info' pill>
					{item.root1Id}
				</Badge>
			) : null}
			{item.root2Id ? (
				<Badge title='ریشه 2' color='secondary' pill>
					{item.root2Id}
				</Badge>
			) : null}
			{item.root3Id ? (
				<Badge title='ریشه 3' color='dark' pill>
					{item.root3Id}
				</Badge>
			) : null}
		</>
	);
};

const changePropItem = (prop = '') => {
	const p = prop.split(':');
	var title = p[0].replace('[', '').replace(']', '');
	var desc = p[1];
	return (
		<span className='d-block'>
			<Badge title='کد' color='primary'>
				{title}
			</Badge>
			{' : '}
			{desc}
		</span>
	);
};
