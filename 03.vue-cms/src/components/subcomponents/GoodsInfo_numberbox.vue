<template>
  <div class="mui-numbox" data-numbox-min="1" :data-numbox-max="this.maxcount">
    <button class="mui-btn mui-btn-numbox-minus" type="button">-</button>
    <input class="mui-input-numbox" type="number" value="1"  @change="numberChange" ref="numbox"  />
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
    props:['maxcount'],
    mounted(){
      debugger
      //初始化数字选择框
      mui('.mui-numbox').numbox();
      console.log(this.maxcount)
    },
    methods: {
      numberChange(){
        console.log(this.$refs.numbox.value);
        //子组件向父组件传值 通过 this.$emit
        this.$emit('getnumber',parseInt(this.$refs.numbox.value));

      }
      
    },
    // watch: {
    //   "maxcount":function(newVal,oldVal){
    //     debugger
    //     console.log(newVal);
    //     mui('.mui-numbox').numbox().setOption('max',newVal);

    //   }
    // },
}
</script>