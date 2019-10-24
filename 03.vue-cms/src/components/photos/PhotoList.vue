<template>
  <div>
    <!-- 顶部滑动区域 开始-->
    <div id="slider" class="mui-slider">
      <div
        id="sliderSegmentedControl"
        class="mui-scroll-wrapper mui-slider-indicator mui-segmented-control mui-segmented-control-inverted"
      >
        <div class="mui-scroll">
          <a
            :class="['mui-control-item',item.id == 0 ? 'mui-active':''] "
            v-for="item in CategoryList"
            :key="item.id"
            @click="GetPhotoListByCategoryID(item.id)"
          >{{item.categoryName}}</a>
        </div>
      </div>
    </div>
    <!-- 顶部滑动区域 结束-->

    <!-- 图片列表 开始-->
    <ul class="photo-list">
      <router-link
        v-for="item in PhotoList"
        :key="item.id"
        tag="li"
        :to="'/home/photoinfo?id='+ item.id+'&clickNumber='+item.clickNumber+'&createTime='+item.createTime"
      >
        <img v-lazy="item.imgUrl" />
        <div class="info">
          <h3 class="info-title">{{item.title}}</h3>
          <div class="info-body">{{item.summary}}</div>
        </div>
      </router-link>
    </ul>
    <!-- 图片列表 结束-->
  </div>
</template>


<script>
import mui from "../../../lib/mui/js/mui.min.js";
import { Toast, Indicator } from "mint-ui";

export default {
  data() {
    return {
      CategoryList: [], //图片类型
      PhotoList: [] //图片列表
    };
  },
  mounted() {
    //当组件中的 dom 结构渲染好并放到页面中后  会执行这个钩子函数
    mui(".mui-scroll-wrapper").scroll({
      deceleration: 0.0005 //flick 减速系数，系数越大，滚动速度越慢，滚动距离越小，默认值0.0006
    });
  },
  created() {
    this.GetCategoryList();

    this.GetPhotoListByCategoryID(0);
  },
  methods: {
    //获取图片类别
    GetCategoryList() {
      let url = "api/Resources/GetPhotoCategory";
      this.$http.get(url).then(result => {
        if (result.body.code == 200) {
          this.CategoryList = result.body.data;
        } else {
          Toast("失败！");
        }
      });
    },
    //获取图片列表
    GetPhotoListByCategoryID(CategoryID) {
      Indicator.open("加载中...");
      let url =
        "api/Resources/GetPhotoListByCategoryID?CategoryID=" + CategoryID;
      setTimeout(() => {
        this.$http.get(url).then(result => {
          if (result.body.code == 200) {
            this.PhotoList = result.body.data;
            Indicator.close();
          } else {
            Toast("失败！");
          }
        });
      }, 500);
    }
  }
};
</script>



<style lang="scss" scoped>
* {
  touch-action: pan-y;
}

.photo-list {
  margin: 0;
  padding: 10px;
  padding-bottom: 0;
  list-style: none;
  li {
    background-color: #ccc;
    text-align: center;
    margin-top: 10px;
    box-shadow: 0 0 9px #999;
    position: relative;
    img {
      width: 100%;
      height: 100%;
      vertical-align: middle;
    }
  }
  img[lazy="loading"] {
    width: 40px;
    height: 300px;
    margin: auto;
  }

  .info {
    color: white;
    text-align: left;
    position: absolute;
    bottom: 0;
    background-color: rgba(0, 0, 0, 0.4);
    max-height: 84px;
    .info-title {
      font-size: 14px;
    }
    .info-body {
      font-size: 13px;
    }
  }
}
</style>
