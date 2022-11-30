$(document).ready(function () {


    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;

    $(".next").click(function () {
        debugger;
        current_fs = $(this).parent().parent().parent().parent().parent();
        next_fs = $(this).parent().parent().parent().parent().parent().next();
        //Add Class Active
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");
        //show the next fieldset
        next_fs.show();
        //hide the current fieldset with style
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
    });
    $(".previous").click(function () {
        current_fs = $(this).parent().parent().parent().parent().parent();
        previous_fs = $(this).parent().parent().parent().parent().parent().prev();
        //Remove class active
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");
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
            },
            duration: 600
        });
    });

    $('.radio-group .radio').click(function () {
        $(this).parent().find('.radio').removeClass('selected');
        $(this).addClass('selected');
    });

    $(".submit").click(function () {
        return false;
    })

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
    }
}
    
let agregaOpcion =document.querySelectorAll("#AgregaOpcion");

//Agregar Opciones de pregunta
agregaOpcion.forEach(function (addOption) {
    addOption.addEventListener('click', function (e) {
        let addDiv = e.target.closest(".justify-content-start").previousElementSibling;
        let hijo = addDiv.querySelector("#OpcionPregunta");
        let newOpcion = hijo.cloneNode(true);
        newOpcion.querySelector("#with-placeholder").innerHTML="";
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



