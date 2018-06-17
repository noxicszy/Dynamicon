{/* <li>
    <a href="#" id="TIM">
        <img src="images/icons/VR Kanojo.url.jpg">
            <br /> TIM
    </a>
</li> 
 */}

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
        var li = displayOneIcon(element);
        appUl.appendChild(li);
    });

});



function displayOneIcon(IconStr) {
    var li = document.createElement("li");
    var arr = IconStr.split('\t');

    var htmlStr ='<a href = "#" id = "{a}" > <img src = "images/icons/{b}.jpg" >  <br /> {c} </a>';
    htmlStr = htmlStr.format({ 'a': arr[0], 'b': arr[0], 'c': arr[0]});
    // var htmlStr = '<a href="http://www.sucaijiayuan.com" target="_blank">www.sucaijiayuan.com";</a>';
    li.innerHTML = htmlStr;
    return li;
    
}


// function displayOneIcon(IconStr) {
//     var li = document.createElement("li");
//     var a = document.createElement("a");
//     var arr = IconStr.split('\t');
//     a.href = "#";
//     a.id = arr[0];
// }