$(document).ready(function () {
    let current_fs, next_fs, previous_fs; //fieldsets
    let opacity;
    let contador = 0;
    $("fieldset").first().addClass('active');
    var forms = document.getElementsByClassName('needs-validation');
    var nextButton = document.querySelectorAll("#siguiente");
    var sendSurveyButton = document.querySelectorAll("#EnviarEncuesta");
    validateFields(nextButton, forms);
    validateFields(sendSurveyButton, forms, true);

    function validateFields(elemento, forms, isSubmit = false) {
        var validation = Array.prototype.filter.call(forms, function (form) {
            elemento.forEach((element) => {
                element.addEventListener('click', function (event) {
                    let activeFieldset = document.querySelector('fieldset.active');
                    let formElements = activeFieldset.querySelectorAll('[required]');
                    form.classList.add('was-validated');
                    var isValid = true;
                    for (var i = 0; i < formElements.length; i++) {
                        if (formElements[i].checkValidity() === false) {
                            isValid = false;
                            break;
                        };
                    };
                    let isValidCheckbox = checkboxGroupValidation();
                    if (!isValid || !isValidCheckbox) {
                        event.preventDefault();
                        event.stopPropagation();
                        let firstInvalid = form.querySelector('[required]:invalid');
                        firstInvalid.focus();
                        form.classList.add('was-validated');
                    } else {
                        contador++;
                        if (!isSubmit) {
                            current_fs = $(this).parent().parent().parent().parent().parent();
                            next_fs = $(this).parent().parent().parent().parent().parent().next();
                            //Add Class Active
                            $("fieldset").eq($("fieldset").index(current_fs)).removeClass("active");
                            $("fieldset").eq($("fieldset").index(next_fs)).addClass("active");
                            form.classList.remove('was-validated');
                            $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");
                            //show the next fieldset
                            next_fs.show();
                            document.getElementById("progressbar").scrollIntoView();
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
                            //Lógica para quitar el requerido 
                            if (contador == 1 || contador == 3) {
                                if (window.matchMedia("(min-width: 768px)").matches) {
                                    document.querySelectorAll("fieldset.active table select").forEach(function (input) {
                                        input.required = true;
                                    });
                                    document.querySelectorAll("fieldset.active div#accordion select").forEach(function (input) {
                                        input.required = false;
                                    });
                                } else {
                                    document.querySelectorAll("fieldset.active table select").forEach(function (input) {
                                        input.required = false;
                                    });
                                    document.querySelectorAll("fieldset.active div#accordion select").forEach(function (input) {
                                        input.required = true;
                                    });
                                };
                            }

                        }else {
                            window.location.href = '@Url.Action("EnvioIndexRespuestasMadurez","Respuestas")';
                        }
                    }
                }, false);
            });
        });
    };

    function checkboxGroupValidation() {
        let checkbox = $("fieldset.active .datacheck").parent().parent().parent().parent();
        if (checkbox.length > 0) {
            flagCheck = true;
            for (j = 0; j < checkbox.length; j++) {
                let errorP = checkbox[j].previousSibling.previousSibling.previousSibling.previousSibling;
                errorP.classList.add("checkbox");
                let validateGroup=false;
                let option = checkbox[j];
                let countCant=0;
                let nextCant=errorP.nextElementSibling.textContent;
                nextCant=nextCant.includes("(3)");    
                let councantValida=nextCant==true?3:0;
                let listCheckBoxes = option.querySelectorAll(".datacheck");
                listCheckBoxes.forEach(element => {
                    if (element.checked ) {
                        countCant++
                        if( countCant>=councantValida){
                            validateGroup = true;
                            errorP.innerHTML = "";
                        }
                    }
                });
                if (!validateGroup) {
                    flagCheck=false;
                    errorP.style.color = "red";
                    errorP.innerHTML = "Debe seleccionar una opción";
                    errorP.scrollIntoView();
                }
            }
        } else
        {
            flagCheck = true;
        }
        return flagCheck;
    };

    $(".previous").click(function () {
        contador--;
        current_fs = $(this).parent().parent().parent().parent().parent();
        previous_fs = $(this).parent().parent().parent().parent().parent().prev();
        //Remove class active
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");        
        //show the previous fieldset
        previous_fs.show();
        document.getElementById("progressbar").scrollIntoView();
        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;
                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                previous_fs.css({ 'opacity': opacity });
                previous_fs.addClass("active");
                current_fs.removeClass("active");
            },
            duration: 600
        });
    });
});




