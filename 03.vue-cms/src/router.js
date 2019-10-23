//导入组件
import VueRouter from 'vue-router'

//自定义组件
import home from './components/tabbar/HomeContainer.vue'
import member from './components/tabbar/MemberContainer.vue'
import shopingcar from './components/tabbar/ShopingcarContainer.vue'
import search from './components/tabbar/SearchContainer.vue'
import newslist from './components/news/NewsList.vue';
import newsinfo from './components/news/NewsInfo.vue';
import photolist from './components/photos/PhotoList.vue';
import photoinfo from './components/photos/PhotoInfo.vue';





//创建路由对象
var router = new VueRouter({
    routes: [//定义路由,配置路由规则
        { path:'/',redirect:'/home'},//默认首页
        { path: '/home', component: home },
        { path: '/member', component: member },
        { path: '/shopingcar', component: shopingcar },
        { path: '/search', component: search },
        { path:'/home/newslist',component:newslist},
        { path:'/home/newsinfo',component:newsinfo},
        { path:'/home/photolist',component:photolist},
        { path:'/home/photoinfo',component:photoinfo},
    ],
    linkActiveClass: 'mui-active'//覆盖路由默认高亮的类rotuer-link-active
})



//把路由对象暴露出去
export default router