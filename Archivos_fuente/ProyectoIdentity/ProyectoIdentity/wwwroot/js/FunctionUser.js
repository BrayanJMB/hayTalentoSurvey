let Check = document.querySelectorAll("#CheckActive");

Check.forEach(function (checked) {
    checked.addEventListener('click', function (e) {
        let elementLabel = e.target.nextElementSibling;
        if (e.target.checked == true) {
            elementLabel.innerHTML = "Activo";
            elementLabel.classList.add("activeLabel");
        } else {
            elementLabel.innerHTML = "Inactivo";
            elementLabel.classList.remove("activeLabel");
        }
    })
})