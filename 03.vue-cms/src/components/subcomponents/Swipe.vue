
<template>
  <div>
    <mt-swipe :auto="4000">
      <mt-swipe-item v-for="item in SwipeList" :key="item.ID">
        <img :src="item.Url" />
      </mt-swipe-item>
    </mt-swipe>
  </div>
</template>


<script>
export default {
  props: ["SwipeList"]
};
</script>


<style lang = "scss" scoped>
.mint-swipe {
  height: 260px;
  img {
    height: 100%;
    width: 100%;
  }
}
</style>
