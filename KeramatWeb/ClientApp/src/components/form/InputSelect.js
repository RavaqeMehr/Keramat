import React from 'react';
import { Input, Label } from 'reactstrap';

const InputSelect = ({
	id,
	label,
	description,
	onChange,
	value,
	hint,
	readOnly = false,
	valid = false,
	invalid = false,
	items,
}) => {
	return (
		<div className='mb-3'>
			<Label for={id} className='mb-0'>
				<strong>{label}</strong> {description && <small className='text-primary'>{description}</small>}
			</Label>
			<Input
				id={id}
				type='select'
				onChange={(val) => onChange(val.target.value)}
				value={value ?? ''}
				readOnly={readOnly}
				valid={valid}
				invalid={invalid}
				bsSize='sm'>
				{items
					? items.map((x, i) => (
							<option key={i} value={x.id}>
								{x.text}
							</option>
					  ))
					: null}
			</Input>
			{hint && <small className='text-info'>{hint}</small>}
		</div>
	);
};

export default InputSelect;
