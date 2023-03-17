//==========初始畫面==========
$('.center').delay(500).fadeIn();
$('.start h1').delay(1000).fadeIn(1000);
$('.go').delay(2000).fadeIn(1000);
$('.out').delay(2000).fadeIn(1000);

//==========按鈕==========
function hover(x) {
    // $('.go').css({ 'color': 'rgba(255,255,255,1)' });
    // $('.go_bk').fadeIn();
    $('.item:eq(' + x + ')').css({ 'color': 'rgba(255,255,255,1)' });
    $('.item:eq(' + x + ')').find('.go_bk').fadeIn();
}

function close() {
    // $('.go').css({ 'color': '' });
    // $('.go_bk').fadeOut(300);
    // $('.out').css({ 'width': '70px', 'height': '70px' });
    // $('path').css({ 'color': 'rgba(100, 100, 200, .3)' });
    $('.item').css({ 'color': '' });
    $('.item').find('.go_bk').fadeOut(300);
}

function click(x) {
    $('.center').fadeOut();
    if (x == 0) {
        setTimeout(function () { location = "select.aspx"; }, 500);
    } else {
        setTimeout(function () { location = "index.aspx"; }, 500);
    }
    // setTimeout(function () { location = "select.aspx"; }, 500);
}

//==========回主頁==========
function hover_out() {
    $('.out').css({ 'width': '100px', 'height': '100px' });
    $('path').css({ 'color': 'rgba(100, 100, 200, 1)' });
}

function click_out() {
    $('.center').fadeOut();
    setTimeout(function () { location = "index.aspx"; }, 500);
}