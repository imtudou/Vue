<!--首页组件-->
<template>
  <div>
    <!--轮播-->
    <swipe :SwipeList="SwipeList"></swipe>


    <!--九宫格-->
    <ul class="mui-table-view mui-grid-view mui-grid-9">
      <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
        <router-link to="/home/newslist">
          <span class="mui-icon mui-icon-home"></span>
          <div class="mui-media-body">新闻资讯</div>
        </router-link>
      </li>
      <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
        <router-link to="/home/photolist">
          <span class="mui-icon mui-icon-extra mui-icon-extra-share"></span>
          <div class="mui-media-body">图片分享</div>
        </router-link>
      </li>
      <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
        <router-link to="/home/goodslist">
          <span class="mui-icon mui-icon-extra mui-icon-extra-cart"></span>
          <div class="mui-media-body">商品购买</div>
        </router-link>
      </li>
      <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
        <a href="#">
          <span class="mui-icon mui-icon-location"></span>
          <div class="mui-media-body">留言反馈</div>
        </a>
      </li>
      <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
        <a href="#">
          <span class="mui-icon mui-icon-extra mui-icon-extra-computer"></span>
          <div class="mui-media-body">视频专区</div>
        </a>
      </li>
      <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
        <a href="#">
          <span class="mui-icon mui-icon-phone"></span>
          <div class="mui-media-body">联系我们</div>
        </a>
      </li>
    </ul>
  </div>
</template>

<script>
import { Toast, Indicator } from "mint-ui";
import swipe from '../subcomponents/Swipe.vue';

export default {
  created() {
    Indicator.open("加载中...");
    setTimeout(() => {
      //获取轮播图信息
      this.GetSwipe();
    }, 500);
  },
  data() {
    return {
      SwipeList: []
    };
  },
  methods: {
    GetSwipe() {
      let url = "api/Resources/GetSwipe";
      this.$http.get(url).then(result => {
        if (result.body.code == 200) {
          this.SwipeList = JSON.parse(result.body.data);
          Indicator.close();
        } else {
          Toast("失败");
        }
      });
    }
  },
  components:{
    swipe
  }
};
</script>

<style  scoped>

.mint-swipe-item:nth-child(1) {
  background-color: red;
}
.mint-swipe-item:nth-child(2) {
  background-color: pink;
}
.mint-swipe-item:nth-child(3) {
  background-color: cyan;
}
/* img {
  width: 100%;
  height: 100%;
} */

.mui-grid-view.mui-grid-9 {
  background-color: white;
}
.mui-grid-view.mui-grid-9 .mui-table-view-cell {
  border: 0;
}
</style>