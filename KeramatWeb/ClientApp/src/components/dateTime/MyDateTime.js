import React from 'react';
import { faDate } from '../../helpers/TimeHelpers';
import { daysAgo } from './../../helpers/TimeHelpers';

const MyDateTime = ({ dateTime, showTime = false, timeOnNewLine = false, showTimeAgo = true }) => (
	<>
		{faDate(dateTime, showTime, timeOnNewLine)} {showTimeAgo ? <small>[{daysAgo(dateTime)}]</small> : null}
	</>
);

export default MyDateTime;
