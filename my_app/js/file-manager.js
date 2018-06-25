const { shell } = require('electron')
const os = require('os')
const cmd = require('node-cmd');

const fs = require('fs');
fs.readFile('my_app/iconList.txt', function (err, data) {
  if (err) {
    return console.error(err);
  }
  iconList = data.toString().split('\n');
  iconList.forEach(element => {
    var arr = element.split('\t');
    var appName = arr[0].split('.lnk')[0].split('.url')[0];
    Btn = document.getElementById(appName);
    Btn.addEventListener('click', (event) => {
      shell.openItem(arr[1]);
    });
  });

});