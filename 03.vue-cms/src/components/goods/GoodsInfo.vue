<template>
  <div class="goodsinfo-container">
    <!-- 小球 -->
    <transition @before-enter="beforeEnter" @enter="enter" @after-enter="afterEnter">
      <div class="ball" v-show="ballFlag" ref="ball"></div>
    </transition>

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
            <numberbox @getnumber="getSelectedNumber" :maxcount="goodscount"></numberbox>
          </p>
          <p>
            <mt-button type="primary" size="small">立即购买</mt-button>
            <mt-button type="danger" size="small" @click="addShoppingCar">加入购物车</mt-button>
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
          <p>库存情况：{{this.goodscount}}</p>
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
      ballFlag: false, //控制小球是否显示
      SwipeList: [],
      num:1,
      goodscount:123,//模拟设置库存数量

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
        name: "goodsinfodesc",
        params: { detailid: id }
      });
    },
    GoGoodsInfoComment(id) {
      this.$router.push({
        name: "goodsinfocomment",
        params: { id }
      });
    },
    addShoppingCar() {
      this.ballFlag = !this.ballFlag;
    },


    /**
     * 涉及到小球动画相关的方法
     */
    beforeEnter(el) {
      //设置小球开始动画前的起始位置
      el.style.transform = "translate(0,0)";
    },
    enter(el, done) {
      //offsetWidth 强制动画刷新  没有实际意义 （注意：不写这句话没有动画效果）
      el.offsetWidth;
      //enter 标识动画开始之后的样式 这里可以设置小球完成动画之后的结束状态

      //获取小球位置
      const ballPosition = this.$refs.ball.getBoundingClientRect();
      //获取徽标位置
      const badgePosition = document.getElementById('badgeball').getBoundingClientRect();
      const x = badgePosition.left - ballPosition.left;
      const y = badgePosition.top - ballPosition.top;
      console.log('x:'+x+',y:'+y);
      
      
      el.style.transform = `translate(${x}px,${y}px)`;



      //这里的done 就是afterEnter这个函数
      //el.style.transform = "all 1s ease"
      el.style.transition = "all 1s cubic-bezier(0.68,-0.55,0.27,0.55)";
      done();
    },
    afterEnter(el) {
      this.ballFlag = !this.ballFlag;
    },
    //获取购买数量
    getSelectedNumber(number){
      this.num = number;
      console.log('this.num:'+this.num);
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

  //小球
  .ball {
    width: 15px;
    height: 15px;
    border-radius: 50%;
    background-color: red;
    position: absolute;
    z-index: 99;
    left: 150px;
    top: 420px;
  }
}
</style>