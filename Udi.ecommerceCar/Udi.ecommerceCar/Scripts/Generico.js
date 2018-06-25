toastr.options.fadeOut = 3000;
toastr.options.timeOut = 3000;

function solicitudAjax(solicitudUrl, onSuccess, data, tipoDato, tipo) {
    var tipoSolicitud = tipo ? 'POST' : 'GET',
        datatype = tipoDato ? 'text' : 'json';

    $.ajax({
        type: tipoSolicitud,
        datatype: datatype,
        traditional: false,
        url: solicitudUrl,
        data: data,
        success: function (responseText) {
            if (onSuccess)
                onSuccess(responseText);
        },
        error: function (exception) {
            console.log(exception);
        }
    });
}

function crearControlFecha(element, cambiarFecha) {
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '<Ant',
        nextText: 'Sig>',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['es']);

    if (cambiarFecha) {
        $(element).datepicker({
            changeMonth: true,
            changeYear: true

        });
    } else {
        $(element).datepicker({});
    }
}

function adicionarOpcionesCombo(elemento, items, evento, prop) {
    prop = prop || { id: 'id', value: 'value' };
    $.each(items, function (index, item) {
        if (index == 0)
            $(elemento).append($('<option selected>').val(item[prop.id]).text(item[prop.value]));
        else
            $(elemento).append($('<option>').val(item[prop.id]).text(item[prop.value]));
    });
    if (evento)
        $(elemento).change(function (e) { evento(e, $(elemento).val()); });
}

function cargarRuta(url) {
    $('#content').load(url, null, null);
}

function cambiarRutaUsuario(url) {
    window.location.replace(url);
}

function limpiarTabla(elemento) {
    $('#' + elemento).find('tbody tr').remove();
}

function crearSpan(id, cssClase, contenido) {
    return $("<span>", { id: id }).addClass(cssClase).html(contenido);
}

function td(elementData, elementClass) {
    var td = $('<td>').html(elementData);
    if (elementClass)
        return td.addClass(elementClass);
    return td;
}

function col(data) {
    return td(data).addClass(alinear(data));
}

function isNumber(valueString) {
    if (valueString == '0') return true;
    if (!valueString) return false;
    return Number(valueString);
}

function isDate(dateString) {
    var patron = new RegExp("[a-zA-Z]");
    var date = new Date(dateString);
    return date.toString() == 'NaN' || date.toString() == 'Invalid Date' ? false : (patron.test(dateString)) ? false : true;
}

function alinear(value) {
    return isNumber(value) ? 'alinearDerecha' : isDate(value) ? 'alinearCentro' : 'alinearizquierda';
}

function AccionColumna(evento, classIcono, title) {
    title = title || "";
    return $('<button>', { title: title, class: "btn btn-outline-primary btn-sm" })
        .append("<img src='../Content/open-iconic/svg/" + classIcono + ".svg' alt='Eliminar'>").click(function (e) {
        e.preventDefault();
        evento(e);
    });
}

Array.prototype.remove = function (item) {
    var i = this.indexOf(item);
    if (i != -1)
        this.splice(i, 1);
};


function getDateFromStringNoFormat(fecha) {
    var fechaMilliseconds = parseInt(fecha.replace("/Date(", "").replace(")/", ""));

    var f = new Date(parseInt(fechaMilliseconds));
    var day = f.getDate();
    if (day < 10)
        day = "0" + day;

    var month = f.getMonth() + 1;
    if (month < 10)
        month = "0" + month;

    var year = f.getFullYear();

    return `${day}/${month}/${year}`;
}