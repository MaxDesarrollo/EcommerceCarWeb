

function moveToSection(sectionId, duration) {
    console.log('entra');
    duration = duration ? duration : 1000;

    $("html, body").animate({ scrollTop: $('#' + sectionId).offset().top }, duration);
}

function toggleClass(elemento, clase) {
    elemento.classList.toggle(clase);
}