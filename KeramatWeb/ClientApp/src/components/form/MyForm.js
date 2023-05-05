import React, { useState } from 'react';
import { Badge, Button, Card, CardBody, CardFooter, CardHeader, Collapse } from 'reactstrap';
import BlurLayer from '../general/BlurLayer';

const MyForm = ({ title, children, onSubmit, loading = false }) => {
	const [isOpen, isOpenSet] = useState(true);
	return (
		<form
			onSubmit={(e) => {
				e.preventDefault();
				if (onSubmit) {
					onSubmit();
				}
			}}>
			<Card className='mb-4'>
				<BlurLayer show={loading} />
				<CardHeader>
					<Badge color='dark' role='button' onClick={() => isOpenSet((old) => !old)}>
						{isOpen ? '-' : '+'}
					</Badge>{' '}
					{title}
				</CardHeader>
				<Collapse isOpen={isOpen}>
					<CardBody>{children}</CardBody>
				</Collapse>
				<Collapse isOpen={isOpen}>
					<CardFooter>
						<Button type='submit' color='primary' className='mx-1'>
							ثبت
						</Button>
					</CardFooter>
				</Collapse>
			</Card>
		</form>
	);
};

export default MyForm;
