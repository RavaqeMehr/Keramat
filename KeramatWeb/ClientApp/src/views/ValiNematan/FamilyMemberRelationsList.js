import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Button } from 'reactstrap';
import MyTableSortable from '../../components/table/MyTableSortable';
import { ReduxActions } from '../../store';

const FamilyMemberRelationsList = () => {
	const navigate = useNavigate();
	const dispatch = useDispatch();
	const { familyMemberRelations } = useSelector((x) => x.logic);

	const [tbl, tblSet] = useState({
		data: familyMemberRelations,
		beforeSort: familyMemberRelations,
		needSaveReOrder: false,
	});

	const onSortEnd = (sortedData) => {
		var o = tbl.beforeSort.reduce((a, b) => `${a},${b.id}`, '');
		var n = sortedData.reduce((a, b) => `${a},${b.id}`, '');

		tblSet((old) => ({ ...old, data: sortedData, needSaveReOrder: o != n }));
	};

	const saveReOrder = () => {
		const sortedIds = tbl.data.map((x) => x.id);
		axios
			.put('ValiNematan/ReOrderFamilyMemberRelations', { sortedIds })
			.then((response) => response.data)
			.then((data) => {
				dispatch(ReduxActions.logicActions.updateFamilyMemberRelations());
			})
			.catch(console.error);
	};

	useEffect(() => {
		tblSet({ data: familyMemberRelations, beforeSort: familyMemberRelations, needSaveReOrder: false });
	}, [familyMemberRelations]);

	return (
		<>
			<MyTableSortable
				title='لیست نسبت‌های خانوادگی'
				cols={['کد', 'عنوان', 'ملاحظات']}
				rows={tbl.beforeSort}
				rowRenderer={rowRenderer}
				onRowClick={(x) => navigate(`./${x.id}`, { relative: true })}
				onSortEnd={onSortEnd}
			/>
			{tbl.needSaveReOrder ? (
				<Button color='info' onClick={saveReOrder} className='mx-1'>
					ذخیره تغییر ترتیب
				</Button>
			) : null}

			<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })} className='mx-1'>
				افزودن
			</Button>
		</>
	);
};

export default FamilyMemberRelationsList;

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>{x.title}</td>
		<td>{x.description}</td>
	</>
);
