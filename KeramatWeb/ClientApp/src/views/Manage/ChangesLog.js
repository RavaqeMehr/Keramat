import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Badge } from 'reactstrap';
import MyDateTime from '../../components/dateTime/MyDateTime';
import MyTable from '../../components/table/MyTable';
import { _ChangeType } from '../../enums';
import { duration2String, NumberWithCommas } from '../../helpers/Utils';
import { _EnitityType } from './../../enums';
import { apiError } from './../../helpers/NotifHelper';

const ChangesLog = () => {
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
			.get('Manage/ChangesLog', { params: { page } })
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

	const [open, openSet] = useState(-1);

	return (
		<>
			<MyTable
				title='لیست تغییرات'
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
				<br />
				<ChangeLogLink data={x} />
			</th>
			<td colSpan={5} className='bg-warning'>
				{x.changedProps.map((c, i) => (
					<ChangePropItem key={i} prop={c} />
				))}
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

const ChangePropItem = ({ prop = '' }) => {
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

const ChangeLogLink = ({ data }) => {
	const navigate = useNavigate();
	const _changeType = _ChangeType.find((x) => x.val == data.changeType);

	const deleted = _changeType.key == 'Delete';

	const _type = _EnitityType.find((x) => x.val == data.enitityType);
	let url = null;

	switch (_type.key) {
		case 'Family':
			if (deleted) {
				return null;
			}
			url = `./../../vali-nematan/families/${data.entityId}`;
			break;
		case 'FamilyLevel':
			url = `./../../vali-nematan/levels/${data.entityId}`;
			break;
		case 'FamilyNeed':
			url = `./../../vali-nematan/families/${data.root1Id}`;
			break;
		case 'FamilyNeedSubject':
			if (deleted) {
				return null;
			}
			url = `./../../vali-nematan/family-needs/${data.entityId}`;
			break;
		case 'Connector':
			if (deleted) {
				return null;
			}
			url = `./../../vali-nematan/connectors/${data.entityId}`;
			break;
		case 'FamilyMember':
			if (deleted) {
				url = `./../../vali-nematan/families/${data.root1Id}`;
			} else {
				url = `./../../vali-nematan/families/${data.root1Id}/${data.entityId}`;
			}
			break;
		case 'FamilyMemberNeed':
			url = `./../../vali-nematan/families/${data.root2Id}/${data.root1Id}`;
			break;
		case 'FamilyMemberNeedSubject':
			if (deleted) {
				return null;
			}
			url = `./../../vali-nematan/member-needs/${data.entityId}`;
			break;
		case 'FamilyMemberRelation':
			if (deleted) {
				return null;
			}
			url = `./../../vali-nematan/relations/${data.entityId}`;
			break;
		case 'FamilyMemberSpecialDisease':
			url = `./../../vali-nematan/families/${data.root2Id}/${data.root1Id}`;
			break;
		case 'FamilyMemberSpecialDiseaseSubject':
			if (deleted) {
				return null;
			}
			url = `./../../vali-nematan/special-disease/${data.entityId}`;
			break;

		case 'NikooKar':
			if (deleted) {
				return null;
			}
			url = `./../../kheyrat/nikoo-karan/${data.entityId}`;
			break;
		case 'Kheyr':
			if (deleted) {
				url = `./../../kheyrat/nikoo-karan/${data.root1Id}`;
			} else {
				url = `./../../kheyrat/nikoo-karan/${data.root1Id}/${data.entityId}`;
			}
			break;

		case 'ServiceSubject':
			if (deleted) {
				return null;
			}
			url = `./../../services/subjects/${data.entityId}`;
			break;
		case 'ServiceProvided':
			if (deleted) {
				return null;
			}
			url = `./../../services/provided/${data.entityId}`;
			break;
		case 'ServiceReciver':
			url = `./../../services/provided/${data.root1Id}`;
			break;

		default:
			break;
	}

	return (
		<Badge
			title='لینک'
			color='secondary'
			onClick={(e) => {
				e.stopPropagation();
				// console.log(data, _type);
				if (url) {
					navigate(url, { relative: true });
				}
			}}>
			...
		</Badge>
	);
};
