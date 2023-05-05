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

	const items = Array.isArray(children) ? children.filter((x) => x) : [children];

	return (
		<Accordion open={open} toggle={toggle}>
			{items.map((x, i) => (
				<AccordionItem key={i}>
					<AccordionHeader targetId={'' + i} className={headersClassName}>
						{headers ? headers[i] ?? i : i}
					</AccordionHeader>
					<AccordionBody accordionId={'' + i} className={bodiesClassName}>
						{x}
					</AccordionBody>
				</AccordionItem>
			))}
		</Accordion>
	);
};

export default MyAccordion;
