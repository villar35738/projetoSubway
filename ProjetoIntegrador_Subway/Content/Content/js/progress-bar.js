/*

Progress bar UI script.


*/
var result_table = $(".result-table");
var all_table = $(".all-table");
var btn_ver_todos = $(".btn-ver-todos");
var wrapper_pedidos = $(".wrapper-pedidos");
var wrapper_faturas = $(".wrapper-faturas");
var wrapper_processos = $(".wrapper-processos");


$(".values-progress-bar div h3").addClass('fadeout');
btn_ver_todos.hide();
wrapper_faturas.hide();
wrapper_processos.hide();



$(".process-bar").mouseleave(function () {
    $(this).find('h3').removeClass("fadein wide-box").addClass("fadeout");
    var order_number = $(this).index();
    $('.values-progress-bar div h3:eq( ' + order_number + ' )').removeClass("fadein wide-box").addClass("fadeout");
    $('.values-progress-bar').not(':eq(' + order_number + ')').css('z-index', '0');
});

$(".process-bar").mouseenter(function () {
    $(this).find('h3').removeClass("fadeout").addClass("fadein wide-box");
    var order_number = $(this).index();
    $('.values-progress-bar div h3:eq( ' + order_number + ' )').removeClass("fadeout").addClass("fadein wide-box");
    $('.values-progress-bar').not(':eq(' + order_number + ')').css('z-index', '-1');
});

$('.process-bar').click(function () {
    result_table.slideToggle('slow');
    all_table.slideToggle('slow');
    btn_ver_todos.slideToggle('slow');


    if (btn_ver_todos.css('display') === 'inline-block') {
        btn_ver_todos.css('display', 'block');
    }
    else {
        btn_ver_todos.css('display', 'none');
    }

});

// Navbar button bindings
$('.btn-pedidos').click(function () {
    wrapper_pedidos.fadeIn();
    wrapper_faturas.fadeOut();
    wrapper_processos.fadeOut();

    $(this).addClass("active");
    $('.btn-faturas').removeClass("active");
    $('.btn-processos').removeClass("active");
});

$('.btn-faturas').click(function () {
    wrapper_pedidos.fadeOut();
    wrapper_faturas.fadeIn();
    wrapper_processos.fadeOut();

    $('.btn-pedidos').removeClass("active");
    $(this).addClass("active");
    $('.btn-processos').removeClass("active");
});

$('.btn-processos').click(function () {
    wrapper_pedidos.fadeOut();
    wrapper_faturas.fadeOut();
    wrapper_processos.fadeIn();

    $('.btn-pedidos').removeClass("active");
    $('.btn-faturas').removeClass("active");
    $(this).addClass("active");
});
