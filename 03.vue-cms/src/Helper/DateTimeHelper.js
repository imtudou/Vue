/**
 * 此js文件是对时间相关操作的帮助类
 * yuan 2019-10-28 11:49:50
 */


var DateTime = new Object();


/**
 * 获取当前时间 并以 'YYYY-MM-DD HH:mm:ss'格式返回时间字符串
 * @param {时间字符串} datetime 
 */
DateTime.Now = function (datetime) {
    if (datetime == '' || datetime == undefined || datetime == null)
        datetime = new Date();
    var dt = new Date(datetime);
    var y = dt.getFullYear();
    var m = (dt.getMonth() + 1).toString().padStart(2, '0');
    var d = dt.getDate();
    var hh = dt.getHours();
    var mm = dt.getMinutes();
    var ss = dt.getSeconds().toString().padStart(2, '0');
    return `${y}-${m}-${d} ${hh}:${mm}:${ss}`;
};

export default DateTime;