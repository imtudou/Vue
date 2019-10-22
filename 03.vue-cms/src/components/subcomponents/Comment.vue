<template>
  <div class="cmt-container">
    <h3>发表评论</h3>
    <hr />
    <textarea placeholder="请输入要吐槽的文字，最多120字" maxlength="120" v-model="contentsss"></textarea>
    <mt-button type="primary" size="large" @click="SaveComment">发表评论</mt-button>
    <div class="cmt-list" v-for="item in CommentList" :key="item.id">
      <div class="cmt-item">
        <div
          class="cmt-title"
        >第{{item.id}}楼&nbsp;&nbsp;用户：{{item.userName}}&nbsp;&nbsp;发表时间：{{item.createTime}}</div>
        <div class="cmt-body">{{item.content}}</div>
      </div>
    </div>

    <mt-button type="danger" size="large" plain @click="LoadMore">加载更多</mt-button>
  </div>
</template>


<script>
import { Toast, Indicator } from "mint-ui";

export default {
  data() {
    return {
      pageIndex: 0,
      CommentList: [],
      contentsss: "",
      total: 0
    };
  },
  created() {
    Indicator.open("加载中...");
    setTimeout(() => {
      this.GetComment();
    }, 1000);
  },
  methods: {
    GetComment() {
      let url = "api/Resources/GetComment?pageIndex=" + this.pageIndex;
      this.$http
        .get(url)
        .then(result => {
          if (result.body.code == 200) {
            this.total = result.body.total;
            this.CommentList = this.CommentList.concat(result.body.data);
            Indicator.close();
          } else {
            Toast("失败！");
          }
        })
        .catch(err => {});
    },

    //
    //加载更多
    //
    LoadMore() {
      this.pageIndex++;
      Indicator.open("加载中...");
      setTimeout(() => {
        this.GetComment();
      }, 1000);
    },
    //
    //发表评论
    //
    SaveComment() {

      Indicator.open();
      var commentItem = {};
      commentItem.id = this.total++ ;
      commentItem.content = this.contentsss;
      commentItem.createTime = new Date().toISOString();
      commentItem.userName = "匿名用户" + commentItem.id;
      this.CommentList.unshift(commentItem);
      this.contentsss == "";
      setTimeout(() => {
        Indicator.close();
        Toast("保存成功！");    
      }, 500);
    }
  }
};
</script>


<style lang="scss" scoped>
.cmt-container {
  h3 {
    font-size: 18px;
  }
  textarea {
    font-size: 14px;
    height: 85px;
    margin: 0;
  }

  .cmt-list {
    margin: 5px 0;

    .cmt-item {
      font-size: 13px;
      .cmt-title {
        line-height: 30px;
        background-color: #cccccc;
      }
      .cmt-body {
        line-height: 35px;
        text-indent: 2em;
      }
    }
  }
}
</style>