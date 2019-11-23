<!--购物车组件-->
<template>
  <div class="shoopingcar-container">
    <div class="gooslist">
      <!-- 商品列表区域 -->
      <div class="mui-card" v-for="(item,index) in this.shoppingcarList" :key="item.id">
        <div class="mui-card-content">
          <div class="mui-card-content-inner">
            <mt-switch
              v-model="IsSelected[item.id]"
              @change="SelectedChange(item.id,IsSelected[item.id])"
            ></mt-switch>
            <img :src="item.imgUrl" />
            <div class="info">
              <h1>{{ item.title}}</h1>
              <p>
                <span class="price">￥{{item.price}}</span>
                <numbox :initcount="numBoxValue[item.id]" :goodsid="item.id"></numbox>
                <a href="#" @click.prevent="Remove(item.id,index)">删除</a>
              </p>
            </div>
          </div>
        </div>
      </div>

      <!-- 結算区域 -->
      <div class="mui-card">
        <div class="mui-card-content">
          <div class="mui-card-content-inner jiesuan">
            <div class="left">
              <p>总计(不含运费)</p>
              <p>
                已勾选商品
                <span class="numprie">{{$store.getters.getCountAndAmount.count}}</span>件,总价 ￥
                <span class="numprie">{{$store.getters.getCountAndAmount.amount}}</span>
              </p>
            </div>
            <mt-button type="danger">去结算</mt-button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import numbox from "../subcomponents/Shopcar_numberbox.vue";
export default {
  components: {
    numbox
  },
  created() {
    console.log(this.numBoxValue);
    console.log(this.shoppingcarList);
  },
  data() {
    return {
      shoppingcarList: this.$store.state.shoppingcar,
      numBoxValue: this.$store.getters.getNumBoxValue,
      IsSelected: this.$store.getters.getGoodsInfoSelect
    };
  },

  methods: {
    //删除购物车中的商品信息
    Remove(id, index) {
      //删除 shoppingcarList 数组中的数据
      this.shoppingcarList.splice(index, 1);

      //删除state 中的数据
      this.$store.commit("RemoveFromShoppingcar", id);
    },
    //监听mt-switch 事件并更新store中商品选中状态
    SelectedChange(id, ischecked) {
      this.$store.commit("GoodsInfoIsSelected", {id:id,ischecked:ischecked});
    
      
    }
  }
};
</script>

<style lang="scss" scope>
.shoopingcar-container {
  background-color: #eee;
  overflow: hidden;
  .gooslist {
    .mui-card-content-inner {
      display: flex;
      align-items: center;
    }
    img {
      width: 60px;
      height: 60px;
    }
    h1 {
      font-size: 13px;
    }
    .info {
      display: flex;
      flex-direction: column;
      justify-content: space-between;
      .price {
        color: red;
      }
    }
  }

  .jiesuan {
    display: flex;
    justify-content: space-between;
    align-items: center;
    .numprie {
      color: red;
      font-weight: bold;
      font-size: 16px;
    }
  }
}
</style> 