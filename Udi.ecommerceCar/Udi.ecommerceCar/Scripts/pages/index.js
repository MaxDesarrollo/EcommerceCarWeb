function getVehiclePresentationHtml(id, nombre, urlImagen) {
    var vehicleCardHtml =
        `<div class ="vehicle-presentation">
			<div class ="vehicle-card-image">
				<img src="/Images/Vehiculos/${urlImagen}.png" alt="${nombre}">
			</div>

			<div class ="vehicle-card-header">
				<span class ="vehicle-presentation-title">
                    <a href="/Vehiculo/Detalle/${id}">${nombre}</a>
                </span>
			</div>
		</div>
        `;

    return vehicleCardHtml;
}

function obtenerVehiculosPrincipalesExitoso(res) {
    if (res.Success) {
        var listaVehicleCardHtml = "";
        var vehiculosPrincipales = res.Data;

        vehiculosPrincipales.forEach(function (vehiculo) {
            listaVehicleCardHtml += getVehiclePresentationHtml(vehiculo.VehiculoId, vehiculo.NombreModelo, vehiculo.NombreModelo);
        });

        $("#vehiculos .vehicle-card-container").html(listaVehicleCardHtml);
    }
}

function obtenerVehiculosPrincipales() {
    var url = "/Vehiculo/ObtenerVehiculosPrincipales";
    var tipo = "GET";
    var datos = {};
    
    var tipoDatos = "JSON";
    solicitudAjax(url, obtenerVehiculosPrincipalesExitoso, datos, tipoDatos, tipo);
}


function getProductCardHtml(id, nombre, descripcion, urlImagen, tipoProducto, precio) {

    if (precio === "Sin precio") {
        precio = "";
    } else precio = "Bs. " + precio;

    var productCardHtml =
        `<div class="product-card">
            <div class ="product-card-image" style="background-image: url('/Images/${tipoProducto}/${nombre}.jpg')"></div>

            <div class="product-card-description">
                <div class ="product-card-header">
                    <span class ="product-card-title">
                        <a href="/Producto/Detalle/${id}">${nombre}</a>
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

function obtenerProductosPrincipalesExitoso(res) {
    if (res.Success) {
        var listaProductCardHtml = "";
        var productosPrincipales = res.Data;

        productosPrincipales.forEach(function (producto) {
            listaProductCardHtml += getProductCardHtml(producto.ProductoId, producto.Nombre, producto.Descripcion, producto.Nombre, producto.TipoProducto, producto.Precio);
        });

        $("#productos .product-card-container").html(listaProductCardHtml);
    }
}

function obtenerProductosPrincipales() {
    var url = "/Producto/ObtenerProductosPrincipales";
    var tipo = "GET";
    var datos = {};

    var tipoDatos = "JSON";
    solicitudAjax(url, obtenerProductosPrincipalesExitoso, datos, tipoDatos, tipo);
}

function getServiceCardHtml(id, nombre, urlImagen) {
    var serviceCardHtml =
        `<div class="service-card">
            <a href="/Servicio/Detalle/${id}"><img src="/Images/Servicios/${nombre}.jpg" alt="${nombre}" /></a>

            <div class="service-card-description">
                <a href="/Servicio/Detalle/${id}">${nombre}</a>
            </div>
        </div>`;

    //<span class="product-card-description">${descripcion}</span>
    //<img src="Images/${tipoProducto}/${nombre}.jpg" alt="${nombre}">

    return serviceCardHtml;
}

function obtenerServiciosPrincipalesExitoso(res) {
    if (res.Success) {
        var listaServiceCardHtml = "";
        var serviciosPrincipales = res.Data;

        serviciosPrincipales.forEach(function (servicio) {
            listaServiceCardHtml += getServiceCardHtml(servicio.ServicioId, servicio.TipoServicio, servicio.TipoServicio);
        });

        $("#servicios .service-card-container").html(listaServiceCardHtml);
    }
}

function obtenerServiciosPrincipales() {
    var url = "/Servicio/ObtenerServiciosPrincipales";
    var tipo = 'GET';
    var datos = {};

    var tipoDatos = 'JSON';
    solicitudAjax(url, obtenerServiciosPrincipalesExitoso, datos, tipoDatos, tipo);
}


function init() {
    obtenerVehiculosPrincipales();
    obtenerProductosPrincipales();
    obtenerServiciosPrincipales();
}

init();