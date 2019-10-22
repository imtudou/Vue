<template>
  <div class="newsinfo_container">
    <h3 class="title">{{NewsInfoList.title}}</h3>
    <p class="subtitle">
      <span>发表时间:{{NewsInfoList.createTime}}</span>
      <span>点击次数:{{NewsInfoList.clickNumber}}</span>
    </p>
    <hr />
    <!--内容区域-->
    <div class="content" v-html="NewsInfoList.contents"></div>
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
      msg: "新闻详情",
      id: this.$route.query.id,
      NewsInfoList: {}
    };
  },
  created() {
    this.GetNewsInfoByID();
  },
  methods: {
    GetNewsInfoByID(id) {
      //http://94.191.121.125:8082/api/Resources/GetNewsInfoByID?id=2
      let url = "api/Resources/GetNewsInfoByID?id=" + this.id;
      this.$http
        .get(url)
        .then(result => {
          if (result.body.code == 200) {
            this.NewsInfoList = result.body.data;
          }
        })
        .catch(err => {});
    }
  },
  components: {
    "comment-box": comment
  }
};
</script>


<style lang="scss"  scope>
.newsinfo_container {
  padding: 0 5px;
  margin-bottom: 15px;
  .title {
    font-size: 16px;
    text-align: center;
    margin: 15px 0;
    color: red;
  }
  .subtitle {
    font-size: 13px;
    color: #26a2ff;
    display: flex;
    justify-content: space-between;
  }
  .content {
    .pic {
      img {
        width: 100%;
        height: 100%;
      }
    }
  }
}
</style>