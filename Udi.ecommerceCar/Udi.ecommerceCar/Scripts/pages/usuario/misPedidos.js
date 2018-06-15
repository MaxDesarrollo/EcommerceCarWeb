
function parseJsonDate(jsonDateString) {
    var date = new Date(parseInt(jsonDateString.replace('/Date(', '')));
    return `${date.getDay().toString().padStart(2, "0")}/${date.getMonth().toString().padStart(2, "0")}/${date.getFullYear()}`;
}

function obtenerMisPedidosExitoso(res) {
    if (res.Success) {
        var datos = res.Data;
        var tablaDatosContainer = document.getElementById("tablaDatosContainer");
        tablaDatosContainer.innerHTML = "";

        for (var i = 0; i < datos.length; i++) {
            var row =
                `<div class="fila">
			        <div class="celda celda-1">${datos[i].VentaId}</div>
			        <div class="celda celda-2">${datos[i].Usuario}</div>
			        <div class="celda celda-2">${parseJsonDate(datos[i].Fecha)}</div>
                    <div class="celda celda-2">Bs.${datos[i].Monto.toFixed(2)}</div>
                    <div class="celda celda-1">${datos[i].EstadoString}</div>

			        <div class="celda celda-2 fila-una-linea">
                        <button class="link-span boton boton-azul hidden" data-page="detalles-ventas-productos" data-parameters="${datos[i].VentaId}">
                            <a href="/VentaProducto/Detalle/${datos[i].VentaId}">Ver Detalle</a>
                        </button>
			        </div>
		        </div>`;

            tablaDatosContainer.innerHTML += row;
            // ${ventaEstado[datos[i].Estado]}
        }

        //document.getElementsByClassName("link--active")[0].classList.remove("link--active");
        //document.getElementById("linkPedidos").classList.add("link--active");
        //refreshLinkSpanList();

        //activateVentaProductoEstadoSelect();
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