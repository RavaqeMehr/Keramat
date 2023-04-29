import axios from 'axios';
import * as consts from '../consts';

const ConfigAxios = () => {
	axios.defaults.baseURL = consts.apiUrl;

	return null;
};

export default ConfigAxios;
