<template>
    <v-dialog persistent transition="dialog-bottom-transition" max-width="350" v-model="dialog">
        <template v-slot:activator="{ on, attrs }">
            <v-btn v-bind="attrs" v-on="on" elevation="1">
                <v-icon> 
                    mdi-bank-transfer
                </v-icon>
            </v-btn>
        </template>

        <template>
            <v-card class="text-center pa-6" elevation="2" mx-auto width="350">
                <div class="mb-1 text-left">
                    <strong>De: </strong>
                </div>

                <div class="mb-1">
                    <strong>Conta: </strong>{{ data.tipoConta }}
                </div>

                <div class="mb-1">
                    <strong>Nome: </strong>{{ data.nome }}
                </div>

                <div class="mb-1 text-left">
                    <strong>Para: </strong>
                </div>

                <v-text-field class="mt-6" label="Número da conta" solo placeholder="Número da conta" v-model="viewModel.sendToAccount"></v-text-field>

                <div class="mb-1 text-left">
                    <strong>Valor: </strong>
                </div>

                <v-text-field class="mt-6" label="Valor de transferência" solo placeholder="Valor de transferência" v-model="viewModel.valor"></v-text-field>

                <v-btn class="mr-4 primary" v-on:click="sendTransferir()">
                    Transferir
                </v-btn>

                <v-btn class="error" @click="dialog = false">
                    Voltar
                </v-btn>
            </v-card>
        </template>
    </v-dialog>
</template>

<script>
import Account from '../services/accounts.js';

export default {
  name: "TransferirDialog",

  props: {
      data: Object,
  },

  data() {
    return {
        viewModel: {
            account: this.data,
            action: "transferir",
            updatedNome: this.data.nome,
            updatedTipoConta: this.data.tipoConta
        },
        dialog: false,
    };
  },

  methods: {
      sendTransferir() {
          Account.updateAccount(this.data.id, this.viewModel)
            .then((response) => {                
                this.data.saldo = response.data.account.saldo;

                let acc = {
                    id: response.data.toAccount.id,
                    saldo: response.data.toAccount.saldo
                };

                this.$emit('newSaldo', acc);

                this.dialog = false;
                
            });
      }
  }
};
</script>