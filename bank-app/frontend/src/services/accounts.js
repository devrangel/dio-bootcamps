import { http } from './config.js';

export default {
    findAllAccounts: async () => {
        return await http.get('accounts');
    },

    updateAccount: async (id, viewModel) => {
        return await http.put(`accounts/${id}`, viewModel);
    },

    deletarAccount: async (id) => {
        return await http.delete(`accounts/${id}`);
    }
}