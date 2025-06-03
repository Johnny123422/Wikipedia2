// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("cautare-articol").addEventListener("click", function () {
    let input = document.getElementById("input-cautare");
    input.style.display = "inline-block";
    input.focus(); 
});

document.getElementById("cautare-articol").addEventListener("click", function () {
    let input = document.getElementById("input-cautare");
    input.style.display = "inline-block";
    input.focus();
});






document.getElementById("input-cautare").addEventListener("input", function () {
    let termen = this.value.toLowerCase().trim().normalize("NFD").replace(/[\u0300-\u036f]/g, '');

    let articole = document.querySelectorAll(".articol-container");

    articole.forEach(function (produs) {
        let valNume = produs.querySelector(".val-nume").innerText
            .toLowerCase().trim().normalize("NFD").replace(/[\u0300-\u036f]/g, '');

        produs.parentElement.style.display = valNume.includes(termen) ? "" : "none";
    });
});