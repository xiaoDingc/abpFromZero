import Vue from 'vue'
import App from './App.vue'

import axios from 'axios'
import Qs from 'qs'
//QS是axios库中带的，不需要我们再npm安装一个

Vue.prototype.axios = axios;
Vue.prototype.qs = Qs;


import VueRouter from 'vue-router'
Vue.use(VueRouter)



import Header from './componets/header'
import End from './componets/end'
import testEnd from './componets/testend'



const routes = [{
    path: '/Header',
    component: Header
  },
  {
    path: '/End',
    component: End
  },
  {
    path: '/testEnd',
    component: testEnd,
  } ,{
    path: '/*',
    component: Header,
  },
]
var router=new VueRouter({
  mode:'history',
  routes
});

new Vue({
  el: '#app',
  router,
  render: h => h(App)
})
