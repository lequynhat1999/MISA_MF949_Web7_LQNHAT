import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import { ValidationProvider, ValidationObserver, extend } from 'vee-validate'; 
import * as rules from 'vee-validate/dist/rules';
import { messages } from 'vee-validate/dist/locale/vi.json';
import Toast from "vue-toastification";
import "vue-toastification/dist/index.css";
import DatePicker from 'vue2-datepicker';
import 'vue2-datepicker/index.css';
import Paginate from 'vuejs-paginate'

const options = {
  // You can set your default options here
  position: 'bottom-right'
};


Vue.use(Toast, options);

Object.keys(rules).forEach(rule => {
  extend(rule, {
    ...rules[rule], // copies rule configuration
    message: messages[rule] // assign message
  });
});
// Register it globally
Vue.component('ValidationProvider', ValidationProvider);
Vue.component('ValidationObserver', ValidationObserver);
Vue.component('paginate', Paginate)
Vue.config.productionTip = false
Vue.component('datepicker', DatePicker)
Vue.use(VueAxios, axios)
new Vue({
  render: h => h(App),
}).$mount('#app')
