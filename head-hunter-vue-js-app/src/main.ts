import { createApp } from 'vue'
import Antd from 'ant-design-vue'
import VueApexCharts from 'vue3-apexcharts'
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faGithub } from '@fortawesome/free-brands-svg-icons'
import { faArrowUp, faLocationDot } from '@fortawesome/free-solid-svg-icons'
import App from './App.vue'
import router from './router'
import store from './store'

library.add(faGithub, faArrowUp, faLocationDot)

import 'ant-design-vue/dist/antd.css'
import './assets/styles/oswald.css'
import './assets/styles/app.scss'
import './assets/styles/app.css'

createApp(App).use(store).use(router).use(Antd).use(VueApexCharts).component('font-awesome-icon', FontAwesomeIcon).mount('#app')
