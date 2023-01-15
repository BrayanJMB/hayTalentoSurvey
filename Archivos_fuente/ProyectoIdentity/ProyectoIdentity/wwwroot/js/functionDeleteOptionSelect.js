$(document).ready(function () {
    let data = document.querySelectorAll("#multiple-options select");
    var selectedValues = [null, null, null, null];
    data.forEach((option) => {

        option.addEventListener("change", () => {
            let elementSelected = Array.prototype.indexOf.call(data, option);
            index = option.selectedIndex;
            if (option[option.selectedIndex].value != "Seleccione") {

                data.forEach((optionDisabled) => {
                    if (optionDisabled !== option)
                        optionDisabled[index].hidden = true;
                    if (selectedValues[elementSelected] != null)
                        optionDisabled[selectedValues[elementSelected]].hidden = false;
                });
                selectedValues[elementSelected] = option[option.selectedIndex].value;
            } else if (option[option.selectedIndex].value == "Seleccione" && selectedValues[elementSelected] != null) {

                data.forEach((optionDisabled) => {
                    optionDisabled[selectedValues[elementSelected]].hidden = false;
                });
                selectedValues[elementSelected] = null;
            }

        });
    });
});