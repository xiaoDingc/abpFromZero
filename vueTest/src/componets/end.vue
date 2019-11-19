<template lang="">
    <div>
    {{title}}
    {{go}}
    <button @click="run">父传值测试</button>
    {{this.$store.state.count}}
    </div>
</template>
<script>
import vueEvent from '../Event/vueEvent';
import store from '../store.js'
export default {
    data(){
        return{
            go:'ttooo',
        }
    },
    store,
    mounted() {
        vueEvent.$on(("to-End"),function(data){
            console.log(data+"1234");
        });
    },
    methods: {
        run(){
            console.log(this.$parent.title);
            this.$store.commit('incre');
        }
    },
    props:['title']
}
</script>