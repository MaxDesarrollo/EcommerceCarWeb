/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES GENERALES
    3. OBTENER SERVICIOS
    4. INICIAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */
var _datosServicios;

/* 2. FUNCIONES GENERALES */


function getServiceCardHtml(nombre, urlImagen) {
    var serviceCardHtml =
        `<div class="service-card" style="background-image: url('Images/Servicios/${nombre}.jpg')">
            <div class="service-card-description">
                ${nombre}
            </div>
        </div>`;

    //<span class="product-card-description">${descripcion}</span>
    //<img src="Images/${tipoProducto}/${nombre}.jpg" alt="${nombre}">

    return serviceCardHtml;
}

/* 3. OBTENER PRODUCTOS */
function mostrarDatosServicios() {
    var listaServiceCardHtml = '';
    _datosServicios.forEach(function (servicio) {
        listaServiceCardHtml += getServiceCardHtml("", "");
    });

    $("#servicios .service-card-container").html(listaServiceCardHtml);
}

function obtenerServiciosExitoso(resultado) {
    console.log(resultado);
    if (resultado.Success) {
        _datosServicios = resultado.Data;
        console.log(_datosServicios);
        //_datosTipo = resultado.Data.Tipos;

        mostrarDatosServicios();
        //cargarComboTipo();
    } else {
        toastr.error(resultado.Mensaje);
    }
}

function init() {
    var url = "/Servicio/ObtenerServicios";
    var tipo = 'GET';
    var datos = {};
    var tipoDatos = 'JSON';
    solicitudAjax(url, obtenerServiciosExitoso, datos, tipoDatos, tipo);
}

/* 4. INICIAR FUNCIONES */
init();