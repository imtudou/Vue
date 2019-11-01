<template>
  <div class="goodsinfodesc_container">
    <span>图文介绍--{{this.detailid}}</span>
    <div v-for=" item in GoodsInfoDescList" :key="item.url">
      <img :src="item.url" />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      detailid: this.$route.params.detailid,
      GoodsInfoDescList: []
    };
  },
  created() {
    this.LoadGoodsInfoDesc();
  },
  methods: {
    LoadGoodsInfoDesc() {
      let url = "api/Resources/GetGoodsInfoDesc";
      this.$http
        .get(url)
        .then(result => {
          this.GoodsInfoDescList = result.body.data;
        })
        .catch(err => {});
    }
  }
};
</script>


<style lang="scss" scoped>
.goodsinfodesc_container {
  img {
    display: block;
    width: 100%;
    height: auto;
    vertical-align: top;
  }
}
</style>