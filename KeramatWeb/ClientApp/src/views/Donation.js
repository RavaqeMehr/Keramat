import React from 'react';
import { Row, Col } from 'reactstrap';

const Donation = () => {
	return (
		<>
			<Row className='text-center'>
				<Col sm={{ size: 12 }} md={{ size: 4 }}>
					<img src='assets/images/donation1.png' alt='حمایت مالی از پروژه کرامت به مبلغ 1 میلیون تومان' />
					<a href='https://zarinp.al/499712' target='_Blank' className='btn d-block btn-success'>
						1 میلیون تومان
					</a>
				</Col>
				<Col sm={{ size: 12 }} md={{ size: 4 }}>
					<img src='assets/images/donation2.png' alt='حمایت مالی از پروژه کرامت به مبلغ 2 میلیون تومان' />
					<a href='https://zarinp.al/499720' target='_Blank' className='btn d-block btn-success'>
						2 میلیون تومان
					</a>
				</Col>
				<Col sm={{ size: 12 }} md={{ size: 4 }}>
					<img src='assets/images/donation5.png' alt='حمایت مالی از پروژه کرامت به مبلغ 5 میلیون تومان' />
					<a href='https://zarinp.al/499722' target='_Blank' className='btn d-block btn-success'>
						5 میلیون تومان
					</a>
				</Col>
			</Row>
			<Row className='text-center'>
				<Col sm={{ size: 12 }} md={{ size: 4 }}>
					<img src='assets/images/donation10.png' alt='حمایت مالی از پروژه کرامت به مبلغ 10 میلیون تومان' />
					<a href='https://zarinp.al/499723' target='_Blank' className='btn d-block btn-success'>
						10 میلیون تومان
					</a>
				</Col>
				<Col sm={{ size: 12 }} md={{ size: 4 }}>
					<img src='assets/images/donation20.png' alt='حمایت مالی از پروژه کرامت به مبلغ 20 میلیون تومان' />
					<a href='https://zarinp.al/499724' target='_Blank' className='btn d-block btn-success'>
						20 میلیون تومان
					</a>
				</Col>
				<Col sm={{ size: 12 }} md={{ size: 4 }}>
					<img src='assets/images/donation50.png' alt='حمایت مالی از پروژه کرامت به مبلغ 50 میلیون تومان' />
					<a href='https://zarinp.al/499725' target='_Blank' className='btn d-block btn-success'>
						50 میلیون تومان
					</a>
				</Col>
			</Row>
			<Row className='text-center'>
				<Col sm={{ size: 12 }} md={{ size: 4 }}></Col>
				<Col sm={{ size: 12 }} md={{ size: 4 }}>
					<img src='assets/images/donation0.png' alt='حمایت مالی از پروژه کرامت به مبلغ مبلغ دلخواه' />
					<a href='https://zarinp.al/ravaqemehr.ir' target='_Blank' className='btn d-block btn-success'>
						مبلغ دلخواه
					</a>
				</Col>
				<Col sm={{ size: 12 }} md={{ size: 4 }}></Col>
			</Row>
		</>
	);
};

export default Donation;
