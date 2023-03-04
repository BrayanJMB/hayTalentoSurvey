$(document).ready(function () {
    let current_fs, next_fs, previous_fs; //fieldsets
    let opacity;
    let contador = -1;
    let tituloDimension = [
        "Datos Demográficos",
        "Beneficios de Calidad de Vida",
        "Beneficios Monetarios y No Monetarios",
        "Beneficios de Desarrollo Personal",
        "Beneficios en Herramientas de Trabajo",
        //"Beneficios/Madurez"
    ]
    let descripcionDimension = [
        "",
        "Aspectos relacionados con las condiciones favorables en la relación laboral y el ambiente de trabajo.",
        "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales.",
        "Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización.",
        "Elementos útiles para una adecuada realización de la labor.",
        //"Nivel en el que la compañía asimila o integra buenas prácticas relacionadas con la administración de los beneficios."
    ]





    $("fieldset").first().addClass('active');
    (function () {
        'use strict';
        window.addEventListener('load', function () {
            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.getElementsByClassName('needs-validation');
            // Loop over them and prevent submission
            var validation = Array.prototype.filter.call(forms, function (form) {
                // Add event listener for the "next" button
                var nextButton = document.getElementById("siguiente");
                nextButton.addEventListener('click', function (event) {

                    if (isValid === false) {
                        debugger;
                        event.preventDefault();
                        event.stopPropagation();
                        let firstInvalid = form.querySelector('[required]:invalid');
                        firstInvalid.focus();
                    } else {
                        contador += 1
                        current_fs = $(this).parent().parent().parent().parent().parent();
                        next_fs = $(this).parent().parent().parent().parent().parent().next();
                        let elem = $(".next");
                        let indexNext = $.inArray(this, elem);
                        //Add Class Active
                        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");
                        $(".titulo-dimension").text(tituloDimension[contador]);
                        $(".descripcion-dimension").text(descripcionDimension[contador]);
                        //show the next fieldset
                        let showNext = true;
                        let datosPregunta = document.querySelectorAll(".question-list")[indexNext].querySelectorAll("#FilaPregunta");
                        datosPregunta.forEach(function (data) {
                            let opcionp = data.querySelectorAll("#opcionP")
                            if (data.querySelector("#tipoPregunta").value != 5) {
                                opcionp.forEach(function (opcion) {
                                    if (opcion.value == null || opcion.value == "") {
                                        showNext = false;
                                        return;
                                    }
                                });
                                next_fs.css({ 'opacity': opacity });
                                current_fs.removeClass("active");
                                next_fs.addClass("active");
                            }
                        });
                        if (showNext == true) {
                            next_fs.show();
                            current_fs.animate({ opacity: 0 }, {
                                step: function (now) {
                                    // for making fielset appear animation
                                    opacity = 1 - now;
                                    current_fs.css({
                                        'display': 'none',
                                        'position': 'relative'
                                    });
                                    next_fs.css({ 'opacity': opacity });
                                },
                                duration: 600
                            });
                        }
                        else
                            alert("Todas las preguntas denben tener valores para mostrar al usuarios final por favor verifique que tenag almenos uno");
                        //hide the current fieldset with style
                    }
                    form.classList.add('was-validated');
                }, false);
            });
        }, false);
    });

    function checkboxGroupValidation() {
        let checkbox = $("fieldset.active .datacheck").parent().parent().parent().parent();
        if (checkbox.length > 0) {
            flagCheck = false;
            for (j = 0; j < checkbox.length; j++) {
                let errorP = checkbox[j].previousSibling.previousSibling.previousSibling.previousSibling;
                errorP.classList.add("checkbox");
                let option = checkbox[j];
                let listCheckBoxes = option.querySelectorAll(".datacheck");
                listCheckBoxes.forEach(element => {
                    if (element.checked) {
                        flagCheck = true;
                        errorP.innerHTML = "";
                        return flagCheck;
                    }
                });
                if (!flagCheck) {
                    errorP.style.color = "red";
                    errorP.innerHTML = "Debe seleccionar una opción";
                    option.querySelector('.datacheck:not(:checked)').focus();
                }
            }
        } else {
            flagCheck = false;
        }
        return flagCheck;

    }
});