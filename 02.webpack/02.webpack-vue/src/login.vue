<template>
    <div>
        <h1>这是使用 .vue文件定义出来的组件------{{msg}}</h1>
    </div>
</template>


<script>
export default{
    data(){
        return {
            msg:'123'
        }
    },
    methods:{
        show(){
            alert("组件中的show方法")
        }
    }
}


</script>



<style>

</style>