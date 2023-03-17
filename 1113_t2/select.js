$('.center').fadeIn(2000);  //初始畫面

function hover(x) { //觸碰方塊
    $('.item:eq(' + x + ')').css({ 'color': 'rgba(255,255,255,1)' });
    $('.item:eq(' + x + ')').find('.go_bk').fadeIn();
}

function close() {  //清除方塊
    $('.item').css({ 'color': '' });
    $('.item').find('.go_bk').fadeOut(300);
}


function click(x) {
    $('.center').fadeOut();
    if (x == 0) {
        setTimeout(function () { location = "sy.aspx"; }, 500);
    } else {
        setTimeout(function () { location = "sf.aspx"; }, 500);
    }
}