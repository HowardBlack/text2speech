﻿$('.center').fadeIn(1000);

function hover(x) {
    $('.item:eq(' + x + ')').find('.go_bk').fadeIn();
    $('.item:eq(' + x + ')').css({ 'color': 'rgba(255,255,255,1)' });
}

function click_out() {
    $('.center').fadeOut();
    setTimeout(function () { location = "index.aspx"; }, 500);
}

function click(x) {
    $('.center').fadeOut();
    setTimeout(function () { location = "se.aspx"; }, 500);
}

function close() {
    $('.item').css({ 'color': '' });
    $('.item').find('.go_bk').fadeOut(300);
}