
var solicitando = false;
var fila;

function cancelarPedidoPorClienteExitoso(res) {
    if (res.Success) {
        toastr.success("Pedido cancelado correctamente.");
        fila.innerHTML = "<div class='fila-mensaje'>Pedido cancelado satisfactoriamente.</div>";
        fila = null;
    } else {
        toastr.error("Ocurrió un problema al querer cancelar su pedido. Por favor intente nuevamente");
    }

    solicitando = false;
}

function cancelarPedidoPorCliente(id) {
    if (solicitando) {
        return;
    }
    solicitando = true;

    var tipo = "POST";
    var url = "/VentaProducto/CancelarPedidoPorCliente";
    var datos = {
        ventaProductoId: id
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, cancelarPedidoPorClienteExitoso, datos, tipoDatos, tipo);
}

function activateCancelarPedidoCliente() {
    var botonesCancelarPedidoCliente = document.getElementsByClassName("btn-cancelar-pedido");
    for (var i = 0; i < botonesCancelarPedidoCliente.length; i++) {
        botonesCancelarPedidoCliente[i].addEventListener("click", function () {
            var id = this.dataset.ventaId;
            cancelarPedidoPorCliente(id);
            fila = this.parentElement.parentElement;
        });
    }
}

function obtenerMisPedidosExitoso(res) {
    if (res.Success) {
        var datos = res.Data;
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < datos.length; i++) {
            var btnCancelarPedido = "";
            if (datos[i].EstadoString == "Pendiente") {
                btnCancelarPedido = `<button class="link-span boton boton-rojo btn-cancelar-pedido" data-venta-id="${datos[i].VentaId}">Cancelar</button>`;
            }

            var row =
                `<div class="fila">
			        <div class="celda celda-1">${datos[i].VentaId}</div>
			        <div class="celda celda-2">${datos[i].Usuario}</div>
			        <div class="celda celda-2">${getDateFromStringNoFormat(datos[i].Fecha)}</div>
                    <div class="celda celda-2">Bs.${datos[i].Monto.toFixed(2)}</div>
                    <div class="celda celda-1">${datos[i].EstadoString}</div>

			        <div class="celda celda-2 fila-una-linea">
                        <button class="link-span boton boton-azul" data-page="detalles-ventas-productos" data-parameters="${datos[i].VentaId}">
                            <a href="/VentaProducto/DetallePedido/${datos[i].VentaId}">Ver Detalle</a>
                        </button>

                        ${btnCancelarPedido}
			        </div>
		        </div>`;

            tablaDatosContainer.innerHTML += row;
            // ${ventaEstado[datos[i].Estado]}
        }

        //document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        //document.getElementById("linkPedidos").classList.add("link--active");
        //refreshLinkSpanList();

        //activateVentaProductoEstadoSelect();
        activateCancelarPedidoCliente();
    }
}

function init() {
    var tipo = "GET";
    var url = "/Usuario/ObtenerVentasProductosUsuario";
    var datos = {
        pk: localStorage.getItem("usuarioId")
    };

    var tipoDatos = "JSON";
    solicitudAjax(url, obtenerMisPedidosExitoso, datos, tipoDatos, tipo);
}

init();