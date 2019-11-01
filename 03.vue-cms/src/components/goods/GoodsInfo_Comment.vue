<template>
    <div class="commentbox">
        <span>商品评论--{{this.id}}</span>
        <commentbox></commentbox>
    </div>
</template>

<script>
import comment from '../../components/subcomponents/Comment.vue'
export default {
    data() {
        return {
            id:this.$route.params.id        
        }
    },
    methods: {     
    },
    components:{
        commentbox:comment
    }
    
}
</script>   


<style lang="scss" scoped>
.commentbox{
    padding: 0 5px;
    margin-bottom: 15px;

}

</style>