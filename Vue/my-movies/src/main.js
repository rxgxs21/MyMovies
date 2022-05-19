import Vue from 'vue'
import  Vuelidate from 'vuelidate'
import 'bootstrap/dist/css/bootstrap.min.css'
import App from './App.vue'
import store from './store'

Vue.use(Vuelidate)
Vue.config.productionTip = false

new Vue({
  store,
  render: h => h(App)
}).$mount('#app')
