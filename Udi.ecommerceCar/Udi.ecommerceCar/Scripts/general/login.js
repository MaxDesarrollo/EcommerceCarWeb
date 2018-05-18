/*
INDICE
1. VARIABLES GLOBALES
2. FUNCIONES GENERALES
3. OBTENER PRODUCTOS
4. INICIAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */
var _datosUsername;
var spanShowLogin = document.getElementById("spanShowLogin"),
    login = document.getElementById("loginContainer"),
    loginSubmit = document.getElementById("loginSubmit");
var txtLoginUsername = document.getElementById("txtLoginUsername"),
    txtLoginPassword = document.getElementById("txtLoginPassword");
var loginUsername = document.getElementById("loginUsername"),
    loginNotRegistered = document.getElementById("loginNotRegistered");


/* 2. FUNCIONES GENERALES */

function getProductCardHtml(id, nombre, descripcion, urlImagen, tipoProducto, precio) {

    if (precio === "Sin precio") {
        precio = "";
    } else precio = "Bs. " + precio;

    console.log(id);

    var productCardHtml =
        `<div class="product-card">
            <div class ="product-card-image" style="background-image: url('Images/${tipoProducto}/${nombre}.jpg')"></div>

            <div class="product-card-description">
                <div class ="product-card-header">
                    <span class ="product-card-title">
                        <a href="Producto/Detalle/${id}">${nombre}</a>
                    </span>
                </div>

                <div class ="product-card-detail">
                    <div class ="product-card-price">
                        ${precio}
                    </div>
                </div>
            </div>
        </div>`;

    //<span class="product-card-description">${descripcion}</span>
    //<img src="Images/${tipoProducto}/${nombre}.jpg" alt="${nombre}">

    return productCardHtml;
}

/* 3. OBTENER PRODUCTOS */
function mostrarDatosUsuario() {

    //var listaProductCardHtml = '';
    //_datosProductos.forEach(function (producto) {
    //    var precio = producto.Precio ? producto.Precio : "Sin precio";
    //    listaProductCardHtml += getProductCardHtml(producto.ProductoID, producto.Nombre, producto.Descripcion, producto.Nombre, producto.TipoProducto, precio);
    //});

    //$("#productos .product-card-container").html(listaProductCardHtml);

    console.log("mostrar datos del usuario porque se inicio sesion correctamente");

    loginUsername.innerText = _datosUsername.Nombre + " " + _datosUsername.Apellido;

    login.classList.remove("login-container--show");
    loginNotRegistered.classList.add("login-not-registered--hide");
    loginUsername.classList.add("login-username--show");
}

function iniciarSesionExitoso(resultado) {
    console.log('exito');
    if (resultado.Success) {
        _datosUsername = resultado.Data;
        mostrarDatosUsuario();
    } else {
        toastr.error(resultado.Mensaje);
    }
}

function iniciarSesion(username, password) {
    var url = "/Usuario/IniciarSesion";
    var tipo = "POST";
    var datos = {
        username: username,
        password: password
    };
    
    var tipoDatos = "JSON";
    solicitudAjax(url, iniciarSesionExitoso, datos, tipoDatos, tipo);
}

function init() {
    if (!spanShowLogin) {
        return;
    }

    spanShowLogin.addEventListener("click", function () {
        spanShowLogin.classList.toggle("span-show-login--active");
        login.classList.toggle("login-container--show");
    });

    loginSubmit.addEventListener("click", function () {
        console.log("adios");
        var username = txtLoginUsername.value;
        var password = txtLoginPassword.value;

        console.log("Iniciar sesion con " + username + ", " + password);
        iniciarSesion(username, password);
    });
}

/* 4. INICIAR FUNCIONES */
init();