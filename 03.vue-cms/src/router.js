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
import goodslist from './components/goods/GoodsList.vue';
import goodsinfo from './components/goods/GoodsInfo.vue';
import goodsinfodesc from './components/goods/GoodsInfo_Desc.vue';
import goodsinfocomment from './components/goods/GoodsInfo_Comment.vue';





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
        { path:'/home/goodslist',component:goodslist},
        { path:'/home/goodsinfo',component:goodsinfo},
        { path:'/home/goodsinfodesc',component:goodsinfodesc,name:'goodsinfodesc'},
        { path:'/home/goodsinfocomment',component:goodsinfocomment,name:'goodsinfocomment'}
    ],
    linkActiveClass: 'mui-active'//覆盖路由默认高亮的类rotuer-link-active
})



//把路由对象暴露出去
export default router