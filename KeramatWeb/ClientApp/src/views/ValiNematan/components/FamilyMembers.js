import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Button } from 'reactstrap';
import MyTable from '../../../components/table/MyTable';
import { useNavigate } from 'react-router-dom';

const FamilyMembers = ({ familyId }) => {
	const navigate = useNavigate();

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
			.catch((e) => {})
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
				rowRenderer={rowRenderer}
				onRowClick={(x) => navigate(`./${x.id}`, { relative: true })}
			/>
			<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })} className='mx-1'>
				افزودن
			</Button>
		</>
	);
};

export default FamilyMembers;

const cols = ['عنوان', 'ملاحظات'];
const rowRenderer = (x) => (
	<>
		<td>{x.id}</td>
		<td>{x.familyMemberRelationId}</td>
		<td>{x.gender}</td>
		<td>{x.maritalStatus}</td>
		<td>{x.name}</td>
		<td>{x.liveStatus}</td>
		<td>{x.age}</td>
	</>
);
