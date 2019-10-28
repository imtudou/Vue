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
import DateTime from '../../Helper/DateTimeHelper.js';

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
      //非空校验
      if (this.contentsss.trim().length == 0) {
        Toast("非法字符！");
      } else { 
        Indicator.open();
        var commentModel = {};
        commentModel.id = this.total++;
        commentModel.content = this.contentsss;
        commentModel.createTime = DateTime.Now();
        commentModel.userName = "匿名用户" + commentModel.id;
        //发起网络请求
        let url = "api/Resources/SaveComment";
        this.$http
          .post(url, JSON.stringify(commentModel), {})
          .then(result => {
            if (result.body.code == 200) {
              setTimeout(() => {
                Indicator.close();
                this.CommentList.unshift(result.body.data);
                this.contentsss = "";
                Toast("发表成功！");
              }, 100);
            }
          })
          .catch(err => {});
      }
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