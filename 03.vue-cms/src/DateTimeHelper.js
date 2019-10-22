function DateTimeNow(datetime) {
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

export default DateTimeNow;