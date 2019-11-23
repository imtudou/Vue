<template>
  <div class="mui-numbox" data-numbox-min="1"   style="height:30px">
    <button class="mui-btn mui-btn-numbox-minus" type="button">-</button>
    <input class="mui-input-numbox" type="number" :value="initcount"  @change="numberChange" ref="numbox" readonly  />
    <button class="mui-btn mui-btn-numbox-plus" type="button">+</button>
  </div>
</template>

<script>

import mui from "../../../lib/mui/js/mui.min.js";
export default {
    
    data(){
        return{

        }
    },
  
    mounted(){

      
      //初始化数字选择框
      mui('.mui-numbox').numbox();
      // console.log(this.maxcount)
      console.log(this.initcount)
    },
    methods: {
      numberChange(){
        // this.goodsid
        console.log(this.$refs.numbox.value)
        var goodsinfo = {id:this.goodsid,count:this.$refs.numbox.value};
        this.$store.commit("updateGoodsInfo",goodsinfo)
 

      }
      
    },
    // watch: {
    //   "maxcount":function(newVal,oldVal){
    //     debugger
    //     console.log(newVal);
    //     mui('.mui-numbox').numbox().setOption('max',newVal);

    //   }
    // },
    
    props:["initcount","goodsid"]
}
</script>


<style lang="scss" scope>


  
</style>