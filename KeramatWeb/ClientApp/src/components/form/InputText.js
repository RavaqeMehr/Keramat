import React from 'react';
import { Input, Label } from 'reactstrap';

const InputText = ({
	id,
	label,
	description,
	onChange,
	maxLength,
	placeHolder,
	value,
	hint,
	readOnly = false,
	valid = false,
	invalid = false,
	multiLine = false,
}) => {
	return (
		<div className='mb-3'>
			<Label for={id} className='mb-0'>
				<strong>{label}</strong> {description && <small className='text-primary'>{description}</small>}
			</Label>
			<Input
				id={id}
				placeholder={placeHolder}
				type={multiLine ? 'textarea' : 'text'}
				onChange={(val) => onChange(val.target.value)}
				value={value ?? ''}
				maxLength={maxLength}
				readOnly={readOnly}
				valid={valid}
				invalid={invalid}
				bsSize='sm'
			/>
			{hint && <small className='text-info'>{hint}</small>}
		</div>
	);
};

export default InputText;
