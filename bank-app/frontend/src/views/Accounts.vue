<template>
  <v-container class="text-center mt-10">
    <v-simple-table>
      <template v-slot:default>
        <thead>
          <tr>
            <th class="text-center">Name</th>
            <th class="text-center">Calories</th>
            <th class="text-center">Edit</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in desserts" :key="item.id">
            <td class="text-center">{{ item.name }}</td>
            <td class="text-center">{{ item.calories }}</td>
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
            name: 'Frozen Yogurt',
            calories: 159,
          },
          {
            id: 1,
            name: 'Ice cream sandwich',
            calories: 237,
          },
          {
            id: 2,
            name: 'Eclair',
            calories: 262,
          },
          {
            id: 3,
            name: 'Cupcake',
            calories: 305,
          },
          {
            id: 4,
            name: 'Gingerbread',
            calories: 356,
          },
          {
            id: 5,
            name: 'Jelly bean',
            calories: 375,
          },
          {
            id: 6,
            name: 'Lollipop',
            calories: 392,
          },
          {
            id: 7,
            name: 'Honeycomb',
            calories: 408,
          },
          {
            id: 8,
            name: 'Donut',
            calories: 452,
          },
          {
            id: 9,
            name: 'KitKat',
            calories: 518,
          },
        ],
      }
    }
  }
</script>
