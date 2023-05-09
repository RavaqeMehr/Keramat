import React from 'react';
import { faDate } from '../../helpers/TimeHelpers';
import { daysAgo } from './../../helpers/TimeHelpers';

const MyDateTime = ({ dateTime }) => (
	<>
		{faDate(dateTime)} <small>[{daysAgo(dateTime)}]</small>
	</>
);

export default MyDateTime;
