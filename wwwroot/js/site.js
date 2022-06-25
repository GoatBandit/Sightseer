// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let cpuValue = document.getElementById("cpu");

function greet() 
{
    // var refresh = cpuValue.innerHTML;
    // cpuValue.innerHTML = refresh;

    // document.getElementById("cpu").contentWindow.location.reload(true);
    console.log(cpuValue);
}

setInterval(greet, 1000);