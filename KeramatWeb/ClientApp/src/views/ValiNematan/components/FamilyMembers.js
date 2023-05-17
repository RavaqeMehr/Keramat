import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Badge, Button } from 'reactstrap';
import MyTable from '../../../components/table/MyTable';
import * as enums from '../../../enums';
import { apiError } from './../../../helpers/NotifHelper';

const FamilyMembers = ({ familyId }) => {
	const navigate = useNavigate();

	const { familyMemberRelations } = useSelector((x) => x.logic);

	const [tbl, tblSet] = useState({
		loading: true,
		data: null,
	});

	const loadTable = () => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('ValiNematan/MembersList', { params: { familyId } })
			.then((x) => x.data.data)
			.then((x) => {
				tblSet((old) => ({ ...old, loading: false, data: x }));
			})
			.catch(apiError)
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		loadTable();
	}, []);

	return (
		<>
			<MyTable
				title='لیست اعضا'
				cols={cols}
				rows={tbl.data}
				loading={tbl.loading}
				rowRenderer={(x) => rowRenderer(x, familyMemberRelations)}
				onRowClick={(x) => navigate(`./${x.id}`, { relative: true })}
			/>
			<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })} className='mx-1'>
				افزودن
			</Button>
		</>
	);
};

export default FamilyMembers;

const cols = ['کد', 'نسبت', 'نام', 'وضعیت تاهل', 'سن'];
const rowRenderer = (x, familyMemberRelations) => {
	return (
		<>
			<td>{x.id}</td>
			<td>{familyMemberRelations.find((y) => y.id == x.familyMemberRelationId).title}</td>
			<td>
				{x.name} {liveLabel(x.liveStatus)}
			</td>
			<td>{enums._MaritalStatus.find((y) => y.val == x.maritalStatus).text}</td>
			<td>{x.age}</td>
		</>
	);
};

const liveLabel = (liveStatus) =>
	liveStatus <= 0 ? null : (
		<Badge color='warning' className='text-dark'>
			{enums._LiveStatus.find((x) => x.val == liveStatus).text}
		</Badge>
	);
