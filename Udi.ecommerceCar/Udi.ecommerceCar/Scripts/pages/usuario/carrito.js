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
    var cantidad = item.cantidad;
    var precio = item.precio ? (item.precio * cantidad).toFixed(2) : "0.00";
    
    //Creo un string selected con la opcion seleccionada en la cantidad correcta
    var slt = createSelectWidthQuantitySelected(10, cantidad, item.id);
    console.log(item);

    var cartItemHtml = `
        <div class="cart-item">
            <div class="cart-item-information">
                <div class="cart-item-information-image">
                    <img src="../../Images/${item.tipo}/${item.nombre}.jpg" alt="${item.nombre}"/>
                </div>

                <div class="cart-item-information-description">
                    <div class="cart-item-information-name">
                        <a href="/Producto/Detalle/${item.id}">${item.nombre}</a>
                    </div>

                    <div class="cart-item-information-tipo">
                        ${item.tipo}
                    </div>

                    <span class="cart-item-information-stock">
                        En stock
                    </span>

                    <div class="cart-item-information-options">
                        <span class="cart-item-information-delete">Eliminar</span>
                    </div>
                </div>
            </div>

            <div class="cart-item-quantity">
                ${slt}
            </div>

            <div class="cart-item-price">
                Bs. ${precio}
            </div>

            <div class="cart-item-ship-price">
                Gratis
            </div>
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
            addToCart("producto", resultado.Data.ProductoID, resultado.Data.Nombre, quantity, resultado.Data.Precio, resultado.Data.TipoProducto);

            ev.target.setAttribute("data-current-quantity", newQuantity);
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

    console.log("Por ahora el envio es cero siempre, no hay forma de escoger el metodo de envio");
    cartEnvio.innerText = (0).toFixed(2);

    var total = subtotal + 0;
    cartTotal.innerText = total.toFixed(2);
}

function init() {

    if (localStorage.getItem("carrito")) {
        var carrito = JSON.parse(localStorage.getItem("carrito"));
        var prods = carrito.productos;

        _datosProductosCarrito = prods;
        mostrarDatosProductosCarrito();
        activateSelectOnChangeQuantity();

        refreshValuesCart();
    }
    
}

/* 3. INICIAR FUNCIONES */
init();