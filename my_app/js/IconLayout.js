String.prototype.format = function (args) {
    var result = this;
    if (arguments.length < 1) {
        return result;
    }
    var data = arguments;
    if (arguments.length == 1 && typeof (args) == "object") {
        data = args;
    }
    for (var key in data) {
        var value = data[key];
        if (undefined != value) {
            result = result.replace("{" + key + "}", value);
        }
    }
    return result;
}
appUl = document.getElementById('app');

const fs = require('fs');
fs.readFile('my_app/iconList.txt', function (err, data) {
    if (err) {
        return console.error(err);
    }
    iconList = data.toString().split('\n');
    iconList.forEach(element => {
        var div = displayOneIcon(element);
        appUl.appendChild(div);
    });

});



function displayOneIcon(IconStr) {
    var div = document.createElement("div");
    div.className = "icon";
    var arr = IconStr.split('\t');

    var htmlStr ='<a href = "#" id = "{a}" > <img src = "images/icons/{b}.jpg" >  <br /> {c} </a>';
    htmlStr = htmlStr.format({ 'a': arr[0], 'b': arr[0], 'c': arr[0]});
    
    div.innerHTML = htmlStr;
    return div;
    
}


