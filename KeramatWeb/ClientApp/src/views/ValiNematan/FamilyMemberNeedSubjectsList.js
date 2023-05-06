import React from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Button } from 'reactstrap';
import MyTable from '../../components/table/MyTable';

const FamilyMemberNeedSubjectsList = () => {
	const navigate = useNavigate();
	const { familyMemberNeedSubjects } = useSelector((x) => x.logic);

	return (
		<>
			<MyTable
				title='لیست نیازهای اعضای خانواده'
				cols={['کد', 'عنوان', 'ملاحظات']}
				rows={familyMemberNeedSubjects}
				rowRenderer={rowRenderer}
				onRowClick={(x) => navigate(`./${x.id}`, { relative: true })}
			/>
			<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })}>
				افزودن
			</Button>
		</>
	);
};

export default FamilyMemberNeedSubjectsList;

const rowRenderer = (x) => (
	<>
		<th scope='row'>{x.id}</th>
		<td>{x.title}</td>
		<td>{x.description}</td>
	</>
);
