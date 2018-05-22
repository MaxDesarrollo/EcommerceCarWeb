/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES
    3. LLAMADAS
*/

/* 1. VARIABLES GLOBALES */
//var loginUsername = document.getElementById("loginUsername"),
//    login = document.getElementById("loginContainer"),
//    loginNotRegistered = document.getElementById("loginNotRegistered");

/* 2. FUNCIONES */
function storageAvailable(type) {
    try {
        var storage = window[type],
            x = '__storage_test__';
        storage.setItem(x, x);
        storage.removeItem(x);
        return true;
    }
    catch (e) {
        return e instanceof DOMException && (
            // everything except Firefox
            e.code === 22 ||
            // Firefox
            e.code === 1014 ||
            // test name field too, because code might not be present
            // everything except Firefox
            e.name === 'QuotaExceededError' ||
            // Firefox
            e.name === 'NS_ERROR_DOM_QUOTA_REACHED') &&
            // acknowledge QuotaExceededError only if there's something already stored
            storage.length !== 0;
    }
}

//function mostrarMenuPerfil() {
//    login.classList.remove("login-container--show");
//    loginUsername.classList.add("login-username--show");
//    loginNotRegistered.classList.remove("login-not-registered--show");
//}

//function mostrarMenuIniciarSesion() {
//    loginUsername.classList.remove("login-username--show");
//    loginNotRegistered.classList.add("login-not-registered--show");
//}

//function verificarSesion() {
//    if (!localStorage.getItem("usuarioId")) {
//        console.log("No esta logueado, asi que hay que mostrar el menu de Iniciar sesion");
//        mostrarMenuIniciarSesion();
//    } else {
//        console.log("Esta logueado, asi que hay que mostrar el menu donde sale su nombre");
//        mostrarMenuPerfil();
//    }
//}

/* 3. LLAMADAS */
//if (storageAvailable('localStorage')) {
//    // Yippee! We can use localStorage awesomeness
//    verificarSesion();
//}
//else {
//    // Too bad, no localStorage for us
//    console.log("Ver qué hacer con estos navegadores.");
//}