
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

/* Paginas para ver */
function obtenerDatosVehiculosDashboardExitoso(res) {
    if (res.Success) {
        _datos = res.Data;
        // Hare que siempre se llame asi el contenedor porque este metodo es Dashboard, para Dashboard siempre se llamara asi
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < _datos.length; i++) {
            tablaDatosContainer.innerHTML += getRow(_datos[i].VehiculoID, _datos[i].NombreModelo, _datos[i].NombreMarca);
        }

        document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        document.getElementById("linkVehiculos").classList.add("link--active");
        refreshLinkSpanList();
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

        document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        document.getElementById("linkProductos").classList.add("link--active");
        refreshLinkSpanList();
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

        document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        document.getElementById("linkServicios").classList.add("link--active");
        refreshLinkSpanList();
    }
}


/* Paginas para agregar */
function obtenerDatosAgregarProductoDashboardExitoso(res) {
    if (res.Success) {
        var datosProductos = res.Data;

        var sltTipoProductoProducto = document.getElementById("sltTipoProductoProducto");

        sltTipoProductoProducto.innerHTML = "";
        for (var i = 0; i < datosProductos.length; i++) {
            sltTipoProductoProducto.innerHTML += `<option value='${datosProductos[i].TipoProductoID}'>${datosProductos[i].Nombre}</option>`;
        }

        refreshLinkSpanList();

        document.getElementById("btnGuardarProducto").addEventListener("click", function() {
            guardarProducto();
        });
    }
}

function obtenerDatosAgregarServicioDashboardExitoso(res) {
    if (res.Success) {
        var datosServicios = res.Data;

        var sltTipoServicioServicio = document.getElementById("sltTipoServicioServicio");

        sltTipoServicioServicio.innerHTML = "";
        for (var i = 0; i < datosServicios.length; i++) {
            sltTipoServicioServicio.innerHTML += `<option value='${datosServicios[i].TipoServicioID}'>${datosServicios[i].Nombre}</option>`;
        }

        refreshLinkSpanList();

        document.getElementById("btnGuardarServicio").addEventListener("click", function () {
            guardarServicio();
        });
    }
}

/* Funciones para llenar datos al dashboard */
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


function refreshLinkSpanList() {
    var linkSpanList = document.getElementsByClassName("link-span");

    if (linkSpanList) {
        for (var i = 0; i < linkSpanList.length; i++) {
            linkSpanList[i].addEventListener("click", function (ev) {
                
                var page = this.dataset.page;
                $("#adminContent").load(urlAdmin + page + ".html", function () {
                    //Cargar datos
                });
            });
        }
    }
}


/* METODOS ABM */

function guardarProductoExitoso(res) {
    if (res.Success) {
        toastr.success("Producto guardado satisfactoriamente!");

        //Limpiar campos
        document.getElementById("txtNombreProducto").value = "";
        document.getElementById("txtDescripcionProducto").value = "";
        document.getElementById("txtDescripcionCortaProducto").value = "";

        document.getElementById("txtPrecioProducto").value = "";
        document.getElementById("txtCantidadProducto").value = "";

        //document.getElementById("txtNombreProducto").value = "";
        //document.getElementById("txtNombreProducto").value = "";
        //document.getElementById("txtNombreProducto").value = "";
    } else {
        toastr.error("Error");
    }
}

function guardarProducto() {
    var url = "/Producto/GuardarProducto";

    var tipo = "POST";
    var producto = {
        ProductoID: 0,
        Nombre: document.getElementById("txtNombreProducto").value,
        Descripcion: document.getElementById("txtDescripcionProducto").value,
        DescripcionCorta: document.getElementById("txtDescripcionCortaProducto").value,
        Cantidad: document.getElementById("txtCantidadProducto").value,
        Precio: document.getElementById("txtPrecioProducto").value,
        VisibleMain: document.getElementById("txtVisibleMainProducto").checked,
        TipoProductoId: document.getElementById("sltTipoProductoProducto").value,
        Puntuacion: null,
        UrlAmigable: null,
        ImagenId: null,
        TipoProducto: null
    };
    producto = JSON.stringify(producto);

    var datos = {
        productoString: producto
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, guardarProductoExitoso, datos, tipoDatos, tipo);
}


function guardarServicioExitoso(res) {
    if (res.Success) {
        toastr.success("Servicio guardado satisfactoriamente!");

        //Limpiar campos
        document.getElementById("txtDescripcionServicio").value = "";
        document.getElementById("txtDescripcionCortaServicio").value = "";

        document.getElementById("txtPrecioServicio").value = "";
        document.getElementById("txtCantidadServicio").value = "";

        //document.getElementById("txtNombreProducto").value = "";
        //document.getElementById("txtNombreProducto").value = "";
        //document.getElementById("txtNombreProducto").value = "";
    } else {
        toastr.error("Error");
    }
}

function guardarServicio() {
    var url = "/Servicio/GuardarServicio";

    var tipo = "POST";
    var servicio = {
        ServicioID: 0,
        Descripcion: document.getElementById("txtDescripcionServicio").value,
        DescripcionCorta: document.getElementById("txtDescripcionCortaServicio").value,
        Precio: document.getElementById("txtPrecioServicio").value,
        VisibleMain: document.getElementById("txtVisibleMainServicio").checked,
        TipoServicioId: document.getElementById("sltTipoServicioServicio").value,
        Puntuacion: null,
        UrlAmigable: null,
        ImagenId: null,
        TipoServicio: null
    };
    servicio = JSON.stringify(servicio);

    var datos = {
        servicioString: servicio
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, guardarServicioExitoso, datos, tipoDatos, tipo);
}



refreshLinkSpanList();


