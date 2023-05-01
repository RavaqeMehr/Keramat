import axios from 'axios';
import React, { useEffect, useState } from 'react';
import MyTable from '../../components/table/MyTable';
import { sleep } from '../../helpers/Utils';

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

const fakePagination1 = {
	totalItems: 1,
	totalPages: 1,
	itemsPerPage: 10,
	currentPage: 1,
};

const fakePagination2 = {
	totalItems: 1,
	totalPages: 3,
	itemsPerPage: 10,
	currentPage: 1,
};

const fakePagination3 = {
	totalItems: 1,
	totalPages: 10,
	itemsPerPage: 10,
	currentPage: 10,
};

const fakePagination4 = {
	totalItems: 1,
	totalPages: 10,
	itemsPerPage: 10,
	currentPage: 9,
};

const fakePagination5 = {
	totalItems: 1,
	totalPages: 10,
	itemsPerPage: 10,
	currentPage: 5,
};

const FamiliesList = () => {
	const [tbl, tblSet] = useState({
		search: '',
		page: 1,
		loading: true,
		cols: null,
		data: null,
		pagination: null,
	});

	const GetPage = (page) => {
		tblSet((old) => ({ ...old, loading: true }));
		axios
			.get('ValiNematan/List', { params: { search: tbl.search, page: page } })
			.then((x) => x.data.data)
			.then((x) => {
				const { items, ...pagination } = x;
				tblSet((old) => ({ ...old, loading: false, cols: fakeCols, data: items, pagination: pagination }));
			})
			.catch((e) => {})
			.finally(() => tblSet((old) => ({ ...old, loading: false })));
	};

	useEffect(() => {
		GetPage(1);
	}, []);

	return (
		<>
			<MyTable
				title='تست'
				cols={tbl.cols}
				rows={tbl.data}
				pagination={tbl.pagination}
				loading={tbl.loading}
				// rowRenderer={fakeRenderer}
				onPageClick={(x) => GetPage(x)}
				onRowClick={console.log}
			/>

			{/* <MyTable cols={fakeCols} rows={fakeData1} />
			<MyTable cols={fakeCols} rows={fakeData2} />
			<MyTable cols={fakeCols} rows={fakeData3} onRowClick={console.log} />
			<hr />
			<MyTable cols={fakeCols} rows={fakeData1} rowRenderer={fakeRenderer} />
			<MyTable cols={fakeCols} rows={fakeData2} rowRenderer={fakeRenderer} />
         <hr /> */}

			{/* <MyTable
				cols={fakeCols}
				rows={fakeData2}
				pagination={fakePagination2}
				onPageClick={console.log}
				title='تست عنوان'
				small
			/>
			<MyTable cols={fakeCols} rows={fakeData3} pagination={fakePagination3} onPageClick={console.log} />
			<MyTable cols={fakeCols} rows={fakeData1} pagination={fakePagination4} onPageClick={console.log} />
			<MyTable cols={fakeCols} rows={fakeData1} pagination={fakePagination5} onPageClick={console.log} /> */}
		</>
	);
};

export default FamiliesList;
