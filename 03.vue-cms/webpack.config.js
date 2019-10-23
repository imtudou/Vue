const path = require('path');
const htmlWebpackPlunin = require('html-webpack-plugin');
const vueLoaderPlugin = require('vue-loader/lib/plugin')

module.exports = {

    entry:path.join(__dirname,'./src/main.js'),//入口文件
    output:{//指定输出项
        path:path.join(__dirname,'./dist'),//输出路径
        filename:'bundle.js'//指定输出文件名称
    },
    plugins:[//所有webpack插件配置接点
        new htmlWebpackPlunin({
            template:'./src/index.html',
            filename:'index.html'
        }), 
        new vueLoaderPlugin()


    ],
    module:{
        rules:[
            {test:/\.css$/, loader:"style-loader!css-loader"},
            {test:/\.less$/,loader:"style-loader!less-loader"},
            {test:/\.scss/,loader:"style-loader!css-loader!sass-loader"},
            // {test:/\.(jpg|png|gif|bmp|jpeg)$/,loader:"url-loader?limit=119319&name=[name].[ext]"}
            {test:/\.(jpg|png|gif|bmp|jpeg)$/,use:'url-loader?limit=119319&name[hash:8]=[name].[ext]'},
            // {test:/\.js$/,use:'babel-loader',exclude:/node_modules/}//配置babel转换高级的es语法
            {test:/\.vue$/,use:'vue-loader'},//配置.vue组件的loader
            {test: /\.(ttf|eot|svg|woff|woff2)$/, use: 'url-loader' } // 处理 字体文件的 loader 
        ]


    },
    resolve:{
        alias:{//修改vue 被导入的包路径
            "vue$":"vue/dist/vue.js"

        }
    }
}