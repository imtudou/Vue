<template>
  <div class="goods-container">
    <router-link
      :to="'/home/goodsinfo?id='+item.id+'&nowPrice='+item.nowPrice+'&oldPrice='+item.oldPrice+'&imgUrl='+item.imgUrl+'&title='+item.title"
      tag="div"
      class="goods-item"
      v-for="item in GoodsList"
      :key="item.id"
    >
      <div class="img">
        <img :src="item.imgUrl" />
      </div>
      <div class="title">
        <h1>{{item.title}}</h1>
      </div>
      <div class="info">
        <p>
          <span class="nowprice">{{item.nowPrice}}元</span>
          <span class="oldprice">{{item.oldPrice}}元</span>
        </p>
        <p>
          <span>热卖中</span>
          <span>剩余{{item.num}}件</span>
        </p>
      </div>
    </router-link>

    <mt-button type="danger" size="large" @click="LoadMore">加载更多</mt-button>
  </div>
</template>



<script>
import { Toast, Indicator } from "mint-ui";
import { setTimeout } from "timers";

export default {
  data() {
    return {
      GoodsList: [],
      pageIndex: 0
    };
  },
  created() {
    Indicator.open("加载中...");
    setTimeout(() => {
      this.GetGoodsList();
    }, 500);
  },
  methods: {
    //商品列表数据源
    GetGoodsList() {
      let url = "api/Resources/GetGoodsList?pageIndex=" + this.pageIndex;
      this.$http
        .get(url)
        .then(result => {
          if (result.body.code == 200) {
            if (result.body.data.length > 0)
              this.GoodsList = this.GoodsList.concat(result.body.data);
            else Toast("当前已经是最后一页了！");

            Indicator.close();
          }
        })
        .catch(err => {});
    },
    //加载跟多
    LoadMore() {
      this.pageIndex++;
      Indicator.open("加载中...");
      setTimeout(() => {
        this.GetGoodsList();
      }, 1000);
    }
  }
};
</script>



<style lang="scss" scoped>
.goods-container {
  display: flex;
  flex-wrap: wrap;
  padding: 7px;
  justify-content: space-between;
  .goods-item {
    width: 49%;
    border: 1px solid #ccc;
    box-shadow: 0 0 8px #ccc;
    margin: 2px 0;
    padding: 2px;
    display: flex;
    flex-direction: column; //改变主轴方向 默认 row
    justify-content: space-between;
    min-height: 293px;
    img {
      width: 100%;
    }
    h1 {
      font-size: 14px;
    }

    .info {
      background-color: #eee;
      p {
        margin: 0;
        padding: 5px;
      }
      .nowprice {
        color: red;
        font-size: 16px;
      }
      .oldprice {
        text-decoration: line-through;
        color: #ccc;
        font-size: 12px;
        margin-left: 10px;
      }
      .sell {
        display: flex;
        justify-content: space-between;
        font-size: 13px;
      }
    }
  }
}
</style>