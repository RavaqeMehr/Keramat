import React from 'react';
import { Alert } from 'reactstrap';

const AboutApp = () => {
	return (
		<>
			<Alert color='info' className='text-center'>
				<strong>کرامت</strong> یک پروژه Open Source یا همان متن‌باز است که توسط شرکت <strong>رواق مهر</strong>
				، جهت بهره‌برداری به صورت عام‌المنفعه طراحی گردیده است. شما نیز می‌توانید با معرفی و انتشار این پروژه
				در برکات آن سهیم باشید.
			</Alert>
			<Alert color='warning' className=''>
				<h4>تکنولوژی‌های اصلی به کار رفته در این پروژه:</h4>
				<ul>
					<li>Microsoft Asp.Net</li>
					<li>Microsoft Entity Framework Core</li>
					<li>Sqlite</li>
					<li>React</li>
					<li>Bootstrap</li>
				</ul>
				در صورتی که تمایل و تخصص در این زمینه‌ها دارید، می‌توانید با ایجاد Fork از این پروژه و ثبت تغییرات به
				صورت Commit و ارسال به صورت Pull Request در توسعه آن مشارکت داشته باشید.
			</Alert>
			<Alert color='info' className=''>
				<h4>لینک‌های مفید:</h4>
				<ul>
					<li>
						<a href='https://github.com/RavaqeMehr/Keramat' target='_Blank'>
							مخزن پروژه در گیت‌هاب
						</a>
					</li>
					<li>
						<a href='https://github.com/RavaqeMehr/Keramat/releases' target='_Blank'>
							دریافت آخرین نسخه
						</a>
					</li>
					<li>
						<a href='https://github.com/RavaqeMehr/Keramat/graphs/contributors' target='_Blank'>
							توسعه‌دهندگان
						</a>
					</li>
					<li>
						<a href='https://github.com/RavaqeMehr/Keramat/issues' target='_Blank'>
							اشکالات
						</a>
					</li>
					<li>
						<a href='https://github.com/RavaqeMehr/Keramat/commits/master' target='_Blank'>
							لیست و جزئیات آخرین تغییرات
						</a>
					</li>
					<li>
						<a href='https://github.com/RavaqeMehr/Keramat/issues' target='_Blank'>
							لیست پکیج‌ها و ابزارهای شخص ثالث
						</a>
					</li>
				</ul>
			</Alert>
		</>
	);
};

export default AboutApp;
