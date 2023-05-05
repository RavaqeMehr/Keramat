import React from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Button } from 'reactstrap';
import MyTable from '../../components/table/MyTable';

const ConnectorsList = () => {
	const navigate = useNavigate();
	const { connectors } = useSelector((x) => x.logic);

	return (
		<>
			<MyTable
				title='لیست سطح‌ها'
				cols={['کد', 'نام', 'تلفن', 'ملاحظات']}
				rows={connectors}
				rowRenderer={rowRenderer}
				onRowClick={(x) => navigate(`./${x.id}`, { relative: true })}
			/>
			<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })}>
				افزودن
			</Button>
		</>
	);
};

export default ConnectorsList;

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>{x.name}</td>
		<td>{x.phone}</td>
		<td>{x.description}</td>
	</>
);
