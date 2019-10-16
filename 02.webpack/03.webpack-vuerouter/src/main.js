import Vue from 'vue'

//1.导入路由
import VueRouter from 'vue-router'
//2.手动安装 vueRouter
Vue.use(VueRouter)

//导入mint-ui
// import MintUI from 'mint-ui';
// import 'mint-ui/lib/style.css'
// Vue.use(MintUI)
// import { Button } from 'mint-ui';
// Vue.component(Button.name, Button);

//按照需要导入mint-ui
import { Button } from 'mint-ui';
Vue.component(Button.name, Button);




import app from './App.vue'
//抽离路由模块
import router from './router.js'





var vm = new Vue({
    el: '#app',
    render: c => c(app),
    router: router//4.将路由对象挂载到 vm身上



})