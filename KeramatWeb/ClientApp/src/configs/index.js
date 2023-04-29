import React from 'react';
import AfterConfig from './AfterConfig';
import BeforeConfig from './BeforeConfig';
import ConfigAxios from './ConfigAxios';

const Configs = () => {
	return (
		<>
			<BeforeConfig />

			<ConfigAxios />

			<AfterConfig />
		</>
	);
};

export default Configs;
