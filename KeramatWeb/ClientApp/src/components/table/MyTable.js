import React from 'react';
import { arrayRange } from './../../helpers/ArrayHelpers';
import {
	Table,
	Alert,
	Pagination,
	PaginationItem,
	PaginationLink,
	Card,
	CardHeader,
	CardBody,
	CardFooter,
} from 'reactstrap';

const MyTable = ({ small = false, title, cols, rows, rowRenderer, onRowClick, pagination, onPageClick }) => {
	let pn1 = 0,
		pn2 = 0;
	if (pagination) {
		// totalItems
		// totalPages
		// itemsPerPage
		// currentPage

		pn1 = Math.max(pagination.currentPage - 2, 1);
		pn2 = Math.min(pagination.currentPage + 2, pagination.totalPages);
	}

	return (
		<Card className='my-3'>
			{title ? <CardHeader>{title}</CardHeader> : null}

			{/* <CardBody> */}
			{rows && rows.length > 0 ? (
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
			{/* </CardBody> */}

			{pagination ? (
				<CardFooter>
					<Pagination aria-label='صفحات' listClassName='justify-content-center'>
						<PaginationItem disabled={pagination.currentPage == 1}>
							<PaginationLink first onClick={onPageClick ? () => onPageClick(1) : undefined} />
						</PaginationItem>
						<PaginationItem disabled={pagination.currentPage == 1}>
							<PaginationLink
								previous
								onClick={onPageClick ? () => onPageClick(pagination.currentPage - 1) : undefined}
							/>
						</PaginationItem>

						{arrayRange(pn1, pn2).map((x, i) => (
							<PaginationItem key={i} active={pagination.currentPage == x}>
								<PaginationLink
									onClick={onPageClick && pagination.currentPage != x ? () => onPageClick(x) : undefined}>
									{x}
								</PaginationLink>
							</PaginationItem>
						))}

						<PaginationItem disabled={pagination.currentPage == pagination.totalPages}>
							<PaginationLink
								next
								onClick={onPageClick ? () => onPageClick(pagination.currentPage + 1) : undefined}
							/>
						</PaginationItem>
						<PaginationItem disabled={pagination.currentPage == pagination.totalPages}>
							<PaginationLink
								last
								onClick={onPageClick ? () => onPageClick(pagination.totalPages) : undefined}
							/>
						</PaginationItem>
					</Pagination>
				</CardFooter>
			) : null}
		</Card>
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
