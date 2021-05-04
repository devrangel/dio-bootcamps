<template>
  <v-container class="text-center pa-10" fluid>
    <v-simple-table>
      <template v-slot:default>
        <thead>
          <tr>
            <th class="text-center">Número</th>
            <th class="text-center">Conta</th>
            <th class="text-center">Nome</th>
            <th class="text-center">Saldo</th>
            <th class="text-center">Crédito</th>
            <th class="text-center">Sacar</th>
            <th class="text-center">Depositar</th>
            <th class="text-center">Transferir</th>
            <th class="text-center">Editar</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in accounts" :key="item.id">
            <td class="text-center">{{ item.id }}</td>
            <td class="text-center">{{ item.tipoConta }}</td>
            <td class="text-center">{{ item.nome }}</td>
            <td class="text-center">{{ item.saldo }}</td>
            <td class="text-center">{{ item.credito }}</td>
            <td class="text-center">
              <SacarDialog :data="item"/>
            </td>
            <td class="text-center">
              <DepositarDialog :data="item"/>
            </td>
            <td class="text-center">
              <TransferirDialog :data="item"/>
            </td>
            <td class="text-center">
              <EditarDialog :data="item"/>
            </td>
          </tr>
        </tbody>
      </template>
    </v-simple-table>
  </v-container>
</template>

<script>
import SacarDialog from '@/components/SacarDialog.vue';
import DepositarDialog from '@/components/DepositarDialog.vue';
import TransferirDialog from '@/components/TransferirDialog.vue';
import EditarDialog from '@/components/EditarDialog.vue';

import Account from '../services/accounts.js';

export default {
  name: 'Accounts',

  components: {
    SacarDialog,
    DepositarDialog,
    TransferirDialog,
    EditarDialog,
  },

  data() {
    return {
      accounts: [],
    }
  },

  mounted() {
    Account.findAllAccounts()
      .then(res => {
        this.accounts = res.data;
      })
      .catch(err => {
        console.error("Não foi possível carregar as contas");
      });
  }
}
</script>
