<template>
  <div>
    {{msg}}
    <button @click="runTest()">测试一下跳转</button>
    <ul v-for="(list, index) in lists" :key="index">
      <li>{{list.name}}</li>
    </ul>
  </div>
</template>
<script>
  import { axios } from "axios";
  export default {
    data() {
      return {
        msg: "this is child msg",
        lists: [{
          id: 10,
          name: 'toto'
        },
        {
          id: 11,
          name: 'toto10'
        },
        {
          id: 12,
          name: 'toto12'
        },
        ]
      }
    },
    methods: {
      getRes() {
        var a = 1;
        var b = 2;
        return a + b;
      },
      runTest() {
        this.$router.push({ path: '/end' })
      }
    },

  }
</script>