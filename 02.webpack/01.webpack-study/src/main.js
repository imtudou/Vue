alert('ok');

import './css/index.css'
import './css/index.less'
import './css/index.scss'

//class 关键字
class Person{
    static info = {name:'zhangsan',age:'20'}
}
console.log(JSON.stringify(Person.info));