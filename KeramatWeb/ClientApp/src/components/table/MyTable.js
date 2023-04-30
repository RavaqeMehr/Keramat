import React from 'react';
import { Table, Alert } from 'reactstrap';

const MyTable = ({ small = false, cols, rows, rowRenderer, onRowClick }) => {
	return (
		<>
			{rows ? (
				<Table hover responsive striped size={small ? 'sm' : undefined}>
					{cols ? (
						<thead>
							<tr>
								{cols.map((x, i) => (
									<th key={'h' + i}>{x}</th>
								))}
							</tr>
						</thead>
					) : null}

					<tbody>
						{rows.map((x, i) => (
							<tr
								key={'r' + i}
								onClick={onRowClick ? () => onRowClick(x) : undefined}
								role={onRowClick ? 'button' : undefined}>
								{rowRenderer
									? rowRenderer(x)
									: Array.isArray(x)
									? defaultRowRenderer(x, i)
									: defaultRowRenderer(Object.values(x), i)}
							</tr>
						))}
					</tbody>
				</Table>
			) : (
				<Alert color='warning' className='text-center'>
					داده‌ای وجود ندارد!
				</Alert>
			)}
		</>
	);
};

export default MyTable;

const defaultRowRenderer = (vals, i = 0) =>
	vals.map((r, i2) => {
		const k = `r${i}-c${i2}`;
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
