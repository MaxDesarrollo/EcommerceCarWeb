/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES
    3. INICIAR FUNCIONES
*/

/*#region 1. VARIABLES GLOBALES */
var btnAddToCartProducto = document.getElementById("btnAddToCartProducto");

/*#region 2. FUNCIONES */


function addToCart(tipo, id, cantidad, nombre) {
    //console.log('Añadir al carrito un producto ' + tipo + " con id " + id);
    var carrito, newProducto;

    if (localStorage.getItem("carrito")) {
        //console.log("Existe el carrito asi que lo obtengo y lo guardo encima este producto");
        // Obtener el carrito
        // Parsearlo para poder manipularlo
        // Aumentar el nuevo producto
        // Guardar de nuevo el carrito en el localStorage

        //newProducto = {
        //    id: id,
        //    cantidad: cantidad
        //}

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
                prods[i].cantidad = cant;
                repeated = true;
            }
        }

        // Si no lo encuentra en el carrito lo aumenta
        if (!repeated) {
            newProducto = {
                id: id,
                cantidad: cantidad
            }
            prods.push(newProducto);
        }

        carrito.productos = prods;
        carrito = JSON.stringify(carrito);

        localStorage.setItem("carrito", carrito);

        console.log(carrito);
        toastr.success(nombre + " añadido al carrito!");


    } else {
        //console.log("No existe el carrito todavia por lo que lo creare de cero y le pondre el nuevo producto solicitado");

        carrito = {
            productos: []
        };
        newProducto = {
            id: id,
            cantidad: cantidad
        }

        carrito.productos.push(newProducto);
        carrito = JSON.stringify(carrito);
        localStorage.setItem("carrito", carrito);
        toastr.success(nombre + " añadido al carrito!");
    }
}

/*#region 3. INICIAR FUNCIONES */
if (btnAddToCartProducto) {
    btnAddToCartProducto.addEventListener("click", function () {
        var url = window.location.href;
        var startId = url.indexOf("Detalle/") + 8;
        var id = url.substr(startId);
        var cantidad = document.getElementById("sltCantidadProducto").value;
        var nombre = document.getElementById("detalleArticuloTitulo").innerHTML;

        addToCart("producto", id, cantidad, nombre);
    });
}

var carr = localStorage.getItem("carrito");
console.log(carr);