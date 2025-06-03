document.addEventListener("DOMContentLoaded", function () {
    const lupa = document.getElementById("cautare-articol");
    const input = document.getElementById("input-cautare");
    const articole = document.querySelectorAll(".articol-container");
    let isInputVisible = false;

    // Toggle input + icon
    lupa.addEventListener("click", function () {
        isInputVisible = !isInputVisible;

        if (isInputVisible) {
            input.style.display = "inline-block";
            lupa.classList.remove("fa-magnifying-glass");
            lupa.classList.add("fa-xmark");
            input.focus();
        } else {
            input.style.display = "none";
            input.value = ""; // Golește câmpul
            lupa.classList.remove("fa-xmark");
            lupa.classList.add("fa-magnifying-glass");

            // Resetează afișarea articolelor
            articole.forEach(function (produs) {
                produs.parentElement.style.display = "";
            });
        }
    });

    // Căutare în articole
    input.addEventListener("input", function () {
        const termen = this.value.toLowerCase().trim().normalize("NFD").replace(/[\u0300-\u036f]/g, '');

        articole.forEach(function (produs) {
            const valNume = produs.querySelector(".val-nume").innerText
                .toLowerCase().trim().normalize("NFD").replace(/[\u0300-\u036f]/g, '');

            produs.parentElement.style.display = valNume.includes(termen) ? "" : "none";
        });
    });
});
