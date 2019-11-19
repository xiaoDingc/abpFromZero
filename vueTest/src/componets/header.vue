<template lang="">
    <div>
        我是头标题{{msg}} {{title}}
        {{this.$store.state.count}}
        <button @click="testEvent()">点我传值</button>
        <ul>
            <li v-for="(item,index) of list" :key="index">
                {{item.name}}
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
                list: [{ categoryName: "C1" }, { categoryName: "C2" }]
            }
        },
        store,
        props: ['title'],
        mounted() {
            var url = 'http://localhost:53195/api/services/app/Poet/GetPagedPoets';
            let data = {
                "skipCount": 0,
                "maxResultCount": 10
            };
            this.axios.post(url, data)
                .then(res => {
                    this.list = res.data.result.items;
                    console.log(res.data.result.items)
                }

                );
        },
        methods: {
            testEvent() {

                // vueEvent.$emit("to-End",this.msg);
                this.$store.commit('incre');
                console.log("点击完成")
            }
        }
    }
</script>