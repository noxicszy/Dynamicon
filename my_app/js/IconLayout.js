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
        if(element != '')
        {
            var div = displayOneIcon(element);
            appUl.appendChild(div);
        }
    });
});



function displayOneIcon(IconStr) {
    var div = document.createElement("div");
    div.className = "icon";
    var arr = IconStr.split('\t');
    var appName = arr[0].split('.lnk')[0].split('.url')[0];
    var htmlStr;

    var IconStyle = fs.readFileSync('my_app/Style.txt', 'utf-8');
    IconStyle = Number(IconStyle);
    if (IconStyle == 1) // Domino
    {
            
        htmlStr = '<a href = "#" id = "{a}"> <div> <figure style="background: url(images/icons/{b}.jpg); background-size: 100%;" > <figcaption> {c} </figcaption> </figure > </div > </a>';
        const reg = new RegExp(' ', "g")
        htmlStr = htmlStr.format({ 'a': appName, 'b': arr[0].replace(reg, '%20'), 'c': appName });
    }
    else if (IconStyle < 5) // chenhongbin
    {
        htmlStr = '<a href = "#" class="origin" id = "{a}" > <img src = "images/icons/{b}.jpg" >  <br /> {c} </a>';
        htmlStr = htmlStr.format({ 'a': appName, 'b': arr[0], 'c': appName });
    }


    div.innerHTML = htmlStr;
    return div;
    
}


