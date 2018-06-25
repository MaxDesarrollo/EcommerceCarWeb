/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES GENERALES
    3. FUNCIONES REGISTRO
    4. INICIAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */
var solicitandoRegistro = false;

/* 2. FUNCIONES GENERALES */

/* 3. FUNCIONES REGISTRO */
function registrarUsuarioExitoso(res) {
    if (res.Success) {
        toastr.success("Usuario registrado exitosamente!");

        iniciarSesion(res.Data.Username, res.Data.Password);
        setTimeout(function() {
            location.href = "/Producto";
        }, 3000);
    } else {
        if (res.Mensaje !== "error") {
            toastr.error(res.Mensaje);
        } else {
            toastr.error("Ocurrió un problema al intentar registrar al cliente, por favor verificar los datos e intentar nuevamente");
        }
    }

    solicitandoRegistro = false;
}

function registrar() {
    if (solicitandoRegistro) {
        return;
    }
    solicitandoRegistro = true;

    var url = "/Usuario/RegistrarUsuario";
    var tipo = "POST";
    var usuario = {
        Nombre: document.getElementById("txtRegisterNombre").value,
        Apellido: document.getElementById("txtRegisterApellido").value,
        Username: document.getElementById("txtRegisterUsername").value,
        Password: document.getElementById("txtRegisterPassword").value
    };
    usuario = JSON.stringify(usuario);
    var datos = {
        usuarioString: usuario
    };

    var tipoDatos = "JSON";
    
    solicitudAjax(url, registrarUsuarioExitoso, datos, tipoDatos, tipo);
}

/* 4. INICIAR FUNCIONES */
document.getElementById("btnRegistrar").addEventListener("click", function() {
    registrar();
});