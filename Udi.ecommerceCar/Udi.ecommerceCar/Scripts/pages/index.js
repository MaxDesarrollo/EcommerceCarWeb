


function obtenerProductosPrincipales(obtenerProductoPrincipalesExitoso) {
    var url = "/Producto/ObtenerProductosPrincipales";
    var tipo = "GET";
    var datos = {};

    var tipoDatos = "JSON";
    solicitudAjax(url, obtenerProductoPrincipalesExitoso, datos, tipoDatos, tipo);
}


function obtenerServiciosPrincipales(obtenerServiciosPrincipalesExitoso) {
    var url = "/Servicio/ObtenerServiciosPrincipales";
    var tipo = 'GET';
    var datos = {};

    var tipoDatos = 'JSON';
    solicitudAjax(url, obtenerServiciosPrincipalesExitoso, datos, tipoDatos, tipo);
}


