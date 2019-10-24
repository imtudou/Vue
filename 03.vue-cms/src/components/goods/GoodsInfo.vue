<template>
    <div>
        <h1>商品详情==={{this.id}}</h1>
    </div>
</template>



<script>
export default {
    data() {
        return {
            id:this.$route.query.id
        }
    },
    
}
</script>



<style lang="scss" scoped>

</style>