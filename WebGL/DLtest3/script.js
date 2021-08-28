// データを配列で管理
var datas = [];

// データを追加
function add_data(jsonObj) {
    jsonObj.id = datas.length + 1;
    datas.push(jsonObj);
}

// データをcsv形式にし、ダウンロード
/*
function download_data() {
    let loghead = "id,score,hit_num,hit_rate\n";
    let logdata = "";
    datas.map(function (d) {
        logdata += d.id + "," + d.score + "," + d.hit_num + "," + d.hit_rate + "\n";
    });
    */
    function download_data() {
        let loghead = "success,fish_num,clear_time,distance\n";
        let logdata = "";
        datas.map(function (d) {
            logdata += d.success+","+d.fish_num+","+d.clear_time +","+d.distance+"\n";
        });
   

    const filename = getNow() + ".csv";
    const bom = new Uint8Array([0xef, 0xbb, 0xbf]);
    const blob = new Blob([bom, loghead + logdata], { type: "text/csv" });

    if (window.navigator.msSaveBlob) {
        window.navigator.msSaveBlob(blob, filename);
    } else {
        const url = (window.URL || window.webkitURL).createObjectURL(blob);
        const download = document.createElement("a");
        download.href = url;
        download.download = filename;
        download.click();
        (window.URL || window.webkitURL).revokeObjectURL(url);
    }
}

// 時刻を取得
function getNow() {
    var date = new Date();
    var yyyy = date.getFullYear();
    var mm = toDoubleDigits(date.getMonth() + 1);
    var dd = toDoubleDigits(date.getDate());
    var hh = toDoubleDigits(date.getHours());
    var mi = toDoubleDigits(date.getMinutes());
    return yyyy + mm + dd + '_' + hh + mi;
}
function toDoubleDigits(num) {
    num += "";
    if (num.length === 1) {
        num = "0" + num;
    }
    return num;   
}
