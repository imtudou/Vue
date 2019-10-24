<template>
  <div class="photoinfo_container">
    <h3 class="photoinfo_title">标题</h3>
    <p class="photoinfo_subtitle">
      <span>发表时间:{{createTime}}</span>
      <span>点击次数:{{clickNumber}}次</span>
    </p>
    <hr />
    <!--内容区域-->
    <div class="photoinfo_content">
      <vue-preview :slides="SwipeList"></vue-preview>
    </div>
    <!--评论子组件区域-->
    <comment-box></comment-box>
  </div>
</template>

<script>
import { Toast } from "mint-ui";

//导入子组件
import comment from "../subcomponents/Comment.vue";

export default {
  data() {
    return {
      PhotoInfoList: [],
      categoryID: this.$route.query.id,
      clickNumber: this.$route.query.clickNumber,
      createTime: this.$route.query.createTime,
      SwipeList:[
          {
            src: 'https://farm4.staticflickr.com/3894/15008518202_b016d7d289_b.jpg',
            msrc: 'https://farm4.staticflickr.com/3894/15008518202_b016d7d289_m.jpg',
            w: 1200,
            h: 900
          },
          {
            src: 'https://farm4.staticflickr.com/3920/15008465772_383e697089_b.jpg',
            msrc: 'https://farm4.staticflickr.com/3920/15008465772_383e697089_m.jpg',
            w: 1200,
            h: 900
          }]
    };
  },
  methods: {
    //获取缩略图
 
  },
  components: {
    //注册评论子组件
    "comment-box": comment
  }
};
</script>


<style lang="scss" scoped>
.photoinfo_container {
  padding: 0 5px;
  margin-bottom: 15px;
  .photoinfo_title {
    font-size: 16px;
    text-align: center;
    margin: 15px 0;
    color: #26a2ff;
  }
  .photoinfo_subtitle {
    font-size: 13px;
    color: #26a2ff;
    display: flex;
    justify-content: space-between;
  }
  .photoinfo_content {
    font-size: 13px;
    line-height: 30px;
  }
}
</style>