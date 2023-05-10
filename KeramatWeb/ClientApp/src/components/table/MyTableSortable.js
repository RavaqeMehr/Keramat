import React from 'react';
import { Alert, Card, CardHeader, Table } from 'reactstrap';
import Loading from '../general/Loading';
import SortableList, { SortableItem, SortableKnob } from 'react-easy-sort';
import arrayMove from 'array-move';

const MyTableSortable = ({
	small = false,
	loading = false,
	title,
	cols,
	rows,
	rowRenderer,
	onRowClick,
	onSortEnd,
	orderMember = 'order',
}) => {
	const preSort = (o, n) => {
		const ar = arrayMove(rows, o, n);
		for (let i = 0; i < ar.length; i++) {
			ar[i][orderMember] = i + 1;
		}
		onSortEnd(ar.sort((a, b) => a.order - b.order));
	};

	return (
		<Card className='mb-4'>
			{title ? <CardHeader>{title}</CardHeader> : null}

			{loading ? <Loading /> : null}

			{rows && rows.length > 0 ? (
				<Table hover responsive striped size={small ? 'sm' : undefined}>
					{cols ? (
						<thead>
							<tr>
								{/* <th>ترتیب</th> */}
								{cols.map((x, i) => (
									<th key={'h' + i}>{x}</th>
								))}
							</tr>
						</thead>
					) : null}

					<SortableList onSortEnd={preSort} lockAxis='y' draggedItemClassName='sortable-at-sort' as='tbody'>
						{rows
							.sort((a, b) => a[orderMember] - b[orderMember])
							.map((x, i) => (
								<SortableItem key={i}>
									<tr
										key={'r' + i}
										onClick={onRowClick ? () => onRowClick(x) : undefined}
										className='user-select-none'
										role={onRowClick ? 'button' : undefined}>
										{/* <th scope='row'>
											<SortableKnob>
												<span>.</span>
											</SortableKnob>
										</th> */}

										{rowRenderer
											? rowRenderer(x)
											: Array.isArray(x)
											? defaultRowRenderer(x, i)
											: defaultRowRenderer(Object.values(x), i)}
									</tr>
								</SortableItem>
							))}
					</SortableList>
				</Table>
			) : (
				<Alert color='warning' className='text-center'>
					داده‌ای وجود ندارد!
				</Alert>
			)}
		</Card>
	);
};

export default MyTableSortable;

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
