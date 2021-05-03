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
                        <v-text-field label="Nome" required v-model="data.nome"></v-text-field>
                        <v-autocomplete label="Selecione" :items="tipoConta" :value="tipoConta[contaValue]"></v-autocomplete>
                    </v-row>
                </v-container>

                <v-btn class="mr-4 primary"> 
                    Editar
                </v-btn>

                <v-btn class="error" @click="dialog = false">
                    Voltar
                </v-btn>
            </v-card>
        </template>
    </v-dialog>
</template>

<script>
export default {
  name: "DepositarDialog",

  props: {
      data: Object,
  },

  data() {
    return {
        tipoConta: ["Física", "Jurídica"],
        contaValue: this.data.tipoContaValue,
        dialog: false,
    };
  },
};
</script>