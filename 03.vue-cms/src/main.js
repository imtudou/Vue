//入口文件
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);
import router from './router.js'

//vue-resource
import VueResource from 'vue-resource'
Vue.use(VueResource)



//引入第三方组件,样式
//1.1 Mint-UI
import 'mint-ui/lib/style.css';
import { Header, Swipe, SwipeItem,Button} from 'mint-ui';
Vue.component(Header.name, Header);
//轮播图
Vue.component(Swipe.name, Swipe);
Vue.component(SwipeItem.name, SwipeItem);
Vue.component(Button.name,Button );


//1.2 MUI
import '../lib/mui/css/mui.min.css'
import '../lib/mui/css/icons-extra.css'

//工具插件
import moment from 'moment';




//引入自定义组件
import app from './App.vue';





//全局配置信息
//http://94.191.121.125:8082/api/Resources/GetSwipe

//1.配置全局根地址：
Vue.http.options.root = 'http://94.191.121.125:8082/';
//2.配置post 提交方式 emulateJSON = true
Vue.http.emulateJSON = true;


//配置全局过滤器
Vue.filter('dateFormat',function(dateStr,parameters = 'YYYY-MM-DD HH:mm:ss'){   
    return moment(dateStr,parameters);
});


var vm = new Vue({
    el: '#app',
    data:{

    },
    methods: {
        
    },
    render: c => c(app),
    router: router
});