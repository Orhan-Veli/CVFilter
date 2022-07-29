import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Applicant from '../views/Applicant.vue'
import Edit from '../views/Edit'
const routes = [
  {
    path: '/Applicant',
    name: 'Applicant',
    component: Applicant
  },
  {
    path: '/Edit',
    name: 'Edit',
    component: Edit
  },
  {
    path: '/Home',
    name: 'Home',
    component: Home
  },
  { path: '/Home',name:'Home',component: () => import('../views/Home.vue') },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router