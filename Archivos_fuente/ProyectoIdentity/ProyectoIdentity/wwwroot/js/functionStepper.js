$(document).ready(function () {
    let data = document.querySelectorAll("#Seleccione1 select");
    var selectedValues = [null, null, null, null];
    data.forEach((option) => {

        option.addEventListener("change", () => {
            let elementSelected = Array.prototype.indexOf.call(data, option);
            index = option.selectedIndex;
            if (option[option.selectedIndex].value != "seleccione") {

                data.forEach((optionDisabled) => {
                    if (optionDisabled !== option)
                        optionDisabled[index].disabled = true;
                    if (selectedValues[elementSelected] != null)
                        optionDisabled[selectedValues[elementSelected]].disabled = false;
                });
                selectedValues[elementSelected] = option[option.selectedIndex].value;
            } else if (option[option.selectedIndex].value == "seleccione" && selectedValues[elementSelected] != null) {

                data.forEach((optionDisabled) => {
                    optionDisabled[selectedValues[elementSelected]].disabled = false;
                });
                selectedValues[elementSelected] = null;
            }

        });
    });
});
