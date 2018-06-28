/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES GENERALES
    3. OBTENER SERVICIOS
    4. INICIAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */
var _datosServicios;
var page = 0;
var size = 20;

/* 2. FUNCIONES GENERALES */


function getServiceCardHtml(id, nombre, urlImagen) {
    var serviceCardHtml =
        `<div class="service-card">
            <a href="/Servicio/Detalle/${id}"><img src="/Images/Servicios/${nombre}.jpg" alt="${nombre}" /></a>

            <div class="service-card-description">
                <a href="Servicio/Detalle/${id}">${nombre}</a>
            </div>
        </div>`;

    //<span class="product-card-description">${descripcion}</span>
    //<img src="Images/${tipoProducto}/${nombre}.jpg" alt="${nombre}">

    return serviceCardHtml;
}

/* 3. OBTENER SERVICIOS */
function mostrarDatosServicios() {
    var listaServiceCardHtml = '';
    _datosServicios.forEach(function (servicio) {
        listaServiceCardHtml += getServiceCardHtml(servicio.ServicioId, servicio.TipoServicio, servicio.TipoServicio);
    });

    $("#servicios .service-card-container").html(listaServiceCardHtml);
}

function obtenerServiciosExitoso(resultado) {
    if (resultado.Success) {
        _datosServicios = resultado.Data;
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
    var datos = {
        page: page,
        size: size
    };

    var tipoDatos = 'JSON';
    solicitudAjax(url, obtenerServiciosExitoso, datos, tipoDatos, tipo);
}

/* 4. INICIAR FUNCIONES */
init();

