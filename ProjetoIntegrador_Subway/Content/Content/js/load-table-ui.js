// EXEMPLO DE AJAX
/*
jQuery.ajax({
    method: "POST",
    url: @Url.Action("MyTestMethod"),,
    cache: false,
    success: function (data) {
        //$('.table > tbody').html(data);
        alert(data);
    },
    error: function (xhr, status, error) {
        var err = eval("(" + xhr.responseText + ")");
        alert(err.Message);
    }
});
*/

var start_pos = 0;
var sortable_list = [];

// Sortable column heads
var oldIndex;
var old_table_id;
var old_table_trs;
var column_buffer = [];

$('.tabela-resultado-cabecalho tr').sortable({
    group: 'group-for-mov',
    containerSelector: 'tr',
    itemSelector: 'th',
    placeholder: '<th class="placeholder"/>',
    vertical: false,
    delay: 70,
    pullPlaceholder: false,
    onDragStart: function ($item, container, _super) {
        oldIndex = $item.index();
        $item.appendTo($item.parent());

        //Reduz opacidade da tabela
        $item.closest('table').find('tbody').css("opacity", "0.3");

        //Pra cada linha, pega a coluna certa e joga numa array
        old_table = $item.closest('table');
        old_table_id = $item.closest('table').attr('id');
        old_table_trs = $item.closest('table').find('tbody tr');

        _super($item, container);
    },
    onDrag: function ($item) {
        $('.placeholder').text($item[0].innerText);
    },
    onDrop: function ($item, container, _super) {
        var new_table_id = $item.closest('table').attr("id");
        var field,
            newIndex = $item.index();

        $('table').find('tbody').css("opacity", "1");

        if (newIndex != oldIndex) {
            $item.closest('table').find('tbody tr').each(function (i, row) {
                row = $(row);
                if (newIndex < oldIndex) {
                    row.children().eq(newIndex).before(row.children()[oldIndex]);
                } else if (newIndex > oldIndex) {
                    row.children().eq(newIndex).after(row.children()[oldIndex]);
                }
            });
        } if (old_table_id !== new_table_id) {
            old_table_trs.each(function (i, row) {
                row = $(row);
                row.children().eq(oldIndex).remove();
            });

        }

        _super($item, container);
    },
    onCancel: function ($item, container, _super) {
        $item.closest('table').find('tbody').css("opacity", "1");
    }
});


//Inicializa o tablesorter pra todas as tabelas da interface
jQuery('.pedidos-tabela-pendencias').tablesorter({
    theme: 'tracking',
    sortMultiSortKey: "shiftKey",
    sortResetKey: 'ctrlKey',
    widgets: ['zebra', 'math'],
    widgetOptions: {
        math_data: 'math',
        math_mask: 'R$ #,00',
        math_complete: function ($cell, wo, result, value, arry) {
            var txt = '<span class="align-decimal">' + result + '</span>';
            /*
            if ($cell.attr('data-math') === 'all-sum') {
                // when the "all-sum" is processed, add a count to the end
                return txt + ' (Sum of ' + arry.length + ' cells)';
            }
            */
            return txt;
        }
    }
});
