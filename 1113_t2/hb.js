$('.center').fadeIn(0);

function hover(x) {
    $('.item:eq(' + x + ')').find('path').css({ 'color': 'rgba(255,255,255,1)' });
    $('.item:eq(' + x + ')').find('.go_bk').fadeIn();
}

function click(x) {
}

function hover_out() {
    $('.out').css({ 'width': '200px', 'height': '200px' });
    $('.out').find('path').css({ 'color': 'rgba(0, 0, 0, 1)' });
}

function click_out() {
    $('.center').fadeOut();
    setTimeout(function () { location = "index.aspx"; }, 500);
}

function close() {
    $('.item').find('path').css({ 'color': '' });
    $('.item').find('.go_bk').fadeOut(0);
    $('.out').css({ 'width': '150px', 'height': '150px' });
    $('.out').find('path').css({ 'color': 'rgba(0, 0, 0, .3)' });
}