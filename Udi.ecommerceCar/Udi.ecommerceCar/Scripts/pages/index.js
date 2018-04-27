/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES
    3. LLAMAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */
var moveToSectionButtons = document.getElementsByClassName('moveToSection');
var hamburgerIcon = document.getElementById('hamburgerIcon');
var navheaderLinks = document.getElementById('navheaderLinks');

/* 2. FUNCIONES */
function activateMoveToSection() {
    Array.prototype.forEach.call(moveToSectionButtons, link => {
        link.addEventListener('click', function () {
            moveToSection(link.dataset.section);
        });
    });
}

function activateToggleMenu() {
    hamburgerIcon.addEventListener('click', function () {
        toggleClass(navheaderLinks, 'navheader-links--open');
        toggleClass(hamburgerIcon, 'hamburger-icon--open');
    });
}

/* 3. LLAMAR FUNCIONES */
if (moveToSectionButtons)
    activateMoveToSection();

if (hamburgerIcon)
    activateToggleMenu();
