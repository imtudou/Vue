var path = require('path');
var htmlWebpackPlunin = require('html-webpack-plugin');

module.exports = {

    entry:path.join(__dirname,'./src/main.js'),
    output:{
        path:path.join(__dirname,'./dist'),
        filename:'bundle.js'
    },
    plugins:[//所有webpack插件配置接点
        new htmlWebpackPlunin({
            template:'./src/index.html',
            filename:'index.html'
        })


    ],
    module:{
        rules:[
            {test:/\.css$/, loader:"style-loader!css-loader"},
            {test:/\.less$/,loader:"style-loader!less-loader"},
            {test:/\.scss/,loader:"style-loader!css-loader!sass-loader"},
            // {test:/\.(jpg|png|gif|bmp|jpeg)$/,loader:"url-loader?limit=119319&name=[name].[ext]"}
            {test:/\.(jpg|png|gif|bmp|jpeg)$/,use:'url-loader?limit=119319&name[hash:8]=[name].[ext]'},
            {test:/\.js$/,use:'babel-loader',exclude:/node_modules/}//配置babel转换高级的es语法
        ]


    }
}