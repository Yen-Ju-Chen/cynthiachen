import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

//  套件
import ViewUI from 'view-design';
import locale from 'view-design/dist/locale/zh-TW'
// UI CSS
import 'view-design/dist/styles/iview.css';
// import VCalendar from 'v-calendar';
import VueApexCharts from 'vue-apexcharts'

Vue.config.productionTip = false
// Vue.use(VCalendar)
// UI設定
Vue.use(ViewUI, {
  locale
})
Vue.use(VueApexCharts)
Vue.component('apexchart', VueApexCharts)
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
