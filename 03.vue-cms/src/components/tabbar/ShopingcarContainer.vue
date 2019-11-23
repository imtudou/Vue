<!--购物车组件-->
<template>
  <div class="shoopingcar-container">
    <div class="gooslist">
      <!-- 商品列表区域 -->
      <div class="mui-card" v-for="item in this.shoppingcarList" :key="item.id">
        <div class="mui-card-content">
          <div class="mui-card-content-inner">
          <mt-switch></mt-switch>
          <img :src="item.imgUrl">
          <div class="info">
              <h1>{{ item.title}}</h1> 
              <p>
                  <span class="price">￥{{item.price}}</span>
                  <numbox :initcount="numBoxValue[item.id]" :goodsid="item.id"></numbox>
                  <a href="#">删除</a>
                  
              </p>
              
          </div>
          </div>
        </div>
      </div>

      <!-- 結算区域 -->
      <div class="mui-card">
        <div class="mui-card-content">
          <div
            class="mui-card-content-inner"
          >这是一个最简单的卡片视图控件；卡片视图常用来显示完整独立的一段信息，比如一篇文章的预览图、作者信息、点赞数量等</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import numbox from '../subcomponents/Shopcar_numberbox.vue';
export default {
    components:{
        numbox
    },
    created() {
        console.log(this.numBoxValue);
        console.log(this.shoppingcarList);
 
    },
    data() {
        return {
            shoppingcarList:this.$store.state.shoppingcar,
            numBoxValue:this.$store.getters.getNumBoxValue

        }
    },
    
    methods: {
        
    },



}



</script>

<style lang="scss" scope>
.shoopingcar-container{
    background-color: #eee;
    overflow: hidden;
    .gooslist{
        .mui-card-content-inner{
            display: flex;
            align-items: center;
        }
        img{
            width: 60px;height: 60px;
        }
        h1{
            font-size: 13px;
        }
        .info{
            display:flex;
            flex-direction: column;
            justify-content: space-between;
            .price{
                color: red;
            }
             
    
        }
    }

}
    
</style> 