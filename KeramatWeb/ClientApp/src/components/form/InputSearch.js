import React from 'react';
import { Input } from 'reactstrap';

const InputSearch = ({
	onChange,
	maxLength,
	placeHolder = 'جستجو',
	value,
	readOnly = false,
	valid = false,
	invalid = false,
}) => {
	return (
		<div className='mb-0'>
			<Input
				placeholder={placeHolder}
				type={'text'}
				onChange={(val) => onChange(val.target.value)}
				value={value ?? ''}
				maxLength={maxLength}
				readOnly={readOnly}
				valid={valid}
				invalid={invalid}
				bsSize='sm'
			/>
		</div>
	);
};

export default InputSearch;
