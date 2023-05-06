import React from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Button } from 'reactstrap';
import MyTable from '../../components/table/MyTable';

const FamilyNeedSubjectsList = () => {
	const navigate = useNavigate();
	const { familyNeedSubjects } = useSelector((x) => x.logic);

	return (
		<>
			<MyTable
				title='لیست نیازهای خانواده'
				cols={['کد', 'عنوان', 'ملاحظات']}
				rows={familyNeedSubjects}
				rowRenderer={rowRenderer}
				onRowClick={(x) => navigate(`./${x.id}`, { relative: true })}
			/>
			<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })}>
				افزودن
			</Button>
		</>
	);
};

export default FamilyNeedSubjectsList;

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>{x.title}</td>
		<td>{x.description}</td>
	</>
);
