//导入组件

import VueRouter from 'vue-router'
import account from './main/Account.vue'
import goodlist from './main/GoodList.vue'

//导入 Account 下的子组件
import login from './main/SubComponent/login.vue'
import register from './main/SubComponent/register.vue'


//3.创建路由对象
var router = new VueRouter({
    routes: [//定义路由
        {
            path: '/account', 
            component: account,
            children:[
                {path:'login',component:login},
                {path:'register',component:register}
            ]
        },
        { path: '/goodlist', component: goodlist },

    ]
})



//把路由对象暴露出去
export default router