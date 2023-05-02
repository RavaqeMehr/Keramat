import React from 'react';
import { FormGroup, Input, Label } from 'reactstrap';

const InputSwitch = ({
	id,
	label,
	description,
	onChange,
	check = false,
	hint,
	readOnly = false,
	valid = false,
	invalid = false,
}) => {
	return (
		<FormGroup switch disabled={readOnly}>
			<Label for={id} check>
				<strong>{label}</strong> {description && <small className='text-primary'>{description}</small>}
			</Label>
			<Input
				id={id}
				type='switch'
				role='switch'
				checked={check}
				onClick={() => onChange(!check)}
				valid={valid}
				invalid={invalid}
				onChange={() => {}}
			/>

			{hint && (
				<small className='text-info'>
					<br />
					{hint}
				</small>
			)}
		</FormGroup>
	);
};

export default InputSwitch;
