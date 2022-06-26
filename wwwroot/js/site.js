// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// let cpuValue = document.getElementById("cpu");

// function greet() 
// {
//     // var refresh = cpuValue.innerHTML;
//     // cpuValue.innerHTML = refresh;

//     // document.getElementById("cpu").contentWindow.location.reload(true);
//     console.log(cpuValue);
// }

// setInterval(greet, 1000);

// const osu = require('node-os-utils')
// const cpu = osu.cpu

// // Run every 2 seconds
// setInterval(() =>
// {
//     // CPU Usage
//     cpu.usage().then((info) =>
//     {
//         document.getElementById('cpu-usage').innerText = info + '%';

//         document.getElementById('cpu-progress').style.width = info + '%';

//         // Make progress bar red if overload
//         if (info >= cpuOverload)
//         {
//             document.getElementById('cpu-progress').style.background = 'red'
//         } else
//         {
//             document.getElementById('cpu-progress').style.background = '#30c88b'
//         }

//         localStorage.setItem('lastNotify', +new Date())

//         console.log("Hola");
//     })
//   })

// cpu.free().then((info) =>
// {
//     document.getElementById('cpu-free').innerText = info + '%'
// })