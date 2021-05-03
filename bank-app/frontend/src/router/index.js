import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Accounts from '../views/Accounts.vue'
import About from '../views/About.vue'
import Edit from '../views/Edit.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/accounts',
    name: 'Account',
    component: Accounts
  },
  {
    path: '/about',
    name: 'About',
    component: About
  },
  {
    path: '/edit/:id',
    name: 'Edit',
    component: Edit
  },
]

const router = new VueRouter({
  routes
})

export default router
