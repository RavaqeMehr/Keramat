import React from 'react';
import { Alert, Card, CardFooter, CardHeader, CardBody, Button } from 'reactstrap';
import BlurLayer from '../general/BlurLayer';

const MyForm = ({ title, children, onSubmit, loading = false }) => {
	return (
		<form
			onSubmit={(e) => {
				e.preventDefault();
				if (onSubmit) {
					onSubmit();
				}
			}}>
			<Card className='my-4'>
				<BlurLayer show={loading} />
				{title ? <CardHeader>{title}</CardHeader> : null}
				<CardBody>{children}</CardBody>
				<CardFooter>
					<Button type='submit' color='primary' className='mx-1'>
						ثبت
					</Button>
				</CardFooter>
			</Card>
		</form>
	);
};

export default MyForm;
