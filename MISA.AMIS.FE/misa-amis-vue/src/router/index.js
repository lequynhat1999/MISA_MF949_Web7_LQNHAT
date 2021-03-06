import Vue from 'vue'
import VueRouter from 'vue-router'
import Employee from "../view/EmployeeList.vue";
import Overview from "../view/Overview.vue";

Vue.use(VueRouter)
const routes = [
    { path: '/overview',name:"Overview", component: Overview},
    { path: '/employee',name:"Employee", component: Employee },
  ]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes,
    linkActiveClass: "menu-active", 
    linkExactActiveClass: "menu-active" 
})

export default router