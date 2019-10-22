<template>
  <div>
    <ul class="mui-table-view">
      <li class="mui-table-view-cell mui-media" v-for="item in NewsList" :key="item.ID">
        <router-link :to="'/home/newsinfo?id=' + item.ID">
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
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
import { Toast, Indicator } from "mint-ui";

export default {
  data() {
    return {
      //   msg: "新闻列表",
      NewsList: []
    };
  },
  created() {
    Indicator.open("加载中...");
    setTimeout(() => {
      this.GetNewsList();
    }, 500);
    
  },
  methods: {
    GetNewsList() {
      //http://94.191.121.125:8082/api/Resources/GetNewsList
      let url = "api/Resources/GetNewsList";
      this.$http.get(url).then(result => {
        if (result.body.code == 200) {
          this.NewsList = JSON.parse(result.body.data);
          Indicator.close();
        } else {
          Toast("失败！");
        }
      });
    }
  }
};
</script>

<style  scoped>
.custome-css-p-span {
  margin-left: 5%;
}
</style>