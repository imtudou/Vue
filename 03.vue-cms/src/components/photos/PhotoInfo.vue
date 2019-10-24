<template>
  <div class="photoinfo_container">
    <h3 class="photoinfo_title">标题</h3>
    <p class="photoinfo_subtitle">
      <span>发表时间:{{this.$route}}</span>
      <span>点击次数:0次</span>
    </p>
    <hr />
    <!--内容区域-->
    <div class="photoinfo_content"></div>
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
      PhotoInfoList: []
    };
  },
  methods: {},
  components: {//注册评论子组件
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
    color: #26A2FF;
  }
  .photoinfo_subtitle {
    font-size: 13px;
    color: #26a2ff;
    display: flex;
    justify-content: space-between;
  }
  .photoinfo_content{
    font-size: 13px;
    line-height: 30px;

  }

 

}
</style>