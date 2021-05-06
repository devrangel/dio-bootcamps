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
            <td class="text-center">
              <SacarDialog :data="item"/>
            </td>
            <td class="text-center">
              <DepositarDialog :data="item"/>
            </td>
            <td class="text-center">
              <TransferirDialog :data="item" v-on:newSaldo="toAccount = $event"/>
            </td>
            <td class="text-center">
              <EditarDialog :data="item" />
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
      toAccount: Object,
    }
  },

  watch: {
    toAccount: function(obj) {
      let hasAccountIndex = this.accounts.findIndex(account => account.id === obj.id);

      if(hasAccountIndex !== -1) {
        this.accounts[hasAccountIndex].saldo = obj.saldo;
      } else {
          console.log("Não encontrado");
      }
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
