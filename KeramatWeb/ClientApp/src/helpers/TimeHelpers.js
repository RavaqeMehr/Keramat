import dayjs from 'dayjs';

export const daysAgo = (date) => dayjs(date).fromNow();

export const faDate = (date, showTime = false, timeOnNewLine = false) => {
	const _date = dayjs(date).calendar('jalali');
	if (showTime) {
		if (timeOnNewLine) {
			return (
				<>
					{_date.format('HH:mm:ss')}
					<br />
					<small>{_date.format('YYYY/MM/DD')}</small>
				</>
			);
		} else {
			return _date.format(showTime ? 'YYYY/MM/DD-HH:mm:ss' : 'YYYY/MM/DD');
		}
	} else {
		return _date.format('YYYY/MM/DD');
	}
};
