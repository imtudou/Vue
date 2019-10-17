//入口文件
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);
import router from './router.js'



//引入第三方组件,样式
//Mint-UI
import 'mint-ui/lib/style.css';
import { Header } from 'mint-ui';
Vue.component(Header.name, Header);

//MUI
import '../lib/mui/css/mui.min.css'
import '../lib/mui/css/icons-extra.css'

 

//引入自定义组件
import app  from './App.vue';



var vm = new Vue({
    el:'#app',
    render:c=>c(app),
    router:router



});