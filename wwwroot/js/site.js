function mostrarImagenCargando() {
    $("#gifCargando").show();
}

function ocultarImagenCargando() {
    $("#gifCargando").hide();
}

$(document).ready(function () {
    let ARCHIVOS_TABLE;
    let ID_INTERVALO = 0;

    $('body').tooltip({ selector: '[data-toggle=tooltip]' });
});

jQuery.fn.reset = function () {
    $(this).each(function () { this.reset(); });
    $('select.form-control').selectpicker('refresh');
    /*if (ARCHIVOS_TABLE !== null && ARCHIVOS_TABLE !== undefined && typeof ARCHIVOS_TABLE !== 'undefined') {
        ARCHIVOS_TABLE.clear().draw();
    }*/
}

bootbox.setDefaults({
    locale: "es",
    show: true,
    backdrop: true,
    closeButton: false,
    animate: true
});

/*DataTable Functions*/
$.extend($.fn.dataTable.defaults, {
    paging: true,
    retrieve: true,
    searching: true,
    autoWidth: false,
    info: true,
    ordering: false,
    language: {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ning&uacute;n dato disponible en esta tabla",
        "sInfo": "Del _START_ al _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Del 0 al 0 de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearchPlaceholder": "Escriba algo...",
        //"sSearch": "",
        //"sUrl": "",
        //"sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        //"oPaginate": {
        //    "sFirst": "Primero",
        //    "sLast": "Último",
        //    "sNext": "Siguiente",
        //    "sPrevious": "Anterior"
        //},
        //"oAria": {
        //    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
        //    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        //}
    },
    lengthChange: false,
    responsive: true,
    serverSide: false,
    processing: true,
    fixedHeader: false,
    colReorder: false,
    layout: {
        topStart: 'pageLength',
        topEnd: 'search',
        bottomStart: 'info',
        bottomEnd: {
            paging: {
                buttons: 4
            }
        }
    }
});

jQuery.ajaxSetup({
    global: false,
    contentType: 'application/x-www-form-urlencoded; charset=utf-8',
    cache: false,
    async: true,
    beforeSend: function (xhr, settings) {
        $("#gifCargando").show();
    },
    error: function (xhr, status) {
        __onError(xhr, status);
    },
    complete: function (data, status, xhr) {
        $("#gifCargando").hide();
    }
});

function __onBegin(xhr, settings) {
    $('#signalLoader').css('animation-play-state', 'initial');
    $('#mainLoadAjax').show();
}

function __onSuccess(data, status, xhr, tableId, config) {
    if (status == 'success') {
        if (tableId !== null && typeof tableId !== 'undefined' && tableId !== undefined && ARCHIVOS_TABLE !== null && typeof ARCHIVOS_TABLE !== 'undefined' && ARCHIVOS_TABLE !== undefined) {
            ARCHIVOS_TABLE_PAGE = ARCHIVOS_TABLE === undefined ? 0 : ARCHIVOS_TABLE.page();
            ARCHIVOS_TABLE.clear().draw();
            ARCHIVOS_TABLE.destroy();
            $(tableId).empty();
            $(tableId).html(data);
            if (config !== null && typeof config !== 'undefined' && config !== undefined) {
                ARCHIVOS_TABLE = $(tableId).DataTable(config);
            } else {
                ARCHIVOS_TABLE = $(tableId).DataTable();
            }
            ARCHIVOS_TABLE.page(ARCHIVOS_TABLE_PAGE).draw('page');
        }
    }
}

function __onFailure(xhr, status, tableName) {
    __onError(xhr, status);
}

function __onError(xhr, status) {
    if (xhr != null && xhr != 'undefined') {
        if (xhr.responseJSON != null) {
            var data = xhr.responseJSON;
            if (!data.exito) {
                bootbox.alert({
                    title: document.getElementsByTagName("title")[0].innerHTML,
                    message: '<span class="text-justify" style="white-space: pre-line">'.concat(data.mensaje).concat('</span>')
                });
            }
        } else {
            if (xhr.status === 0) {
                bootbox.alert({
                    title: '[0] No hay conexión a internet',
                    message: '<span class="text-justify" style="white-space: pre-line">Verifique su conexión a internet y vuelva a intentarlo.</span>'
                });
            } else if (xhr.status == 404) {
                bootbox.alert({
                    title: '[404] Recurso no encontrado',
                    message: '<span class="text-justify" style="white-space: pre-line">No se puede encontrar el recurso.</span>'
                });
            } else if (xhr.status == 500) {
                bootbox.alert({
                    title: '[500] Error interno del servidor',
                    message: '<span class="text-justify" style="white-space: pre-line">Error interno del servidor.</span>'
                });
            } else if (xhr.status == 503) {
                bootbox.alert({
                    title: '[503] Servicio no disponible',
                    message: '<span class="text-justify" style="white-space: pre-line">Servicio no disponible.</span>'
                });
            } else if (status === 'timeout') {
                bootbox.alert({
                    title: 'Tiempo de espera excedido',
                    message: '<span class="text-justify" style="white-space: pre-line">Tiempo de espera excedido.</span>'
                });
            } else if (status === 'abort') {
                console.log('Ajax[aborted]');
            } else {
                __callErrorModal(xhr.responseText);
            }
        }
    }
}

function __onComplete(data, status, xhr) {
    $("#gifCargando").hide();
}

function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function __callErrorModal(data) {
    $('#DivErrores').html(data);
    $('#modalError').modal('show');
}

function __callModal(modalHtml, size, enfasis) {
    var modal = $(__dimModal(modalHtml, size, enfasis));
    var id = uuidv4();
    CURRENT_MODAL_ID = id;
    console.log('Creando modal: ' + CURRENT_MODAL_ID + '...');
    modal.attr('id', CURRENT_MODAL_ID);
    $('#TrafoModals').append(modal);
    $('#' + CURRENT_MODAL_ID).modal('show');
    $('#' + CURRENT_MODAL_ID).on('hidden.bs.modal', function () {
        console.log('Limpiando modal ' + $(this).attr('id') + '...');
        $(this).modal('dispose');
        $(this).remove();
        CURRENT_MODAL_ID = '';
        if (typeof ID_INTERVALO !== 'undefined') {
            if (ID_INTERVALO > 0) {
                console.log("Limpiando intervalo " + ID_INTERVALO);
                clearInterval(ID_INTERVALO);
                ID_INTERVALO = 0;
            }
        }
    });
}

function __hideCurrentModal() {
    if ($('#TrafoModals > div.modal.fade').length > 0) {
        console.log($('#TrafoModals > div.modal.fade').length);
        var modal = $('#TrafoModals > div').last();
        if (modal.is(':visible')) {
            modal.modal('hide');
        }
    } else {
        console.log('no se encontraron modals activos.');
    }
}

function __hideAllModals() {
    $.each($('#TrafoModals > div.modal.fade'), function (index, object) {
        var modal = $(object);
        if (modal.is(':visible')) {
            modal.modal('hide');
        }
    });
}

function __showModalResult(data, refresh, url) {
    __hideAllModals();
    bootbox.dialog({
        title: document.getElementsByTagName("title")[0].innerHTML,
        message: '<span class="text-justify" style="white-space: pre-line">'.concat(data.mensaje).concat('</span>'),
        className: 'alert-success',
        closeButton: false,
        buttons: {
            ok: {
                label: '<i class="fa fa-check"></i> OK',
                className: 'btn-success',
                callback: function () {
                    if (refresh) {
                        window.location.href = url;
                    }
                    return true;
                }
            }
        }
    });
}

function __dimModal(modalHtml, size, enfasis) {
    var htmlEnfasis = '';
    var htmlSize = '';

    if (enfasis)
        htmlEnfasis = ' alert-' + enfasis;
    if (size)
        htmlSize = ' modal-' + size;

    var fullModalHtml = '<div class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" aria-hidden="true">' +
        '<div class="modal-dialog' + htmlSize + htmlEnfasis + '" role="document">' +
        '<div class="modal-content">' + modalHtml +
        '</div>' +
        '</div>' +
        '</div>';
    return fullModalHtml;
}