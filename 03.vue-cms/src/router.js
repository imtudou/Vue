//导入组件
import VueRouter from 'vue-router'

//自定义组件
import home from './components/tabbar/HomeContainer.vue'
import member from './components/tabbar/MemberContainer.vue'
import shopingcar from './components/tabbar/ShopingcarContainer.vue'
import search from './components/tabbar/SearchContainer.vue'




//创建路由对象
var router = new VueRouter({
    routes: [//定义路由,配置路由规则
        {path:'/',redirect:'/home'},//默认首页
        { path: '/home', component: home },
        { path: '/member', component: member },
        { path: '/shopingcar', component: shopingcar },
        { path: '/search', component: search }
    ],
    linkActiveClass: 'mui-active'//覆盖路由默认高亮的类rotuer-link-active
})

//把路由对象暴露出去
export default router