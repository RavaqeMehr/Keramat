import React from 'react';
import MyTable from '../../../components/table/MyTable';

const FamilyUsesTable = ({ navigate, data, pagination, loading, GetPage }) => (
	<MyTable
		title='لیست وابسطه'
		cols={cols}
		rows={data}
		pagination={pagination}
		loading={loading}
		rowRenderer={(x) => (
			<>
				<th scope='row'>{x.id}</th>
				<td>{x.title}</td>
				<td>{x.addDate}</td>
			</>
		)}
		onPageClick={GetPage}
		onRowClick={(x) => navigate(`./../../families/${x.id}`, { relative: true })}
	/>
);

export default FamilyUsesTable;

const cols = ['کد', 'عنوان', 'درج'];
