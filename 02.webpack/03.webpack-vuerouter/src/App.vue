<template>
  <div>
    <h1>这是 app 组件</h1>
    <router-link to="/account">Account</router-link>
    <router-link to="/goodlist">GoodList</router-link>
    <router-view></router-view>

    <mt-button type="primary">primary</mt-button>
    <mt-button type="danger" @click="show">danger</mt-button>
  </div>
</template>


 
<script>
import { Toast } from "mint-ui";

export default {
  data() {
    return {};
  },
  methods: {
    getList(){

    },
    show() {
      Toast({
        message: "操作成功",
        iconClass: "icon icon-success"
      });
    }
  }
};
</script>
 




<style>
</style>