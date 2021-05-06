<template>
  <v-app-bar app color="primary" dark>
      <div class="d-flex flex-row align-center text-h5 mr-10">
         <v-icon router-link to="/" class="mr-2" large>
            mdi-home
         </v-icon>
         Bank App
      </div>

      <v-btn text router-link to="/">
        Home
      </v-btn>
      <v-btn text router-link to="/accounts">
        Accounts
      </v-btn>

      <v-spacer></v-spacer>

      <div>
        {{ new Date().getFullYear() }} - <strong>@devrangel</strong>
      </div>

  </v-app-bar>
</template>

<script>
export default {
  name: 'Header',
};
</script>
