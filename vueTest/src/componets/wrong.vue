<template>
    <div>

        <el-input type="textarea" autosize placeholder="请输入内容" v-model="textarea2">
        </el-input>
        <div style="margin: 20px 0;"></div>
        <el-input type="textarea" :autosize="{ minRows: 2, maxRows: 4}" placeholder="请输入内容" v-model="textarea3">
        </el-input>
        <el-button type="primary" :loading="true">{{textarea3}}</el-button>
        <div class="block">
            <span class="demonstration">hover 触发子菜单</span>
            <el-cascader expand-trigger="hover" :options="options" v-model="selectedOptions2" @change="handleChange">
            </el-cascader>
        </div>

    </div>
</template>

<script>
    export default {
        data: () => ({
            show: true,
            textarea2: '',
            textarea3: '',
            options: [
                {
                    value: 'zhinan',
                    label: '指南',
                    children: [{
                        value: 'shejiyuanze',
                        label: '设计原则',
                        children: [{
                            value: 'yizhi',
                            label: '一致'
                        }, {
                            value: 'fankui',
                            label: '反馈'
                        }, {
                            value: 'xiaolv',
                            label: '效率'
                        }, {
                            value: 'kekong',
                            label: '可控'
                        }]
                    }, {
                        value: 'daohang',
                        label: '导航',
                        children: [{
                            value: 'cexiangdaohang',
                            label: '侧向导航'
                        }, {
                            value: 'dingbudaohang',
                            label: '顶部导航'
                        }]
                    }]
                }],
            selectedOptions: [],
            selectedOptions2: []
        })
    }
</script>

<style>
    .transition-box {
        margin-bottom: 10px;
        width: 200px;
        height: 100px;
        border-radius: 4px;
        background-color: #409EFF;
        text-align: center;
        color: #fff;
        padding: 40px 20px;
        box-sizing: border-box;
        margin-right: 20px;
    }
</style>