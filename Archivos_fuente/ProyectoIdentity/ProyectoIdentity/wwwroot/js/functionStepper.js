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
                    if (form.checkValidity() === false) {
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
                        console.log(elem)
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
    })();

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
        } else
        {
            flagCheck = false;
        }
        console.log(flagCheck)
        return flagCheck;
        
    }


    //$(".next").click(function () {
    //    /*
    //    debugger;
    //    let selectAspectosDemograficos = $("fieldset.active .select-aspectos-demograficos");
    //    let selectdemograficos = $("fieldset.active .select-demograficos");
    //    let selectDemograficosMobile = $("fieldset.active .select-demograficos-mobile");
    //    let select = $("fieldset.active .form-select.form-select-sm.likkert");
    //    let selectEscala = $("fieldset.active .form-select.form-select-sm.escala").parent().parent().parent();
    //    let checkbox = $("fieldset.active .datacheck").parent().parent().parent().parent();
    //    let errorDescripcion =  $("fieldset.active .error-description");
    //    let errorDemograficos =  $("fieldset.active .error-demograficos");
    //    let table = document.getElementsByClassName("table")
    //    let flag;
    //    let flag_;
    //    let flagEscala;
    //    let flagCheck;
    //    let flagCheck3;
    //    let flagSelectDemograficos;
    //    if (select.length > 0 &&  selectdemograficos.length == 0){
    //        flag= false;
    //        for(i = 0; i < select.length; i++){
    //            if(select[i].value == "Seleccione" ){
    //                if (flag == false)
    //                    select[i].focus();
    //                errorDescripcion[i].style.color  = "red" ;
    //                errorDescripcion[i].innerHTML = "Requerido";
    //                flag = true;
    //            }else{
    //                errorDescripcion[i].innerHTML = "";
    //            }
    //        }
    //    }

    //    if (selectAspectosDemograficos.length > 0){
    //        flag_= false;
    //        for(i = 0; i < selectAspectosDemograficos.length; i++){
    //            if(selectAspectosDemograficos[i].value == "Seleccione" || selectAspectosDemograficos[i].value == null){
    //                if (flag_ == false)
    //                    selectAspectosDemograficos[i].focus();
    //                errorDemograficos [i].style.color  = "red" ;
    //                errorDemograficos [i].innerHTML = "Debe seleccionar una opción";
    //                flag_ = true;
    //            }else{
    //                errorDemograficos [i].innerHTML = "";
    //            }
    //        }
    //    }
    
    //    if (selectEscala.length >0){
    //        debugger;
    //        for(i = 0; i < selectEscala.length; i++){
    //            flagEscala = false;
    //            let errorEscala = selectEscala[i].previousSibling.previousSibling.previousSibling.previousSibling;
    //            errorEscala.classList.add("escala");
    //            let option = selectEscala[i];
    //            let listSelectEscala = option.querySelectorAll(".escala");
    //            listSelectEscala.forEach(element => {
    //                if(element.value == "Seleccione" || element.value == null){
    //                    if (flagEscala == false)
    //                        element.focus();
    //                    errorEscala.style.color  = "red" ;
    //                    errorEscala.innerHTML = "Debe seleccionar una opción";
    //                    flagEscala = true;
    //                    }else{
    //                        errorEscala.innerHTML = "";
    //                    }
    //            });
    //        }
    //    }
    //    if (window.matchMedia("(min-width: 768px)").matches) {
    //        try {
    //            table[0].classList.add("desktop")
    //        } catch (error) {
    //            console.log(error)
    //        }

    //      } else {
    //        try {
    //            table[0].classList.remove("desktop")
    //        } catch (error) {
    //            console.log(error)
    //        }
    //      }
          
    //    if ($("fieldset.active .select-demograficos").parent().parent().parent().parent().hasClass("desktop")){
    //        if (selectdemograficos.length > 0){
    //            flagSelectDemograficos = false;
    //            let error = $("fieldset.active .error-demograficos");
    //            debugger
    //            [...selectdemograficos].forEach((element, index) =>{
    //                if((element.value == "Seleccione" || element.value == null) && element.hasAttribute('disabled')===false){
    //                    element.style.color = "red";
    //                    element.style.borderColor = "red";
    //                    error[index].style.color = "red";
    //                    error[index].innerHTML = "Requerido";
    //                    flagSelectDemograficos =  true
    //                }else{
    //                    element.style.color = "";
    //                    element.style.borderColor = "";
    //                    error[index].innerHTML = "";
    //                }
    //            })
    //        }
    //    }else{
    //        if (selectDemograficosMobile.length > 0){
    //            flagSelectDemograficos = false;
    //            let error = $("fieldset.active .error-demograficos-mobile");
    //            debugger
    //            [...selectDemograficosMobile].forEach((element, index) =>{
    //                if(element.value == "Seleccione" || element.value == null){
    //                    element.style.color = "red";
    //                    element.style.borderColor = "red";
    //                    error[index].style.color = "red";
    //                    error[index].innerHTML = "Campo Requerido";
    //                    flagSelectDemograficos =  true
    //                }else{
    //                    element.style.color = "";
    //                    element.style.borderColor = "";
    //                    error[index].innerHTML = "";
    //                }
    //            })
    //        }
    //    }

    //    if (checkbox.length > 0){
    //        debugger;
    //        flagCheck =  false;
    //        for(j = 0; j < checkbox.length; j++){
    //            let errorP = checkbox[j].previousSibling.previousSibling.previousSibling.previousSibling;
    //            errorP.classList.add("checkbox");
    //            let option = checkbox[j];
    //            let listCheckBoxes = option.querySelectorAll(".datacheck");
    //            let numeroChecked = 0
    //            listCheckBoxes.forEach(element => {
    //                debugger;
    //                if (contador == 3 && j == 0){
    //                    element.classList.add("data-3")
    //                    flagCheck3 = false
    //                }

    //                if (element.classList.contains("data-3")){
    //                    if(element.checked){
    //                        numeroChecked +=1
    //                    }
    //                    if (numeroChecked == 3){
    //                        flagCheck3 = true;
    //                        errorP.innerHTML = "";
    //                        return;
    //                    }
    //                }else{
    //                    if(element.checked){
    //                        flagCheck = true;
    //                        errorP.innerHTML = "";
    //                        return;
    //                    }
    //                }
    //            });
    //            if (!flagCheck){
    //                errorP.style.color  = "red";
    //                errorP.innerHTML = "Debe seleccionar una opción";
    //            }
    //        }
    //    }
    //    if(selectEscala.length >0)
    //        flagCheck=false
    //    if(flag == true ||flag_==true|| flagEscala==true || flagCheck==true || flagCheck3==true || flagSelectDemograficos==true)
    //        return;

    //    $("#EnviarEncuestaMadurez").click(function (e) {
    //        e.preventDefault();
    //        document.location = '@Url.Action("EnvioIndexRespuestasMadurez","Respuestas")';
    //    });*/

    //    contador +=1
    //    current_fs = $(this).parent().parent().parent().parent().parent();
    //    next_fs = $(this).parent().parent().parent().parent().parent().next();
    //    let elem = $(".next");
    //    console.log(elem)
    //    let indexNext = $.inArray(this, elem);
    //    //Add Class Active
    //    $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");
    //    $(".titulo-dimension").text(tituloDimension[contador]);
    //    $(".descripcion-dimension").text(descripcionDimension[contador]);
    //    //show the next fieldset
    //    let showNext = true;
    //    let datosPregunta = document.querySelectorAll(".question-list")[indexNext].querySelectorAll("#FilaPregunta");
    //    datosPregunta.forEach(function (data) {
    //        let opcionp = data.querySelectorAll("#opcionP")
    //        if (data.querySelector("#tipoPregunta").value != 5) {
    //            opcionp.forEach(function (opcion) {
    //                if (opcion.value == null || opcion.value == "") {
    //                    showNext = false;
    //                    return;
    //                }
    //            });
    //            next_fs.css({ 'opacity': opacity });
    //            current_fs.removeClass("active");
    //            next_fs.addClass("active");
    //        }
    //    });
    //    if (showNext == true) {
    //        next_fs.show();
    //        current_fs.animate({ opacity: 0 }, {
    //            step: function (now) {
    //                // for making fielset appear animation
    //                opacity = 1 - now;
    //                current_fs.css({
    //                    'display': 'none',
    //                    'position': 'relative'
    //                });
    //                next_fs.css({ 'opacity': opacity });
    //            },
    //            duration: 600
    //        });
    //    }
    //    else
    //        alert("Todas las preguntas denben tener valores para mostrar al usuarios final por favor verifique que tenag almenos uno");
    //    //hide the current fieldset with style
        
    //});

    $(".previous").click(function () {
        debugger;
        contador -=1
        current_fs = $(this).parent().parent().parent().parent().parent();
        previous_fs = $(this).parent().parent().parent().parent().parent().prev();
        //Remove class active
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");
        if (contador == -1){
            $(".titulo-dimension").text("Aspectos Demográficos");
            $(".descripcion-dimension").text("País, Ciudad, Unidad de Negocio, Área");
        }else{
            $(".titulo-dimension").text(tituloDimension[contador]);
        }
        
        //show the previous fieldset
        previous_fs.show();
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

    $('.radio-group .radio').click(function () {
        $(this).parent().find('.radio').removeClass('selected');
        $(this).addClass('selected');
    });
});
//eliminar Preguntas
let deleteQuestion = document.querySelectorAll("#DeletQuestion");

deleteQuestion.forEach(function (trash) {
    trash.addEventListener('click', function (e) {
        let divDelete = e.target.closest("#FilaPregunta");
        let linedelete = divDelete.nextElementSibling;
        console.log(linedelete)
        linedelete.remove();
        divDelete.remove();
    })

});

//Eliminar Opcion de pregunta
function EliminaOpcionOne(element) {
    let divDelete = element.closest("#OpcionPregunta");
    let countElements = divDelete.parentElement.querySelectorAll("#OpcionPregunta").length;
    if (countElements > 1) {
        divDelete.remove();
    } else {
        divDelete.querySelector("#with-placeholder").innerHTML = "";
        divDelete.querySelector("#with-placeholder").value = "";
    }
}
    
let agregaOpcion =document.querySelectorAll("#AgregaOpcion");

//Agregar Opciones de pregunta
agregaOpcion.forEach(function (addOption) {
    addOption.addEventListener('click', function (e) {
        let addDiv = e.target.closest(".justify-content-start").previousElementSibling;
        let hijo = addDiv.querySelector("#OpcionPregunta");
        let newOpcion = hijo.cloneNode(true);
        newOpcion.querySelector("#with-placeholder").innerHTML = "";
        newOpcion.querySelector("#with-placeholder").value = "";
        newOpcion.style.display = "block";
        addDiv.appendChild(newOpcion);
    })

});

//sobreescribir los datos de la pregunta
let btnGuardar = document.querySelectorAll("#GuardaPregunta");
btnGuardar.forEach(function (btn) {
    btn.addEventListener('click', function (e) {
        let poscicion = Array.from(btnGuardar).indexOf(e.target);
        let divCambiar = e.target.closest(".justify-content-start").previousElementSibling.parentElement;
        //agregar los datos de la nueva pregunta
        let NuevaPregunta = divCambiar.querySelector(".custom-survey-input").value;
        //Div Completo pregunta
        let saveDiv = document.querySelectorAll(".question_data")[poscicion];
        let Descripciont = document.querySelectorAll("textarea").value
        saveDiv.querySelector(".bold-questions").innerHTML = NuevaPregunta;
        document.querySelectorAll("#PreguntaCa")[poscicion].value = NuevaPregunta;
        document.querySelectorAll("#Descripcion")[poscicion].value = Descripciont;
        //agregar las nuevas opciones
        let newOptions = divCambiar.querySelectorAll("#with-placeholder");
        let options = saveDiv.querySelector(".row");
        options.querySelector(".col-4").style.height = "auto";
        let option = options.querySelector(".col-4");
        
        let newOption = option.cloneNode(true);
        while (options.hasChildNodes()) {
            options.removeChild(options.firstChild);
        }
        for (let i = 0; i < newOptions.length; i++){
            let optionAdd = newOption.cloneNode(true)
            optionAdd.querySelector(".block").innerHTML = i + 1;
            optionAdd.querySelector("#strongly-disagree").innerHTML = newOptions[i].value
            optionAdd.querySelector("#opcionP").value = newOptions[i].value
            let valuejson = optionAdd.querySelector("#opcionP").name;
            let newvalue = valuejson.replace("Opciones[0]", "Opciones[" + i + "]");
            optionAdd.querySelector("#opcionP").name = newvalue;
            options.appendChild(optionAdd);
        }
        console.log(options);
        let modal = document.querySelectorAll(".modal")[poscicion];
        modal.classList.remove("show");
        modal.removeAttribute("aria-modal");
        modal.style.display = "none";
        modal.setAttribute("aria-hidden", "true");
        document.querySelector(".modal-backdrop").remove();
        
    })

});



