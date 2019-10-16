//入口文件


alert('ok'); 


import Vue from 'vue'
//import Vue from '../node_modules/vue/dist/vue'




// var login = {
//     template:'<h1>login组件</h1>'

// }
//导入 login 组件

import login from './login.vue'


//exprot default 用法
import cc,{title,titlessss}  from  './test.js'
console.log(cc);
console.log(title+"--------"+titlessss);

var vm = new Vue({
    el:'#app',
    data:{
        msg:'webapck打包'   
    },
    // components:{
    //     login:login
    // }
    // render:function(createElements){//在vue中想要把一个组件放到页面上去 需要使用render 函数
    //     return createElements(login);
    // }
    render:c => c(login)
})


