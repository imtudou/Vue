//项目入口文件

// 1.导入 jquery

import $ from 'jquery'


$(function(){
    $('li:odd').css('backgroundColor','red')
    $('li:even').css('backgroundColor',function(){
        return '#'+'D97643'
    })
})

    