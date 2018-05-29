/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES
    3. LLAMAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */


/* 2. FUNCIONES */

function obtenerDetalleProducto(pk, metodoObtenerDetalleProductoExitoso) {
    var url = "/Producto/ObtenerProducto";
    var tipo = "POST";
    var datos = {
        pk: pk
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, metodoObtenerDetalleProductoExitoso, datos, tipoDatos, tipo);
}

/* 3. LLAMAR FUNCIONES */


