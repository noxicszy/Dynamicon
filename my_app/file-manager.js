const { shell } = require('electron')
const os = require('os')
const cmd = require('node-cmd');

const MyComputerBtn = document.getElementById('Computer')
const TyporaBtn = document.getElementById("Typora")
const TIMBtn = document.getElementById("TIM")

MyComputerBtn.addEventListener('click', (event) => {
  
  cmd.run('explorer.exe /s,');  //open 'My Computer'
})

TyporaBtn.addEventListener('click', (event) => {
  shell.openItem("D:\\Program Files (x86)\\Typora\\Typora.exe")
})

TIMBtn.addEventListener('click', (event) => {
  shell.openItem("D:\\Program Files (x86)\\Tencent\\TIM\\Bin\\QQScLauncher.exe")
})

