/*
INDICE
1. VARIABLES GLOBALES
2. FUNCIONES GENERALES
3. FUNCIONES SESION
4. INICIAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */
var _datosUsername;
var spanShowLogin = document.getElementById("spanShowLogin"),
    loginSubmit = document.getElementById("loginSubmit");
var txtLoginUsername = document.getElementById("txtLoginUsername"),
    txtLoginPassword = document.getElementById("txtLoginPassword");

var loginUsername = document.getElementById("loginUsername"),
    login = document.getElementById("loginContainer"),
    loginNotRegistered = document.getElementById("loginNotRegistered"),
    usernameMenu = document.getElementById("usernameMenu");

var btnCerrarSesion = document.getElementById("btnCerrarSesion");


/* 2. FUNCIONES GENERALES */
window.addEventListener("storage", function (e) {
    verificarSesion();
    getCartInfoList();
});


/* 3. VERIFICAR SESION */

function mostrarMenuPerfil() {
    login.classList.remove("login-container--show");
    loginUsername.classList.add("login-username--show");
    loginNotRegistered.classList.remove("login-not-registered--show");

    loginUsername.innerText = localStorage.getItem("nombre") + " " + localStorage.getItem("apellido");
}

function mostrarMenuIniciarSesion() {
    loginUsername.classList.remove("login-username--show");
    loginNotRegistered.classList.add("login-not-registered--show");
}

function verificarSesion() {
    if (localStorage.getItem("usuarioId")) {
        mostrarMenuPerfil();
    } else {
        mostrarMenuIniciarSesion();
    }
}

function guardarDatosSesion() {
    localStorage.setItem("usuarioId", _datosUsername.UsuarioId);
    localStorage.setItem("username", _datosUsername.Username);
    localStorage.setItem("nombre", _datosUsername.Nombre);
    localStorage.setItem("apellido", _datosUsername.Apellido);
}

function iniciarSesionExitoso(resultado) {
    if (resultado.Success) {
        _datosUsername = resultado.Data;

        guardarDatosSesion();
        verificarSesion();

    } else {
        toastr.error(resultado.Mensaje);

    }
}

function iniciarSesion(username, password) {
    var url = "/Usuario/IniciarSesion";
    var tipo = "POST";
    var datos = {
        username: username,
        password: password
    };
    
    var tipoDatos = "JSON";
    solicitudAjax(url, iniciarSesionExitoso, datos, tipoDatos, tipo);
}

function init() {
    if (!spanShowLogin) {
        return;
    }

    spanShowLogin.addEventListener("click", function () {
        spanShowLogin.classList.toggle("span-show-login--active");
        login.classList.toggle("login-container--show");
    });

    loginSubmit.addEventListener("click", function () {
        var username = txtLoginUsername.value;
        var password = txtLoginPassword.value;

        spanShowLogin.classList.remove("span-show-login--active");

        iniciarSesion(username, password);
    });
}

/* 4. INICIAR FUNCIONES */
init();

if (storageAvailable('localStorage')) {
    // Yippee! We can use localStorage awesomeness
    verificarSesion();
}
else {
    // Too bad, no localStorage for us
    console.log("Ver qué hacer con estos navegadores.");
}

if (loginUsername) {
    loginUsername.addEventListener("click", function() {
        usernameMenu.classList.toggle("username-menu--show");
    });
}

if (btnCerrarSesion) {
    btnCerrarSesion.addEventListener("click", function() {
        localStorage.removeItem("usuarioId");
        localStorage.removeItem("username");
        localStorage.removeItem("nombre");
        localStorage.removeItem("apellido");

        usernameMenu.classList.remove("username-menu--show");

        verificarSesion();
    });
}
