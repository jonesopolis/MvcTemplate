import axios from 'axios';

export default class {

    static get() {
        return axios.get('/api')
            .then(r => r.data)
            .catch(e => console.log(e));
    }
}