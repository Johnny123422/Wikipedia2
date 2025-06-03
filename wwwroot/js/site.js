// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("cautare-articol").addEventListener("input", function () {
    let termen = this.value.toLowerCase().trim().normalize("NFD").replace(/[\u0300-\u036f]/g, '');

    let articole = document.querySelectorAll(".articol-container");

    articole.forEach(function (produs) {
        let valNume = produs.querySelector(".val-nume").innerHTML
            .toLowerCase().trim().normalize("NFD").replace(/[\u0300-\u036f]/g, '');

        if (valNume.includes(termen)) {
            produs.parentElement.style.display = ""; // afișează articolul
        } else {
            produs.parentElement.style.display = "none"; // ascunde articolul
        }
    });
});