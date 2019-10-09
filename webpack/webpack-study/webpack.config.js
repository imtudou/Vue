
//
const path = require('path');

//引入webpack
const webpack = require('webpack')

// 导入自动生成HTMl文件的插件
//作用:
//1.自动 在内存中根据配置项生成一个内存中的页面
//2.自动把打包好的budle.js 追加到指定页面中
var htmlWebpackPlugin = require('html-webpack-plugin');







//配置文件
module.exports = {
  entry: './src/main.js',//入口文件
  output: {
    //输出文件相关配置
    filename: 'bundle.js',//文件名称
    path: path.resolve(__dirname, './dist'),//输出目录
  },
  plugins: [//配置插件节点
    new htmlWebpackPlugin({//创建一个在内存中生成的 HTML 页面插件
      template: path.join(__dirname, './src/index.html'),//指定模板页面 会根据指定路径生成内存中的页面
      filename: 'index.html'//指定生成页名称

    })
  ],
  module: {//用于配置所有地方三方模块加载器

    rules: [//所有第三方模块 匹配规则
      { test: /\.css$/, use: ['style-loader', 'css-loder'] }//配置处理 .css文件的第三方loader



    ]

  }

};