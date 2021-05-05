<template>
    <v-dialog persistent transition="dialog-bottom-transition" max-width="350" v-model="dialog">
        <template v-slot:activator="{ on, attrs }">
            <v-btn v-bind="attrs" v-on="on" elevation="1">
                <v-icon> 
                    mdi-bank-transfer-out
                </v-icon>
            </v-btn>
        </template>

        <template>
            <v-card class="text-center pa-6" elevation="2" mx-auto width="350">
                <div class="mb-1">
                    <strong>Conta: </strong>{{ data.tipoConta }}
                </div>

                <div class="mb-1">
                    <strong>Nome: </strong>{{ data.nome }}
                </div>

                <div class="mb-1">
                    <strong>Saldo: </strong>{{ data.saldo }}
                </div>

                <div class="mb-1">
                    <strong>Crédito: </strong>{{ data.credito }}
                </div>

                <v-text-field class="mt-6" label="Valor do saque" solo placeholder="Valor do saque" v-model="viewModel.valor"></v-text-field>

                <v-btn class="mr-4 primary" @click="sendSaque()"> 
                    Sacar
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
  name: "SacarDialog",

  props: {
      data: Object,
  },

  data() {
    return {
        viewModel: {
            account: this.data,
            action: 'sacar'
        },
        dialog: false,
    };
  },

  methods: {
      sendSaque() {
          Account.updateAccount(this.data.id, this.viewModel)
            .then((response) => {
                this.data.saldo = response.data.account.saldo;
                this.dialog = false;
            });
      }
  }
};
</script>