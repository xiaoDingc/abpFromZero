import Vue from 'vue'
import App from './App.vue'
import store from "./store"
import axios from 'axios'
import Qs from 'qs'


import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
//QS是axios库中带的，不需要我们再npm安装一个
Vue.use(ElementUI)

Vue.prototype.axios = axios;
Vue.prototype.qs = Qs;


import VueRouter from 'vue-router'
Vue.use(VueRouter)


import Header from './componets/header'
import End from './componets/end'
import testEnd from './componets/testend'
import wrong from './componets/wrong'

const routes = [{
    path: '/Header',
    component: Header,
    meta: {
      login: true,
    }
  },
  {
    path: '/End',
    component: End,
    meta: {
      login: false,
    }
  },
  {
    path: '/testEnd',
    component: testEnd,
    meta: {
      login: false,
    }
  },
  {
    path: '/error',
    component: wrong,
    meta: {
      login: true,
    }
  },
  {
    path: '/*',
    component: Header,
    meta: {
      login: true,
    }
  },

]
var router = new VueRouter({
  mode: 'history',
  routes
});
router.beforeEach((to, from, next) => {
  console.log("to :" + to.meta.login);
  console.log("from :" + from);
  if (to.meta.login)
    next();
  else {
    // alert("过不去了吧")
    to.meta.login = true;
    next('/error');
  }
});
new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})
