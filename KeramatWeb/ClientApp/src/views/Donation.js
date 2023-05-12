import React, { useState } from 'react';
import { Row, Col, Alert } from 'reactstrap';
import InputSelect from '../components/form/InputSelect';

const donationLinks = [
	{
		imgSrc: 'assets/images/donation1.png',
		imgAlt: 'حمایت مالی از پروژه کرامت به مبلغ 1 میلیون تومان',
		aHref: 'https://zarinp.al/499712',
		aTitle: 'پرداخت 1 میلیون تومان',
	},
	{
		imgSrc: 'assets/images/donation2.png',
		imgAlt: 'حمایت مالی از پروژه کرامت به مبلغ 2 میلیون تومان',
		aHref: 'https://zarinp.al/499720',
		aTitle: 'پرداخت 2 میلیون تومان',
	},
	{
		imgSrc: 'assets/images/donation5.png',
		imgAlt: 'حمایت مالی از پروژه کرامت به مبلغ 5 میلیون تومان',
		aHref: 'https://zarinp.al/499722',
		aTitle: 'پرداخت 5 میلیون تومان',
	},
	{
		imgSrc: 'assets/images/donation10.png',
		imgAlt: 'حمایت مالی از پروژه کرامت به مبلغ 10 میلیون تومان',
		aHref: 'https://zarinp.al/499723',
		aTitle: 'پرداخت 10 میلیون تومان',
	},
	{
		imgSrc: 'assets/images/donation20.png',
		imgAlt: 'حمایت مالی از پروژه کرامت به مبلغ 20 میلیون تومان',
		aHref: 'https://zarinp.al/499724',
		aTitle: 'پرداخت 20 میلیون تومان',
	},
	{
		imgSrc: 'assets/images/donation50.png',
		imgAlt: 'حمایت مالی از پروژه کرامت به مبلغ 50 میلیون تومان',
		aHref: 'https://zarinp.al/499725',
		aTitle: 'پرداخت 50 میلیون تومان',
	},
	{
		imgSrc: 'assets/images/donation0.png',
		imgAlt: 'حمایت مالی از پروژه کرامت به مبلغ دلخواه',
		aHref: 'https://zarinp.al/ravaqemehr.ir',
		aTitle: 'پرداخت مبلغ دلخواه',
	},
];

const Donation = () => {
	const [form, formSet] = useState(donationLinks[0].imgSrc);

	let currentItem = donationLinks.find((x) => x.imgSrc == form);
	return (
		<>
			<Alert color='warning' className='text-center'>
				با توجه به اینکه کرامت یک پروژه Open Source، رایگان و عام‌المنفعه است؛ بابت تهیه و استفاده آن نیاز به
				پرداخت هزینه نیست. اما در صورت تمایل به مشارکت در این امر خیر می‌توانید از حامیان مالی این پروژه باشید
				و در برکات آن شریک شوید.
			</Alert>

			<Row className='text-center' dir='ltr'>
				<Col sm={{ size: 12 }} md={{ size: 6, offset: 3 }} dir='rtl'>
					<Alert color='info'>
						<InputSelect
							id='doantionSelect'
							label='مبلغ مورد نظر'
							value={form}
							onChange={formSet}
							items={donationLinks.map((x) => ({ id: x.imgSrc, text: x.aTitle }))}
						/>
					</Alert>
				</Col>
			</Row>
			<Row className='text-center' dir='ltr'>
				<Col sm={{ size: 12 }} md={{ size: 4, offset: 4 }} dir='rtl'>
					<img src={currentItem.imgSrc} alt={currentItem.imgAlt} />
					<a href={currentItem.aHref} target='_Blank' className='btn d-block btn-success'>
						{currentItem.aTitle}
					</a>
				</Col>
			</Row>
		</>
	);
};

export default Donation;
