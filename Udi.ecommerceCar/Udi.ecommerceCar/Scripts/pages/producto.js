/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES GENERALES
    3. OBTENER PRODUCTOS
    4. INICIAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */
var _datosProductos;

/* 2. FUNCIONES GENERALES */


function getProductCardHtml(nombre, descripcion, urlImagen, tipoProducto, precio) {
    var productCardHtml =
        `<div class="product-card">
            <div class="product-card-header">
                <span class="product-card-title">${nombre}</span>
            </div>

            <div class ="product-card-image" style="background-image: url('Images/${tipoProducto}/${nombre}.jpg')">
            </div>

            <div class="product-card-detail">
                <div class="product-card-price">
                    $${precio}
                </div>

                <button class="btnProductCardAddtoCart">
                    Add to cart
                </button>
            </div>
        </div>`;

    //<span class="product-card-description">${descripcion}</span>
    //<img src="Images/${tipoProducto}/${nombre}.jpg" alt="${nombre}">

    return productCardHtml;
}

/* 3. OBTENER PRODUCTOS */
function mostrarDatosProductos() {
    //limpiarTabla('tblProductos');
    //$.each(_datosProducto, function (index, elemento) {
    //    var fila = $('<tr>').attr('id', elemento.PkProducto);
    //    var input = crearSpan("lblEditProducto" + index, "spanHyperLink", elemento.Nombre);
    //    eventoActualizarProducto(input, elemento);
    //    fila.append(col(input));
    //    fila.append(col(elemento.Precio).addClass("alinearDerecha"));
    //    fila.append(col(elemento.Stock).addClass("alinearDerecha"));
    //    fila.append(col(elemento.Tipo).addClass("alinearIzquierda"));
    //    fila.append(col(AccionColumna(function (e) { mostrarModalEliminarProducto(e, elemento) }
    //        , 'trash', 'Eliminar')).addClass("alinearCentro"));
    //    $('#tblProductos tbody').append(fila);
    //});

    var listaProductCardHtml = '';
    _datosProductos.forEach(function (producto) {
        listaProductCardHtml += getProductCardHtml(producto.Nombre, producto.Descripcion, producto.Nombre, producto.TipoProducto, 65);
    });

    $("#productos .product-card-container").html(listaProductCardHtml);
}

function obtenerProductosExitoso(resultado) {
    //console.log(resultado);
    if (resultado.Success) {
        _datosProductos = resultado.Data;
        //console.log(_datosProductos);
        //_datosTipo = resultado.Data.Tipos;

        mostrarDatosProductos();
        //cargarComboTipo();
    } else {
        toastr.error(resultado.Mensaje);
    }
}

function init() {
    var url = "/Producto/ObtenerProductos";
    var tipo = 'GET';
    var datos = {};
    var tipoDatos = 'JSON';
    solicitudAjax(url, obtenerProductosExitoso, datos, tipoDatos, tipo);
}

/* 4. INICIAR FUNCIONES */
init();