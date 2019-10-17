


<template>
  <div class="app_container">
    <!--顶部区域-->
    <mt-header fixed title="固定在顶部"></mt-header>

    <!--中间区域-->
    <h1>中间区域 内容部分</h1>

    <!--底部区域-->
    <nav class="mui-bar mui-bar-tab">
      <router-link class="mui-tab-item" to="/home">
        <span class="mui-icon mui-icon-home"></span>
        <span class="mui-tab-label">首页</span>
      </router-link>
      <router-link class="mui-tab-item" to="/member">
        <span class="mui-icon mui-icon-extra mui-icon-extra-prech">
        </span>
        <span class="mui-tab-label">会员</span>
      </router-link>
      <router-link class="mui-tab-item" to="/shopingcar">
        <span class="mui-icon mui-icon-extra mui-icon-extra-cart">
             <span class="mui-badge">0</span>  
        </span>
        <span class="mui-tab-label">购物车</span>
      </router-link>
      <router-link class="mui-tab-item" to="/search">
        <span class="mui-icon mui-icon-search"></span>
        <span class="mui-tab-label">搜索</span>
      </router-link>
    </nav>

  </div>
</template>


<style scoped>
.app_container {
  padding-top: 40px;
}
</style>


 
<script>
</script>
