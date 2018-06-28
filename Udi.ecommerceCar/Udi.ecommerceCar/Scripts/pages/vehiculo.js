/*
    INDICE
    1. VARIABLES GLOBALES
    2. FUNCIONES GENERALES
    3. OBTENER VEHICULOS
    4. INICIAR FUNCIONES
*/

/* 1. VARIABLES GLOBALES */
var _datosVehiculos;
var indexVehicleCardActive = 1, nextCard = -1, previousCard = 1;
var vehicleCardContainer = document.getElementsByClassName('vehicle-card-container')[0];
var movePosVehicleCardContainer = 30, curPosVehicleCardContainer = 0;
var minLimit = -90, maxLimit = 30;
var vehicleCards;

var page = 0,
    size = 20;


/* 2. FUNCIONES GENERALES */

function getVehicleCardHtml(nombre, urlImagen, activado) {
    activado = typeof activado !== 'undefined' ? activado : '';

    var vehicleCardHtml =
        `<div class ="vehicle-card ${activado}">
			<div class ="vehicle-card-header">
				<span class ="vehicle-card-title">${nombre}</span>
				<span class ="vehicle-card-price">$ 13.000, 00</span>
			</div>

			<div class ="vehicle-card-image">
				<img src="Images/Vehiculos/${nombre}.png" alt="${nombre}">
			</div>

			<div class ="vehicle-card-detail">
				<div class ="vehicle-card-description">
					${nombre}
				</div>

				<a class ="button button-blue">
					Ver modelo
				</a>
			</div>
		</div>
        `;

    //<span class="product-card-description">${descripcion}</span>
    //<img src="Images/${tipoProducto}/${nombre}.jpg" alt="${nombre}">

    return vehicleCardHtml;
}

function getVehiclePresentationHtml(id, nombre, urlImagen, color) {
    var vehicleCardHtml =
        `<div class ="vehicle-presentation">
			<div class ="vehicle-card-image">
				<img src="/Images/Vehiculos/${urlImagen}.png" alt="${nombre}">
			</div>

			<div class ="vehicle-card-header">
				<span class ="vehicle-presentation-title">
                    <a href="/Vehiculo/Detalle/${id}">${nombre} (${color})</a>
                </span>
			</div>
		</div>
        `;

    return vehicleCardHtml;
}

function activateMoveVehicleCardContainer() {
    minLimit = -30 * (_datosVehiculos.length - 2);
    maxLimit = 30 * (_datosVehiculos.length - 1);

    vehicleCards = document.getElementsByClassName('vehicle-card');
    //console.log(vehicleCards);
    if (vehicleCards.length === 0)
        return;

    vehicleCards[indexVehicleCardActive].classList.add('vehicle-card--active');

    document.getElementById('btnPreviousVehicleCard').addEventListener('click', function () {
        moveCurrentVehicleCard(vehicleCardContainer, previousCard);
    });

    document.getElementById('btnNextVehicleCard').addEventListener('click', function () {
        moveCurrentVehicleCard(vehicleCardContainer, nextCard);
    });
}

function moveCurrentVehicleCard(elemento, direction) {
    var newPos = (movePosVehicleCardContainer * direction);
    if (curPosVehicleCardContainer + newPos >= minLimit && curPosVehicleCardContainer + newPos < maxLimit) {
        vehicleCards[indexVehicleCardActive].classList.remove('vehicle-card--active');
        indexVehicleCardActive += -direction;
        vehicleCards[indexVehicleCardActive].classList.add('vehicle-card--active');

        curPosVehicleCardContainer += newPos;
        elemento.style.transform = `translateX(${curPosVehicleCardContainer}vw)`;

        //console.log(curPosVehicleCardContainer);
    }

}


/* 3. OBTENER VEHICULOS */
function mostrarDatosVehiculos() {
    //var listaVehicleCardHtml = '';
    //_datosVehiculos.forEach(function (vehiculo) {
    //    listaVehicleCardHtml += getVehicleCardHtml(vehiculo.NombreModelo, vehiculo.NombreModelo);
    //});

    //$("#vehiculos .vehicle-card-container").html(listaVehicleCardHtml);


    console.log('mostrar los vehiculos que son ' + _datosVehiculos.length);

    var listaVehicleCardHtml = '';
    _datosVehiculos.forEach(function (vehiculo) {
        listaVehicleCardHtml += getVehiclePresentationHtml(vehiculo.VehiculoId, vehiculo.NombreModelo, vehiculo.NombreModelo, vehiculo.Color);
    });

    $("#vehiculos .vehicle-card-container").html(listaVehicleCardHtml);

}

function obtenerVehiculosExitoso(resultado) {
    if (resultado.Success) {
        _datosVehiculos = resultado.Data;

        console.log(_datosVehiculos);
        mostrarDatosVehiculos();

        //activateMoveVehicleCardContainer();
    } else {
        toastr.error(resultado.Mensaje);
    }
}

function init() {
    var url = "/Vehiculo/ObtenerVehiculos";
    var tipo = 'GET';
    var datos = {
        page: page,
        size: size
    };
    //datos = JSON.stringify(datos);

    var tipoDatos = 'JSON';
    solicitudAjax(url, obtenerVehiculosExitoso, datos, tipoDatos, tipo);
}

/* 4. INICIAR FUNCIONES */
init();