import dayjs from 'dayjs';

export const daysAgo = date => dayjs(date).fromNow();

export const faDate = date =>
  dayjs(date).calendar('jalali').format('YYYY/MM/DD');
