//项目入口文件

// 1.导入 jquery
import $ from 'jquery'

//2.使用 import 导入 css样式
 import './css/index.css'

 //3.使用import 导入 less
 import './css/index.less'

 //4.使用import 导入 scss
 import './css/index.scss'


$(function(){
    $('li:odd').css('backgroundColor','red')
    $('li:even').css('backgroundColor',function(){
        return '#'+'D97643'
    })
})

//----------webpack 打包js文件---------------
//使用 webpack-dev-server 实现自动打包编译的功能
//注意：webpack 4.x中 需要在本地安装webpack后再安装webpack-cli
//npm i webpack -D
//npm i -D webpack-cli
//1.使用命令  npm i webpack-dev-server  安装开发依赖( webpack-dev-server)
//2. 在 package.json文件中的 scripts节点 配置 【"dev": "webpack-dev-server --open  --port 3000  --contentBase src  --hot"】
/*
--open :自动打开浏览器
--port 3000:配置自定义端口 3000
--contentBase src  :知道托管根目录 
--hot :配置热更新 浏览器无刷新加载
 */

//3. npm run dev
// 
//
//webpack-dev-server  中常用的参数
//在 package.json文件中的 scripts节点 配置 【webpack-dev-server --open  --port 3000  --contentBase src  --hot】 打开根路径 并自定义端口为3000
//
//
//
//
//----------webpack 打包非js文件(安装css)---------------
//1.打包非js文件需要安装第三方(style-loader,css-loader) loder 加载器   cnpm i style-loader css-loader -D
//2.在webpack.config.js  新增一个  modul 节点 ，他是一个对象  在modul 身上 rules 属性（rules 是个对象）配置匹配和处理原则



//----------webpack 打包非js文件(安装less)---------------
// cnpm i less -D
// cnpm i less-loader -D


//----------webpack 打包非js文件(安装scss)---------------
// cnpm i node-sass -D
// cnpm i sass-loader -D