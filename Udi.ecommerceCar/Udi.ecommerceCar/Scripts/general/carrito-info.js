/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES
    3. INICIAR FUNCIONES
*/

/*#region 1. VARIABLES GLOBALES */
var btnAddToCartProducto = document.getElementById("btnAddToCartProducto");
var cartInfoListContainer = document.getElementById("cartInfoListContainer"),
    cartInfoListItemContainer = document.getElementById("cartInfoListItemContainer"),
    cartInfoIcon = document.getElementById("cartInfoIcon");

var cartInfoSubtotal = document.getElementById("cartInfoSubtotal"),
    cartInfoEnvio = document.getElementById("cartInfoEnvio"),
    cartInfoTotal = document.getElementById("cartInfoTotal");

var subtotal = 0;

/*#region 2. FUNCIONES */

function addToCart(categoria, id, nombre, cantidad, precio, tipo) {
    var carrito, newProducto;

    if (localStorage.getItem("carrito")) {
        var message = " añadido al carrito!";

        carrito = JSON.parse(localStorage.getItem("carrito"));
        var prods = carrito.productos;

        // Lo busca si ya existe en el carrito
        var repeated = false;
        for (var i = 0; i < prods.length; i++) {
            if (repeated) {
                break;
            }

            if (prods[i].id === id) {
                var cant = parseInt(prods[i].cantidad) + parseInt(cantidad);
                cant *= 1;
                prods[i].cantidad = cant;

                repeated = true;
                message = " cambiado en el carrito!";
            }
        }

        // Si no lo encuentra en el carrito lo aumenta
        if (!repeated) {
            newProducto = {
                id: id,
                nombre: nombre,
                cantidad: cantidad,
                precio: precio,
                tipo: tipo
            }
            prods.push(newProducto);

            message = " añadido al carrito!";
        }

        carrito.productos = prods;
        carrito = JSON.stringify(carrito);

        localStorage.setItem("carrito", carrito);

        toastr.success(nombre + message);


    } else {
        carrito = {
            productos: []
        };
        newProducto = {
            id: id,
            nombre: nombre,
            cantidad: cantidad,
            precio: precio,
            tipo: tipo
        }

        carrito.productos.push(newProducto);
        carrito = JSON.stringify(carrito);
        localStorage.setItem("carrito", carrito);
        toastr.success(nombre + " añadido al carrito!");
    }

    getCartInfoList();
}

function deleteItemFromCartInfo(event) {
    var id = event.target.parentElement.dataset.cartListItemId;
    if (id == null) {
        console.log("No existe el ID seleccionado");
        return;
    }

    var carrito = JSON.parse(localStorage.getItem("carrito"));
    var prods = carrito.productos;
    console.log(prods);

    var repeated = false;
    for (var i = 0; i < prods.length; i++) {
        console.log(id, prods[i]);
        if (repeated) {
            break;
        }

        if (prods[i].id == id) {
            prods.splice(i, 1);

            repeated = true;
        }
    }

    if (repeated) {
        carrito.productos = prods;
        carrito = JSON.stringify(carrito);

        localStorage.setItem("carrito", carrito);

        console.log(carrito);

        getCartInfoList();
    } else {
        toastr.error("No se pudo realizar la acción, por favor inténtelo nuevamente.");
    }
}

function activateDeleteItemFromCartInfo() {
    var itemDeleteList = document.getElementsByClassName("cart-info-list-item-delete");

    for (var i = 0; i < itemDeleteList.length; i++) {
        itemDeleteList[i].addEventListener("click", function (event) {
            deleteItemFromCartInfo(event);
        });
    }

}

function createCartInfoListItem(item) {
    var cartInfoListItem = `
                <div class ="cart-info-list-item" data-cart-list-item-id="${item.id}">
                    <div class="cart-info-list-item-image">
                        <img src="/Images/${item.tipo}/${item.nombre}.jpg" />
                    </div>
                    <span class ="cart-info-list-item-nombre">${item.nombre}</span>
                    <span>${item.cantidad}</span>
                    <span>Bs.${(item.precio * item.cantidad).toFixed(2)}</span>
                    <span class ="cart-info-list-item-delete">
                        <svg viewPort="0 0 12 12" version="1.1" width="13" height="13"
                             xmlns="http://www.w3.org/2000/svg">
                            <line x1="1" y1="11"
                                  x2="11" y2="1"
                                  stroke="black"
                                  stroke-width="2"/>
                            <line x1="1" y1="1"
                                  x2="11" y2="11"
                                  stroke="black"
                                  stroke-width="2"/>
                        </svg>
                    </span>
                </div>`;

    return cartInfoListItem;
}

function refreshValuesCartInfo() {
    cartInfoSubtotal.innerText = subtotal.toFixed(2);

    console.log("Por ahora el envio es cero siempre, no hay forma de escoger el metodo de envio");
    cartInfoEnvio.innerText = (0).toFixed(2);

    var total = subtotal + 0;
    cartInfoTotal.innerText = total.toFixed(2);
}

function sumSubtotal(precio, cantidad) {
    return (precio * cantidad);
}

function createCartInfoList() {
    var cartInfoListItems = "";
    subtotal = 0;

    if (localStorage.getItem("carrito")) {
        var carrito = JSON.parse(localStorage.getItem("carrito"));

        var productos = carrito.productos;
        for (var i = 0; i < productos.length; i++) {
            cartInfoListItems += createCartInfoListItem(productos[i]);
            subtotal += sumSubtotal(productos[i].precio, productos[i].cantidad);
        }
    } else {
        cartInfoListItems = "TODAVIA NO TIENE PRODUCTOS EN EL CARRITO";
    }

    return cartInfoListItems;
}

function getCartInfoList() {
    var cartListItems = createCartInfoList();
    refreshValuesCartInfo();

    cartInfoListItemContainer.innerHTML = cartListItems;
    activateDeleteItemFromCartInfo();
}



/*#region 3. INICIAR FUNCIONES */
if (btnAddToCartProducto) {
    btnAddToCartProducto.addEventListener("click", function () {
        var url = window.location.href;
        var startId = url.indexOf("Detalle/") + 8;
        var id = url.substr(startId);
        var cantidad = document.getElementById("sltCantidadProducto").value;

        // Hacer llamada a la BD para que de alla devuelva el objeto, verificando asi su existencia y que devuelva los datos correctos.
        obtenerDetalleProducto(id, function (resultado) {
            if (resultado.Success) {
                addToCart("producto", resultado.Data.ProductoID, resultado.Data.Nombre, cantidad, resultado.Data.Precio, resultado.Data.TipoProducto);
            }
        });

    });
}

if (cartInfoIcon) {
    cartInfoIcon.addEventListener("click", function () {
        cartInfoListContainer.classList.toggle("cart-info-list-container--show");
    });
}

//localStorage.removeItem("carrito");
getCartInfoList();