import React, { useState } from 'react';
import { Accordion, AccordionBody, AccordionHeader, AccordionItem } from 'reactstrap';

const MyAccordion = ({ headers, defaultOpenIndex = 0, headersClassName, bodiesClassName, children }) => {
	const [open, openSet] = useState('' + defaultOpenIndex);

	const toggle = (id) => {
		if (open === id) {
			openSet();
		} else {
			openSet(id);
		}
	};

	return (
		<Accordion open={open} toggle={toggle}>
			{children.map((x, i) =>
				x ? (
					<AccordionItem key={i}>
						<AccordionHeader targetId={'' + i} className={headersClassName}>
							{headers ? headers[i] ?? i : i}
						</AccordionHeader>
						<AccordionBody accordionId={'' + i} className={bodiesClassName}>
							{x}
						</AccordionBody>
					</AccordionItem>
				) : null
			)}
		</Accordion>
	);
};

export default MyAccordion;
