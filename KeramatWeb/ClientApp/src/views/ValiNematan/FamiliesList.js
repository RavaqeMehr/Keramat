import React from 'react';
import MyTable from '../../components/table/MyTable';

const fakeCols = ['کد', 'نام', 'طرح', 'اقدام'];
const fakeData1 = [];
const fakeData2 = [
	[1, 'سینا', 'آب', 'شود'],
	[2, 'نیما', 'باد', 'شد'],
	[3, 'علی', 'آتش', 'نشود'],
	[4, 'حمید', 'خاک', 'نشد'],
	[5, 'اکبر', 'الکی', 'به من چه'],
];
const fakeData3 = [
	{ id: 1, name: 'سینا', tarh: 'آب', eqdam: 'شود' },
	{ id: 2, name: 'نیما', tarh: 'باد', eqdam: 'شد' },
	{ id: 3, name: 'علی', tarh: 'آتش', eqdam: 'نشود' },
	{ id: 4, name: 'حمید', tarh: 'خاک', eqdam: 'نشد' },
	{ id: 5, name: 'اکبر', tarh: 'الکی', eqdam: 'به من چه' },
];

const fakeRenderer = (x) => {
	if (x) {
		return x.map((r, i2) => {
			const k = `r${0}-c${i2}`;
			if (i2 == 0) {
				return (
					<th key={k} scope='row'>
						{r}
					</th>
				);
			} else {
				return <td key={k}>{r}</td>;
			}
		});
	}
	return null;
};

const FamiliesList = () => {
	return (
		<>
			<MyTable cols={fakeCols} rows={fakeData1} />
			<MyTable cols={fakeCols} rows={fakeData2} />
			<MyTable cols={fakeCols} rows={fakeData3} onRowClick={console.log} />
			<hr />
			<MyTable cols={fakeCols} rows={fakeData1} rowRenderer={fakeRenderer} />
			<MyTable cols={fakeCols} rows={fakeData2} rowRenderer={fakeRenderer} />
			{/* <MyTable cols={fakeCols} rows={fakeData3} rowRenderer={fakeRenderer} /> */}
		</>
	);
};

export default FamiliesList;
