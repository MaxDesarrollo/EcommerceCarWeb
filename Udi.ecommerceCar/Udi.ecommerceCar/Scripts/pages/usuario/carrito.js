/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES
    3. INICIAR FUNCIONES
*/

/*#region 1. VARIABLES GLOBALES */

var _datosProductosCarrito;

var sltQuantityCartProduct = document.getElementsByClassName("sltQuantityCartProduct");

var cartSubtotal = document.getElementById("cartSubtotal"),
    cartEnvio = document.getElementById("cartEnvio"),
    cartTotal = document.getElementById("cartTotal");

var btnSolicitarPedido = document.getElementById("btnSolicitarPedido");

var solicitandoPedido = false;

//var subtotal = 0;

/*#region 2. FUNCIONES */

function createSelectWidthQuantitySelected(quantity, selectedQuantity, dataId) {
    var clase = "sltQuantityCartProduct";

    var slt = "<select class='" + clase + "' data-id='" + dataId + "' data-current-quantity='" + selectedQuantity + "'>";
    for (var i = 1; i <= quantity; i++) {
        var selected = "";
        if (i == selectedQuantity) {
            selected = "selected";
        }
        slt += "<option value='" + i + "' " + selected + ">" + i + "</option>";
    }

    slt += "</select>";

    return slt;
}

function getCartItemHtml(item) {
    var cantidad = item.Cantidad;
    var precio = item.Precio ? (item.Precio * cantidad).toFixed(2) : "0.00";
    
    //Creo un string selected con la opcion seleccionada en la cantidad correcta
    var slt = createSelectWidthQuantitySelected(10, cantidad, item.ProductoId);

    var cartItemHtml = `
        <div class="cart-item">
            <div class="cart-item-information">
                <div class="cart-item-information-image">
                    <img src="../../Images/${item.TipoProducto}/${item.Nombre}.jpg" alt="${item.Nombre}"/>
                </div>

                <div class="cart-item-information-description">
                    <div class="cart-item-information-name">
                        <a href="/Producto/Detalle/${item.ProductoId}">${item.Nombre}</a>
                    </div>

                    <div class="cart-item-information-tipo">
                        ${item.TipoProducto}
                    </div>

                    <span class="cart-item-information-stock">
                        En stock
                    </span>

                    <div class="cart-item-information-options">
                        <span class="cart-item-information-delete" data-producto-id="${item.ProductoId}">Eliminar</span>
                    </div>
                </div>
            </div>

            <div class="cart-item-quantity">${slt}</div>
            <div class="cart-item-price">Bs. ${precio}</div>
            <div class="cart-item-ship-price">Gratis</div>
        </div>`;

    return cartItemHtml;
}

function mostrarDatosProductosCarrito() {
    var cartItemListHtml = "";
    _datosProductosCarrito.forEach(function (producto) {
        cartItemListHtml += getCartItemHtml(producto);
    });

    document.getElementById("cartContainer").innerHTML = cartItemListHtml;
}

function selectOnChangeQuantity(ev) {
    var id = ev.target.dataset.id;
    var oldQuantity = ev.target.dataset.currentQuantity;
    var newQuantity = ev.target.value;
    var quantity = newQuantity - oldQuantity;
    // Lo dejo en negativo para que reste cuando quiera agregarlo al carrito, tecnicamente le restaria la diferencia entre el valor actual y el anterior

    // Hacer llamada a la BD para que de alla devuelva el objeto, verificando asi su existencia y que devuelva los datos correctos.
    obtenerDetalleProducto(id, function (resultado) {
        if (resultado.Success) {
            addToCart("producto", resultado.Data.ProductoId, resultado.Data.Nombre, quantity, resultado.Data.Precio, resultado.Data.TipoProducto);

            ev.target.setAttribute("data-current-quantity", newQuantity);
            var precioText = ev.target.parentElement.parentElement.getElementsByClassName("cart-item-price")[0];
            if (precioText) {
                precioText.innerText = "Bs. " + (newQuantity * resultado.Data.Precio).toFixed(2);
            }
            refreshValuesCart();
        }
    });
}

function activateSelectOnChangeQuantity() {
    for (var i = 0; i < sltQuantityCartProduct.length; i++) {
        sltQuantityCartProduct[i].addEventListener("change", function(ev) {
            selectOnChangeQuantity(ev);
        });
    }
}

function refreshValuesCart() {
    cartSubtotal.innerText = subtotal.toFixed(2);

    //console.log("Por ahora el envio es cero siempre, no hay forma de escoger el metodo de envio");
    cartEnvio.innerText = (0).toFixed(2);

    var total = subtotal + 0;
    cartTotal.innerText = total.toFixed(2);
}


function metodoSolicitarPedidoProductoExitoso(res) {
    if (res.Success) {
        toastr.success("Se ha realizado tu pedido. Se lo redireccionará a un detalle");

        localStorage.removeItem("carrito");
        refreshValuesCart();

        setTimeout(function() {
            window.location.href = "/VentaProducto/Detalle/" + res.Data;
        }, 2500);
    } else {
        toastr.error("Ocurrió un error mientras se realizaba el pedido. Por favor, intente nuevamente");
    }

    solicitandoPedido = false;
}

function solicitarPedidoProducto(idUsuario, listaProductos) {
    if (solicitandoPedido) {
        return;
    }
    solicitandoPedido = true;

    var url = "/Producto/SolicitarPedidoProducto";
    var tipo = "POST";
    var datos = {
        idUsuario: idUsuario,
        listaProductosString: listaProductos
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, metodoSolicitarPedidoProductoExitoso, datos, tipoDatos, tipo);
}


function deleteItemFromCart(event) {
    var id = event.target.dataset.productoId;
    if (id == null) {
        toastr.error("Existe un problema con el producto seleccionado");
        return;
    }

    var carrito = JSON.parse(localStorage.getItem("carrito"));
    var prods = carrito.productos;
    //console.log(prods);

    var repeated = false;
    for (var i = 0; i < prods.length; i++) {
        if (repeated) {
            break;
        }

        if (prods[i].ProductoId == id) {
            prods.splice(i, 1);

            repeated = true;
        }
    }

    if (repeated) {
        carrito.productos = prods;
        carrito = JSON.stringify(carrito);

        localStorage.setItem("carrito", carrito);

        getCartInfoList();
        event.target.parentElement.parentElement.parentElement.parentElement.innerHTML = `<div class="mensaje-grande"><strong>Producto eliminado satisfactoriamente!</strong></div>`;
    } else {
        toastr.error("No se pudo realizar la acción, por favor inténtelo nuevamente.");
    }
}

function activateDeleteItemFromCart() {
    var itemDeleteList = document.getElementsByClassName("cart-item-information-delete");

    for (var i = 0; i < itemDeleteList.length; i++) {
        itemDeleteList[i].addEventListener("click", function (event) {
            deleteItemFromCart(event);
        });
    }

}

function init() {

    var carrito = JSON.parse(localStorage.getItem("carrito"));
    if (carrito.productos && carrito.productos.length > 0) {
        
        var prods = carrito.productos;

        _datosProductosCarrito = prods;
        mostrarDatosProductosCarrito();
        activateSelectOnChangeQuantity();

        refreshValuesCart();
        activateDeleteItemFromCart();

        if (btnSolicitarPedido) {
            btnSolicitarPedido.addEventListener("click", function() {
                var idUsuario = localStorage.getItem("usuarioId");
                if (idUsuario == null) {
                    location.href = "/Usuario/Registro";
                }

                var productos = JSON.parse(localStorage.getItem("carrito"));

                productos = JSON.stringify(productos.productos);

                solicitarPedidoProducto(idUsuario, productos);
            });
        }
    }
    
}

/* 3. INICIAR FUNCIONES */
init();