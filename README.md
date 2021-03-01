## 自学vue 入坑

+ 01.vue语法基本使用

+ 02.webpack 使用

+ [03.vue-cms 项目](https://github.com/imtudou/Vue/tree/master/03.vue-cms)

+ 04.vue-cms dotnetcore 2.1 api 后台

## vue-cms 是跟着B站上传智播客自学的一个小项目 作为一个 .NET 后端只想入坑下vue [线上地址](http://vue.imtudou.cn)

![演示图片](./05.README/3.gif)

## 执行如下命令运行项目
```
npm install
npm run dev  
```




webpack基本使用：

## 1.使用npm包管理  
 npm init -y
 --如果是中文 直接 npm init 项目名称


## 2.全局打包（不好用）
 webpack .\src\main.js .\dit\bundle.js
 --webpack ./src/main.js -o ./dist/bundle.js --mode development

## 3.自动打包
 ## 3.1  安装webpack-dev-server
 ```js
    cnpm i webpack -D   cnpm i -D webpack-cli
    cnpm i webpack-dev-server -D
 ```
 ## 3.2  项目根目录新增 webpack.config.js 配置文件文件 
 在配置文件里做相应配置代码如下：
 ``` js    
      //导入path 模块
      const path = require('path');
      module.export={
        entry:path.join(__dirname,'./src/main.js'),//入口文件
        output:{//指定输出项
        path:path.join(__dirname,'./dist');//输出路径
        filename:'bundle.js';//指定输出文件名称
        }
      }
```
## 3.3 配置实时构建
在 package.json 文件找到 script 节点中添加脚本： ``` "dev": "webpack-dev-server --open  --port 3000  --contentBase src  --hot",```


## 4.使用html-webpack-plugin插件配置启动页面
## 4.1  cnpm i html-webpack-plugin -D
## 4.2  在配置文件(webpack.config.js )中做如下配置
```js
     var htmlWebpackPlugin = require('html-webpack-plugin');

     plugins:{
         new htmlWebpackPlugin({
             template:path.join(__dirname,'./src/index.html'),//指定模板文件路径
             filename:'index.html'//指定生成内存页面名称
         })
     }
```

## 5.安装第三方loader
## 5.1 安装css-loader
cnpm i style-loader -D
```
cnpm i css-loader -D
--简写 cnpm i style-loader css-loader -D
```
## 5.2 安装less-loader   
```
cnpm i less -D
cnpm i less-loader -D
--简写  cnpm i less-loader less -D
```
## 5.3 安装sass-loader
```
cnpm i node-sass -D
cnpm i sass-loader -D
--简写 cnpm i sass-loader node-sass -D
```
## 5.4 在配置文件中做相应配置如下：
```js
  module: {//用于配置所有地方三方模块加载器
    rules: [//所有第三方模块 匹配规则
      //错误配置     { test: /\.css$/, use: ['style-loader', 'css-loder'] }//配置处理 .css文件的第三方loader
      { test: /\.css$/, loader: "style-loader!css-loader" },//配置处理 .css文件的第三方loader
      { test: /\.less$/, loader: "style-loader!css-loader!less-loader" },//配置处理 .less文件的第三方loader
      { test: /\.scss$/, loader: "style-loader!css-loader!sass-loader" }//配置处理 .scss文件的第三方loader


    ],
  }
```
## 5.5 配置处理css文件中的 url地址，,不管是图片 字体库
```js
cnpm i url-loader file-loader -D

配置处理图片规则：
{test:/\.(jpg|png|gif|bmp|jpeg)$/,use:'url-loader?limit=119319&name[hash:8]=[name].[ext]'}
limit >= 图片的大小(kb*1024=字节)  图片会转成base64位编码。
limit < 图片的大小(kb*1024=字节)  图片不会转成base64位编码。

配置图片显示名称 name[hash:8]=[name].[ext]
                [hash:8] hash值+图片默认名称
```
## 5.6 配置字体图标 bootstarp


``` { test: /\.(ttf|eot|svg|woff|woff2)$/, use: 'url-loader' }, // 处理 字体文件的 loader ```


## 5.7webpack 中处理es6，es7高级语法。
```
cnpm i babel-core babel-loader babel-plugin-transform-runtime -D 
cnpm i babel-preset-env bable-preset-stage-0 -D
```
```js
在webpack.config.js添加配置项如下：  
{tests:/\.js$/,use:'babel-loader',exclude:/node_modules/}  --排除//exclude:/node_modules/
在根目录添加 .bablerc 配置文件（json格式）配置项如下:
{
  "presets":["env","stage-0"],//语法映射
  "plugins":["transform-runtime"]//插件
}
```

## 6.webpack 项目中使用vue
```js
cnpm i  vue -S 
注意:此处安装vue后会引起 webpack-dev-server 的不兼容,此时只与需要将
     node_modules文件全部删除后 执行npm install后即可
```
## 6.1 安装 打包 .vue 文件的 loader
``` cnpm i vue-loader vue-template-compiler -D ```

## 6.2 在配置文件中module节点新增配置项如下：
``` {test:/\.vue$/,use:'vue-loader'} ```

## 6.3 使用vue-loader需要在配置文件中插件配置接点新增配置
导入插件：
```js
 const vueLoaderPlugin = require('vue-loader/lib/plugin')
 new vueLoaderPlugin()
```


## 7.安装 vue-router
```
npm install vue-router -S
```

## 8. 安装 vue-resource
```js
cnpm i vue-resource -S
```

## 9.定义全局过滤器,使用 moment时间插件 格式时间

```js
//安装插件命令：
cnpm i moment -S
//导入插件
improt moment from 'moment';
//定义全局过滤器
Vue.filter('dateFormat',function(dateStr,parameters = 'YYYY-MM-DD HH:mm:ss'){
  debugger
    return moment(dateStr,parameters);
});

```
调用方式 :
```html
<span>发表时间:{{item.CreateTime | dateFormat}}</span>
```

## 10.在webpack打包的时移除严格模式
1.装包
```js
cnpm install babel-plugin-transform-remove-strict-mode -D

//在 .babelrc 中配置如下:
"plugins": [
      "transform-remove-strict-mode"  //配置移除严格模式
]
```

> [土豆部落:使用mui的tab-top-webview-main完成分类滑动栏解决方案](http://imtudou.cn/2019/08/09/%E4%B8%83-Vue-js-%E4%BD%BF%E7%94%A8mui%E7%9A%84tab-top-webview-main%E5%AE%8C%E6%88%90%E5%88%86%E7%B1%BB%E6%BB%91%E5%8A%A8%E6%A0%8F/)
 

## 11.安装图片预览插件
[Vue preview plugin](https://github.com/LS1231/vue-preview)

```js
cnpm i vue-preview -S
```


## 12.在 Android 手机调试网站
在 ```package.json```中
```"dev": "webpack-dev-server --open  --port 3000  --contentBase src  --hot --host 192.168.1.219"```
新增 ```--host 192.168.1.219"```配置ip地址

## 13.Vue Router(编程式的导航)
[https://router.vuejs.org/zh/guide/essentials/navigation.html](https://router.vuejs.org/zh/guide/essentials/navigation.html)


## 14.vue-router路由中 this.$router 与this.$route区别
1. this.$router 实际上 就是全局 路由对象  任何页面 都可以 调用 push(), go()等方法
2. this.$route  表示当前正在用于跳转的路由器对象，可以调用其name、path、query、params等属性


## 15 vuex使用
1. `cnpm install vuex -S`
2. 使用 `mutations` 来操作state中的数据
3. 使用 `this.$store.commit("increment")` 调用mutations 中定义的方法













       
