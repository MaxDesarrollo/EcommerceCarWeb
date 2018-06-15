
var urlAdmin = "/Content/html/admin/";

var page = 0,
    size = 10;

var ventaEstado = ["Pendiente", "Pagado", "Enviado", "Completado", "CanceladoAdministrador", "CanceladoCliente"];

var estadoCancelado = false;

function getRow(id, nombre, descripcion, marcado) {
    var desc = descripcion ? descripcion : "";
    var btnMarcarPrincipalText = marcado ? "Desmarcar" : "Marcar";

    var row =
        `<div class="fila">
			<div class="celda celda-1">${id}</div>
			<div class="celda celda-2">${nombre}</div>
			<div class="celda celda-2">${desc}</div>
            <div class="celda celda-1"><button class="btn-marcar-principal boton boton-naranja" data-id="${id}">${btnMarcarPrincipalText}</button></div>
			<div class="celda celda-4"></div>
		</div>`;

    return row;
}


function parseJsonDate(jsonDateString) {
    var date = new Date(parseInt(jsonDateString.replace('/Date(', '')));
    return `${date.getDay().toString().padStart(2, "0")}/${date.getMonth().toString().padStart(2, "0")}/${date.getFullYear()}`;
}

/* Paginas para ver */

function obtenerDashboardExitoso() {
    document.getElementsByClassName("link--active")[0].classList.remove("link--active");
    document.getElementById("linkDashboard").classList.add("link--active");
    refreshLinkSpanList();
}

function obtenerDatosVehiculosDashboardExitoso(res) {
    if (res.Success) {
        var datos = res.Data;
        // Hare que siempre se llame asi el contenedor porque este metodo es Dashboard, para Dashboard siempre se llamara asi
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < datos.length; i++) {
            tablaDatosContainer.innerHTML += getRow(datos[i].InventarioVehiculoId, datos[i].NombreModelo, datos[i].NombreMarca, datos[i].VisibleMain);
        }

        document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        document.getElementById("linkVehiculos").classList.add("link--active");
        refreshLinkSpanList();
        activateBtnMarcarPrincipal("/Vehiculo/MarcarPrincipalVehiculo", marcarPrincipalVehiculoExitoso);
    }
}

function obtenerDatosProductosDashboardExitoso(res) {
    if (res.Success) {
        var datos = res.Data;
        // Hare que siempre se llame asi el contenedor porque este metodo es Dashboard, para Dashboard siempre se llamara asi
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < datos.length; i++) {
            tablaDatosContainer.innerHTML += getRow(datos[i].ProductoId, datos[i].Nombre, datos[i].TipoProducto, datos[i].VisibleMain);
        }

        document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        document.getElementById("linkProductos").classList.add("link--active");
        refreshLinkSpanList();
        activateBtnMarcarPrincipal("/Producto/MarcarPrincipalProducto", marcarPrincipalProductoExitoso);
    }
}

function obtenerDatosServiciosDashboardExitoso(res) {
    if (res.Success) {
        var datos = res.Data;
        // Hare que siempre se llame asi el contenedor porque este metodo es Dashboard, para Dashboard siempre se llamara asi
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < datos.length; i++) {
            tablaDatosContainer.innerHTML += getRow(datos[i].ServicioId, datos[i].TipoServicio, datos[i].DescripcionCorta, datos[i].VisibleMain);
        }

        document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        document.getElementById("linkServicios").classList.add("link--active");
        refreshLinkSpanList();
        activateBtnMarcarPrincipal("/Servicio/MarcarPrincipalServicio", marcarPrincipalServicioExitoso);
    }
}


function obtenerDatosVentasProductosDashboardExitoso(res) {
    if (res.Success) {
        var datos = res.Data;
        // Hare que siempre se llame asi el contenedor porque este metodo es Dashboard, para Dashboard siempre se llamara asi
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < datos.length; i++) {
            var row =
                `<div class="fila">
			        <div class="celda celda-1">${datos[i].VentaId}</div>
			        <div class="celda celda-2">${datos[i].Usuario}</div>
			        <div class="celda celda-2">${parseJsonDate(datos[i].Fecha)}</div>
                    <div class="celda celda-2">Bs.${datos[i].Monto.toFixed(2)}</div>
                    <div class="celda celda-1">${datos[i].EstadoSelect}</div>

			        <div class="celda celda-2 fila-una-linea">
                        <button class="link-span boton boton-azul" data-page="detalles-ventas-productos" data-parameters="${datos[i].VentaId}">Ver Detalle</button>
                        <button class="btn-cambio-estado-venta-producto boton boton-verde" data-venta-producto-id="${datos[i].VentaId}">Confirmar</button>
			        </div>
		        </div>`;

            tablaDatosContainer.innerHTML += row;
            // ${ventaEstado[datos[i].Estado]}
        }

        document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        document.getElementById("linkPedidos").classList.add("link--active");
        refreshLinkSpanList();

        activateVentaProductoEstadoSelect();
    }
}

function obtenerDatosDetallesVentasProductosDashboardExitoso(res) {
    if (res.Success) {
        var datos = res.Data;

        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        var subtotal = 0;
        for (var i = 0; i < datos.length; i++) {
            var row =
                `<div class="fila">
			        <div class="celda celda-1">${datos[i].DetalleVentaProductoId}</div>
                    <div class="celda celda-3">${datos[i].Producto}</div>
			        <div class="celda celda-2">${datos[i].Cantidad}</div>
			        <div class="celda celda-2">Bs. ${datos[i].Precio.toFixed(2)}</div>
                    <div class="celda celda-2">Bs.${(datos[i].Precio * datos[i].Cantidad).toFixed(2)}</div>
		        </div>`;

            tablaDatosContainer.innerHTML += row;
            subtotal += (datos[i].Precio * datos[i].Cantidad);
        }

        document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        document.getElementById("linkPedidos").classList.add("link--active");
        refreshLinkSpanList();

        showPriceDashboard(subtotal);
    } else {
        toastr.error("Ocurrió un problema al momento de realizar la acción. Por favor intente nuevamente.");
    }
}


/* Paginas para agregar */
function obtenerDatosAgregarProductoDashboardExitoso(res) {
    if (res.Success) {
        var datosProductos = res.Data;

        var sltTipoProductoProducto = document.getElementById("sltTipoProductoProducto");

        sltTipoProductoProducto.innerHTML = "";
        for (var i = 0; i < datosProductos.length; i++) {
            sltTipoProductoProducto.innerHTML += `<option value='${datosProductos[i].TipoProductoId}'>${datosProductos[i].Nombre}</option>`;
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
            sltTipoServicioServicio.innerHTML += `<option value='${datosServicios[i].TipoServicioId}'>${datosServicios[i].Nombre}</option>`;
        }

        refreshLinkSpanList();

        document.getElementById("btnGuardarServicio").addEventListener("click", function () {
            guardarServicio();
        });
    }
}

/* Funciones para llenar datos al dashboard */
function obtenerDatosDashboard(url, obtenerDatosDashboardExitoso, datosParametros) {
    var tipo = "GET";
    var datos;

    if (!datosParametros) {
        page = 0;
        size = 10;

        datos = {
            page: page,
            size: size
        };
    } else {
        datos = datosParametros;
    }

    var tipoDatos = "JSON";
    solicitudAjax(url, obtenerDatosDashboardExitoso, datos, tipoDatos, tipo);
}


/* Funciones para activar funcionalidades a los botones una vez cargados en la pagina */

function activateBtnMarcarPrincipal(url, marcarPrincipalExitoso) {
    var btnMarcarPrincipalList = document.getElementsByClassName("btn-marcar-principal");

    if (btnMarcarPrincipalList) {
        for (var j = 0; j < btnMarcarPrincipalList.length; j++) {
            btnMarcarPrincipalList[j].addEventListener("click", function () {
                var id = this.dataset.id;
                marcarPrincipal(url, id, marcarPrincipalExitoso);

                if (this.innerText == "Marcar") {
                    this.innerText = "Desmarcar";
                } else {
                    this.innerText = "Marcar";
                }
            });
        }
    }
}

function refreshLinkSpanList() {
    var linkSpanList = document.getElementsByClassName("link-span");

    if (linkSpanList) {
        for (var i = 0; i < linkSpanList.length; i++) {
            linkSpanList[i].addEventListener("click", function (ev) {
                
                var page = this.dataset.page;
                var parameters = this.dataset.parameters;

                var url = urlAdmin + page + ".html";
                document.getElementById("txtParametros").value = parameters;

                $("#adminContent").load(url, function () {});
            });
        }
    }
}

function cambiarEstadoVentaProductoExitoso(res) {
    // Si se cancelo el pedido, cambiar la fila por un mensaje de pedido cancelado por el administrador
    if (res.Success) {
        var select = document.getElementsByClassName("slt-venta-producto-estado--modificado")[0];

        if (estadoCancelado) {
            select.parentElement.parentElement.innerHTML = "<div class='fila-mensaje'>Pedido cancelado satisfactoriamente.</div>";
            estadoCancelado = false;
        } else {
            select.parentElement.innerHTML = res.Data;
            activateVentaProductoEstadoSelect();
            select.classList.remove("slt-venta-producto-estado--modificado");
        }

        toastr.success("Se ha modificado el estado correctamente");
    } else {
        estadoCancelado = false;
        toastr.error("Ocurrió un problema. Por favor intente nuevamente");
    }
}

function cambiarEstadoVentaProducto(ventaProductoId, nuevoEstado) {
    var url = "/VentaProducto/CambiarEstadoVentaProducto";
    var tipo = "POST";
    var datos = {
        ventaProductoId: ventaProductoId,
        nuevoEstado: nuevoEstado
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, cambiarEstadoVentaProductoExitoso, datos, tipoDatos, tipo);
}

function activateBtnCambioEstadoVentaProducto() {
    var listaBtnCambioEstadoVentaProducto = document.getElementsByClassName("btn-cambio-estado-venta-producto");
    for (var i = 0; i < listaBtnCambioEstadoVentaProducto.length; i++) {
        listaBtnCambioEstadoVentaProducto[i].addEventListener("click", function() {
            var ventaProductoId = this.dataset.ventaProductoId;

            var select = this.parentElement.parentElement.getElementsByClassName("slt-venta-producto-estado")[0];
            var nuevoEstado = select.value;

            if (nuevoEstado == 4) {
                estadoCancelado = true;
            }

            cambiarEstadoVentaProducto(ventaProductoId, nuevoEstado);
            select.classList.add("slt-venta-producto-estado--modificado");

            this.classList.remove("btn-cambio-estado-venta-producto--show");
        });
    }
}


function findBtnCambioEstadoVentaProducto(select) {
    return select.parentElement.parentElement.getElementsByClassName("btn-cambio-estado-venta-producto")[0];
}

function activateVentaProductoEstadoSelect() {
    var listaSltVentaProductoEstado = document.getElementsByClassName("slt-venta-producto-estado");
    for (var i = 0; i < listaSltVentaProductoEstado.length; i++) {
        listaSltVentaProductoEstado[i].addEventListener("change", function(ev) {
            var estadoActual = ev.target.dataset.estadoActual;
            var nuevoEstado = this.value;

            var btnCambioEstadoVentaProducto = findBtnCambioEstadoVentaProducto(this);

            if (estadoActual != nuevoEstado) {
                btnCambioEstadoVentaProducto.classList.add("btn-cambio-estado-venta-producto--show");
            } else {
                btnCambioEstadoVentaProducto.classList.remove("btn-cambio-estado-venta-producto--show");
            }
        });
    }

    activateBtnCambioEstadoVentaProducto();
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
        ProductoId: 0,
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
        ServicioId: 0,
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

/* METODOS MARCAR PRINCIPAL */

function marcarPrincipalProductoExitoso(res) {
    if (res.Success) {
        toastr.success(res.Mensaje);
    } else {
        toastr.error(res.Mensaje);
    }
}

function marcarPrincipalServicioExitoso(res) {
    if (res.Success) {
        toastr.success(res.Mensaje);
    } else {
        toastr.error(res.Mensaje);
    }
}

function marcarPrincipalVehiculoExitoso(res) {
    if (res.Success) {
        toastr.success(res.Mensaje);
    } else {
        toastr.error(res.Mensaje);
    }
}

function marcarPrincipal(url, id, marcarPrincipalExitoso) {
    var tipo = "POST";
    var datos = {
        id: id
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, marcarPrincipalExitoso, datos, tipoDatos, tipo);
}

/* METODOS EXTRAS */

function showPriceDashboard(subtotal) {
    document.getElementById("dashboardPriceSubtotal").innerText = subtotal.toFixed(2);
    document.getElementById("dashboardPriceEnvio").innerText = (0).toFixed(2);
    document.getElementById("dashboardPriceTotal").innerText = (subtotal + (0)).toFixed(2);
}



refreshLinkSpanList();

var url = urlAdmin + "dashboard.html";
$("#adminContent").load(url, function () { });
