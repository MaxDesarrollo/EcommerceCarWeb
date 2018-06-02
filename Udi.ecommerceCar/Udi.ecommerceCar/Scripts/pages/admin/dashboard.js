

var linkSpanList = document.getElementsByClassName("link-span");
var urlAdmin = "/Content/html/admin/";

var _datos;

var page = 0,
    size = 10;


function getRow(id, nombre, descripcion) {
    var desc = descripcion ? descripcion : "";
    var row =
        `<div class="fila">
			<div class="celda celda-1">
				${id}
			</div>

			<div class="celda celda-2">
				${nombre}
			</div>

			<div class="celda celda-2">
				${desc}
			</div>

			<div class="celda celda-5">
				Marcar como Principal, Editar, Eliminar
			</div>
		</div>`;

    return row;
}


function obtenerDatosVehiculosDashboardExitoso(res) {
    if (res.Success) {
        _datos = res.Data;
        // Hare que siempre se llame asi el contenedor porque este metodo es Dashboard, para Dashboard siempre se llamara asi
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < _datos.length; i++) {
            tablaDatosContainer.innerHTML += getRow(_datos[i].VehiculoID, _datos[i].NombreModelo, _datos[i].NombreMarca);
        }
    }
}

function obtenerDatosProductosDashboardExitoso(res) {
    if (res.Success) {
        _datos = res.Data;
        // Hare que siempre se llame asi el contenedor porque este metodo es Dashboard, para Dashboard siempre se llamara asi
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < _datos.length; i++) {
            tablaDatosContainer.innerHTML += getRow(_datos[i].ProductoID, _datos[i].Nombre, _datos[i].TipoProducto);
        }
    }
}


function obtenerDatosServiciosDashboardExitoso(res) {
    if (res.Success) {
        _datos = res.Data;
        // Hare que siempre se llame asi el contenedor porque este metodo es Dashboard, para Dashboard siempre se llamara asi
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < _datos.length; i++) {
            tablaDatosContainer.innerHTML += getRow(_datos[i].ServicioID, _datos[i].TipoServicio, _datos[i].DescripcionCorta);
        }
    }
}


function obtenerDatosDashboard(url, obtenerDatosDashboardExitoso) {
    page = 0;
    size = 10;

    var tipo = "GET";
    var datos = {
        page: page,
        size: size
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, obtenerDatosDashboardExitoso, datos, tipoDatos, tipo);
}


if (linkSpanList) {
    for (var i = 0; i < linkSpanList.length; i++) {
        linkSpanList[i].addEventListener("click", function (ev) {
            console.log(ev);
            var page = this.dataset.page;
            $("#adminContent").load(urlAdmin + page + ".html", function() {
                //Cargar datos
            });
        });
    }
}