import { http } from './config.js';

export default {
    findAllAccounts: async () => {
        return await http.get('accounts');
    }
}