import React from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Button } from 'reactstrap';
import MyTable from '../../components/table/MyTable';

const FamailiLevelsList = () => {
	const navigate = useNavigate();
	const { familyLevels } = useSelector((x) => x.logic);

	return (
		<>
			<MyTable
				title='لیست سطح‌ها'
				cols={['کد', 'عنوان', 'ملاحظات', 'سطح']}
				rows={familyLevels}
				onRowClick={(x) => navigate(`./${x.id}`, { relative: true })}
			/>
			<Button color='success' onClick={(x) => navigate(`./0`, { relative: true })}>
				افزودن
			</Button>
		</>
	);
};

export default FamailiLevelsList;
