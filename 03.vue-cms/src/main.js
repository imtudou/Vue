console.log("~~~~~~hahahahahahhaha~~~~~");
console.log("无敌小土豆:");
import DateTime from './Helper/DateTimeHelper.js';
console.log(DateTime.Now());

console.log("www.imtudou.cn");
console.log("~~~~~~hahahahahahhaha~~~~~");





//入口文件
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);
import router from './router.js'

//vue-resource
import VueResource from 'vue-resource';
Vue.use(VueResource);

//Vuex
import Vuex from 'vuex';
Vue.use(Vuex);
var store = new Vuex.Store({
    state: {//this.$store.state.xxx
        shoppingcar: JSON.parse(localStorage.getItem('shoppingcar') || '[]') //存储购物车中商品的数据

    },
    mutations: {//this.$store.mutations.xxx
        //点击加入购物车把商品信息保存到 shoppingcar[] 中
        addToShoopingcar(state, goodsinfo) {
            //判断若重复添加只加对应商品数量即可
            let flag = state.shoppingcar.some(item => {
                if (item.id == goodsinfo.id) {
                    item.count += parseInt(goodsinfo.count)
                    return true;
                }
            })

            if (!flag)
                state.shoppingcar.push(goodsinfo);

            localStorage.setItem('shoppingcar', JSON.stringify(state.shoppingcar));



        },
        //修改购物车中商品数量同步到store中
        updateGoodsInfo(state, goodsinfo) {
            state.shoppingcar.some(item => {
                if (item.id == goodsinfo.id) {
                    item.count = parseInt(goodsinfo.count);
                    return true;

                }
            })
            localStorage.setItem('shoppingcar', JSON.stringify(state.shoppingcar));
        },

        //删除购物车中国商品数据同步到 store中
        RemoveFromShoppingcar(state, id) {
            state.shoppingcar.some((item, index) => {
                if (item.id == id) {
                    state.shoppingcar.splice(index, 1);
                }
            })
            localStorage.setItem('shoppingcar', JSON.stringify(state.shoppingcar));
        },
        GoodsInfoIsSelected(state,obg){
            state.shoppingcar.some((item) => {
                if (item.id == obg.id) {
                    item.ischecked = obg.ischecked
                }
            })
            localStorage.setItem('shoppingcar', JSON.stringify(state.shoppingcar));

        }

    },
    getters: {//this.$store.getters.xxx

        //购物车徽标数量取值
        getAllCount(state) {
            let c = 0;
            state.shoppingcar.forEach(item => {
                c += item.count;
            })
            return c;
        },
        //获取购物车numbox 的值
        getNumBoxValue(state) {
            let obj = {};
            state.shoppingcar.forEach(item => {
                obj[item.id] = item.count
            })
            return obj;
        },
        //获取商品添加都购物车后是否选中
        getGoodsInfoSelect(state){
            let obj = {};
            state.shoppingcar.forEach(item=>{
                obj[item.id] = item.ischecked;
            })
            return obj;
        },
        //结算区域计算总数和总价
        getCountAndAmount(state){
            let obj = {count:0,amount:0}
            state.shoppingcar.forEach(item=>{
                if(item.ischecked)
                {
                    obj.count += item.count;
                    obj.amount += (item.price * item.count);

                }
            })
            return obj;
        }
    }
});



//引入第三方组件,样式
//1.1 Mint-UI

import 'mint-ui/lib/style.css';
import MintUI from 'mint-ui';
Vue.use(MintUI);
// import { Header, Swipe, SwipeItem,Button,Lazyload } from 'mint-ui';
// Vue.component(Header.name, Header);
// //轮播图
// Vue.component(Swipe.name, Swipe);
// Vue.component(SwipeItem.name, SwipeItem);
// Vue.component(Button.name,Button );

//注意：此处按需导入 懒加载 效果无法出现，需改成全部导入 mint-ui
// //懒加载
// Vue.use(Lazyload);


//1.2 MUI
import '../lib/mui/css/mui.min.css'
import '../lib/mui/css/icons-extra.css'

//工具插件
import moment from 'moment';
//工具插件  图片预览
import VuePreview from 'vue-preview';
Vue.use(VuePreview);




//引入自定义组件
import app from './App.vue';






//全局配置信息
//http://94.191.121.125:8082/api/Resources/GetSwipe

//1.配置全局根地址：
Vue.http.options.root = 'http://47.95.243.55:8082/';
//2.配置post 提交方式 emulateJSON = true
Vue.http.emulateJSON = true;


//配置全局过滤器
Vue.filter('dateFormat', function (dateStr, parameters = 'YYYY-MM-DD HH:mm:ss') {
    return moment(dateStr, parameters);
});


var vm = new Vue({
    el: '#app',
    data: {

    },
    methods: {

    },
    render: c => c(app),
    router: router,
    store: store
});