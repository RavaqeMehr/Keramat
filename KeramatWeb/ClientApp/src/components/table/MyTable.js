import React from 'react';
import {
	Alert,
	Card,
	CardFooter,
	CardHeader,
	Pagination,
	PaginationItem,
	PaginationLink,
	Table,
} from 'reactstrap';
import Loading from '../general/Loading';
import { arrayRange } from './../../helpers/ArrayHelpers';

const MyTable = ({
	small = false,
	loading = false,
	title,
	cols,
	rows,
	rowRenderer,
	onRowClick,
	pagination,
	onPageClick,
	search,
}) => {
	let pn1 = 0,
		pn2 = 0;
	if (pagination) {
		pn1 = Math.max(pagination.currentPage - 2, 1);
		pn2 = Math.min(pagination.currentPage + 2, pagination.totalPages);
	}

	return (
		<Card className='mb-4'>
			{title ? <CardHeader>{title}</CardHeader> : null}
			{search ? <CardHeader>{search}</CardHeader> : null}

			{loading ? <Loading /> : null}

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

			{pagination && pagination.totalPages > 0 ? (
				<CardFooter className='row g-0'>
					<div className='col align-self-center  text-end'>
						<span>موارد: {pagination.totalItems}</span>
					</div>
					<div className='col align-self-center'>
						<Pagination
							aria-label='صفحات'
							listClassName='justify-content-center'
							size={small ? 'sm' : undefined}>
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
					</div>
					<div className='col align-self-center text-start'>
						<span>صفحات: {pagination.totalPages}</span>
					</div>
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
