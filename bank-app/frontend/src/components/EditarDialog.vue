<template>
    <v-dialog persistent transition="dialog-bottom-transition" max-width="350" v-model="dialog">
        <template v-slot:activator="{ on, attrs }">
            <v-btn v-bind="attrs" v-on="on" elevation="1">
                <v-icon> 
                    mdi-account-edit-outline
                </v-icon>
            </v-btn>
        </template>

        <template>
            <v-card class="text-center pa-6" elevation="2" mx-auto width="350">
                <v-container>
                    <v-row>
                        <v-text-field label="Nome" required v-model="viewModel.updatedNome"></v-text-field>
                        <v-select label="Selecione" :items="tipoConta" v-model="viewModel.updatedTipoConta"></v-select>
                    </v-row>
                </v-container>

                <v-btn class="mr-4 primary" @click="sendEditar()"> 
                    Salvar
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
  name: "DepositarDialog",

  props: {
      data: Object,
  },

  data() {
    return {
        viewModel: {
            account: this.data,
            action: 'editar'
        },
        tipoConta: ["Física", "Jurídica"],
        dialog: false,
    };
  },

  methods: {
      sendEditar() {
          Account.updateAccount(this.data.id, this.viewModel)
            .then((response) => {
                this.data.tipoConta = response.data.account.tipoConta;
                this.data.nome = response.data.account.nome;
                this.dialog = false;
            });
      }
  }
};
</script>