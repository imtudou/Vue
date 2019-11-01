<template>
  <div class="goodsinfo-container">
    <!-- 商品轮播区域 -->
    <div class="mui-card">
      <swipe :SwipeList="SwipeList"></swipe>
    </div>

    <!-- 商品购买区域 -->
    <div class="mui-card">
      <div class="mui-card-header">商品标题</div>
      <div class="mui-card-content">
        <div class="mui-card-content-inner">
          <p>
            <span>
              市场价：
              <del>2399元</del>
            </span>
            <span>销售价：2199元</span>
          </p>
          <p>
            购买数量：
            <numberbox></numberbox>
          </p>
          <p>
            <mt-button type="primary" size="small">立即购买</mt-button>
            <mt-button type="danger" size="small">加入购物车</mt-button>
          </p>
        </div>
      </div>
    </div>

    <!-- 商品参数区域 -->
    <div class="mui-card">
      <div class="mui-card-header">商品参数</div>
      <div class="mui-card-content">
        <div class="mui-card-content-inner">
          <p>商品编号：6789098765</p>
          <p>库存情况：2445</p>
          <p>上架时间：2019-10-28 17:29:34</p>
        </div>
      </div>
      <div class="mui-card-footer">
        <mt-button @click="GoGoodInfoDesc(id)" type="primary" size="large" plain>图文介绍</mt-button>
        <mt-button @click="GoGoodsInfoComment(id)" type="danger" size="large" plain>商品评论</mt-button>
      </div>
    </div>
  </div>
</template>



<script>
import { Toast, Indicator } from "mint-ui";
import swipe from "../../components/subcomponents/Swipe.vue";
import numberbox from "../../components/subcomponents/GoodsInfo_numberbox.vue";

export default {
  data() {
    return {
      id: this.$route.query.id,
      numbox: 1,
      SwipeList: []
    };
  },
  created() {
    Indicator.open("加载中...");
    setTimeout(() => {
      //获取轮播图信息
      this.GetSwipe();
    }, 500);
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
    },
    GoGoodInfoDesc(id) {
      this.$router.push({
        name: 'goodsinfodesc',
        params: { detailid:id }
      });
    },
    GoGoodsInfoComment(id) {
      this.$router.push({
        name: 'goodsinfocomment',
        params: { id }
      });
    }
  },
  components: {
    swipe,
    numberbox
  }
};
</script>



<style lang="scss" scoped>
.goodsinfo-container {
  background-color: #eee;
  overflow: hidden;

  .mui-card-footer {
    display: block;
    button {
      margin: 15px 0;
    }
  }
}
</style>