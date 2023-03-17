$('.center').fadeIn(0);

function hover(x) {
    $('.item:eq(' + x + ')').find('.go_bk').fadeIn();
}

function hover_out() {
    $('.out').css({ 'width': '200px', 'height': '200px' });
    $('.out').find('path').css({ 'color': 'rgba(0, 0, 0, 1)' });
}

function click(x) {
    $('.item:eq(' + x + ')').parent().find('.svg-off').fadeIn();
    $('.item:eq(' + x + ')').parent().find('.svg-on').fadeOut(0);
}

function click_out() {
    $('.center').fadeOut();
    setTimeout(function () { location = "index.aspx"; }, 500);
}

function close() {
    $('.item').find('path').css({ 'color': '' });
    $('.item').find('.go_bk').fadeOut(300);
    $('.out').css({ 'width': '150px', 'height': '150px' });
    $('.out').find('path').css({ 'color': 'rgba(0, 0, 0, .3)' });
}