<template>
  <div>
    <ul class="mui-table-view">
      <li class="mui-table-view-cell mui-media" v-for="item in NewsList" :key="item.ID">
        <a href="javascript:;">
          <img class="mui-media-object mui-pull-left" :src="item.ImgUrl" />
          <div class="mui-media-body">
            {{item.Title}}
            <p class="mui-ellipsis">{{item.Memo}}</p>
            <p class="mui-ellipsis">
              <span>发表时间:{{item.CreateTime }}</span>
              <!-- 此处的时间后端已经处理好了不必再前端重新格式 -->
              <!-- <span>发表时间:{{item.CreateTime | dateFormat('YYYY-MM-DD')}}</span> -->
              <span class="custome-css-p-span">浏览:{{item.ClickNumber}} 次</span>
            </p>
          </div>
        </a>
      </li>
    </ul>
  </div>
</template>

<script>
import { Toast } from "mint-ui";

export default {
  data() {
    return {
      //   msg: "新闻列表",
      NewsList: []
    };
  },
  created() {
    this.GetNewsList();
  },
  methods: {
    GetNewsList() {
      //http://94.191.121.125:8082/api/Resources/GetNewsList
      let url = "api/Resources/GetNewsList";
      this.$http.get(url).then(result => {
        if (result.body.code == 200) {
          this.NewsList = JSON.parse(result.body.data);
          
        } else {
          Toast("失败！");
        }
      });
    }
  }
};
</script>

<style  scoped>
.custome-css-p-span{
    margin-left: 5%;
}
</style>