<template>
  <v-container class="text-center pa-10" fluid>
    <v-simple-table>
      <template v-slot:default>
        <thead>
          <tr>
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
          <tr v-for="item in desserts" :key="item.id">
            <td class="text-center">{{ item.tipoConta }}</td>
            <td class="text-center">{{ item.nome }}</td>
            <td class="text-center">{{ item.saldo }}</td>
            <td class="text-center">{{ item.credito }}</td>
            <td class="text-center">
              <v-btn router-link :to="{ name: 'Sacar', params: {id: item.id } }" elevation="1">
                  <v-icon>
                    mdi-bank-transfer-out
                  </v-icon>
              </v-btn>
            </td>
            <td class="text-center">
              <v-btn router-link :to="{ name: 'Depositar', params: {id: item.id } }" elevation="1">
                  <v-icon>
                    mdi-bank-transfer-in
                  </v-icon>
              </v-btn>
            </td>
            <td class="text-center">
              <v-btn router-link :to="{ name: 'Transferir', params: {id: item.id } }" elevation="1">
                  <v-icon>
                    mdi-bank-transfer
                  </v-icon>
              </v-btn>
            </td>
            <td class="text-center">
              <v-btn router-link :to="{ name: 'Edit', params: {id: item.id } }" elevation="1">
                  <v-icon>
                    mdi-account-edit-outline
                  </v-icon>
              </v-btn>
            </td>
          </tr>
        </tbody>
      </template>
    </v-simple-table>
  </v-container>
</template>

<script>
  export default {
    name: 'Accounts',

    data() {
      return {
        desserts: [
          {
            id: 0,
            tipoConta: 'Pessoa Jurídica',
            nome: 'Frozen Yogurt',
            saldo: 12530.00,
            credito: 500.00
          },
          {
            id: 1,
            tipoConta: 'Pessoa Jurídica',
            nome: 'Ice cream sandwich',
            saldo: 14280.00,
            credito: 300.00
          },
          {
            id: 2,
            tipoConta: 'Pessoa Física',
            nome: 'Eclair',
            saldo: 1800.00,
            credito: 250.00
          }
        ],
      }
    }
  }
</script>
