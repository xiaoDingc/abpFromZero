import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)

var state = {
  count: 0,
}
var mutations = {
  incre() {
    state.count++;
  },
  decre(state, n = 0) {
    state.count -= n;
  }
}
var actions = {
  decre(context, n = 0) {
    context.commit("decre", n)
  }
}
const store = new Vuex.Store({
  state,
  mutations: mutations,
  actions: actions,
})
export default store;
