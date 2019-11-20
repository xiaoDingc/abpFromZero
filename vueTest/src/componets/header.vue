<template lang="">
    <div>
        我是头标题{{msg}} {{title}}
        {{this.$store.state.count}}
        <button @click="testEvent()">点我加1</button>
        <button @click="testDec()">点我-1</button>
        <ul>
            <li v-for="(item,index) of list" :key="index">
                {{item.name}}
            </li>
        </ul>
        <ul>
            <li v-for="(item,index) of categorys" :key="index">
                    {{item.categoryName}}
            </li>
        </ul>
    </div>
</template>
<script>
    import vueEvent from '../Event/vueEvent'
    import store from '../store.js'
    import { axios } from "axios";
    export default {
        data() {
            return {
                msg: 'this is msg',
                list: [],
                categorys:[],
            }
        },
        store,
        props: ['title'],
        mounted() {
            var url = 'http://localhost:57407/api/services/app/Poet/GetPagedPoets';
            let data = {
                "skipCount": 0,
                "maxResultCount": 10
            };
            this.axios.post(url, data)
                .then(res => {
                    this.list = res.data.result.items;
                }
                );
        },
        methods: {
            testEvent() {
                let url="http://localhost:57407/api/services/app/Poet/GetAllCategories";
                this.axios.post(url)
                .then(res=>{
                    console.log(res);
                    this.categorys=res.data.result.items;
                })
                // vueEvent.$emit("to-End",this.msg);
                this.$store.commit('incre');
                console.log("点击完成")
            },
            testDec(){
                //this.$store.commit("decre",5);
                this.$store.dispatch("decre",3);
            }
        }
    }
</script>