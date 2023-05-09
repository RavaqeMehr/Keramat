import React from 'react';
import MyTable from '../../../components/table/MyTable';

const MemberUsesTable = ({ navigate, data, pagination, loading, GetPage }) => (
	<MyTable
		title='لیست وابسطه'
		cols={cols}
		rows={data}
		pagination={pagination}
		loading={loading}
		rowRenderer={(x) => (
			<>
				<td>{x.familyTitle}</td>
				<td>{x.name}</td>
			</>
		)}
		onPageClick={GetPage}
		onRowClick={(x) => navigate(`./../../families/${x.familyId}/${x.id}`, { relative: true })}
	/>
);

export default MemberUsesTable;

const cols = ['خانواده', 'عضو'];
