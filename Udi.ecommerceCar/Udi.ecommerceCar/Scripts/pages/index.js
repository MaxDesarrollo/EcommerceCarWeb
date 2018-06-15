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
    console.log(res);
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

function obtenerProductosPrincipales() {
    var url = "/Producto/ObtenerProductosPrincipales";
    var tipo = "GET";
    var datos = {};

    var tipoDatos = "JSON";
    solicitudAjax(url, obtenerProductosPrincipalesExitoso, datos, tipoDatos, tipo);
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
}

init();