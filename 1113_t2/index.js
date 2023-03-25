$('.center').fadeIn(1000);  //初始畫面

function hover(x) {  //觸碰按鈕
    console.log("1");
    $('.go:eq(' + x + ')').css({ 'color': 'rgba(255,255,255,1)' });
    $('.go:eq(' + x + ')').find('.go_bk').fadeIn()
    
}

function click(x) {
 
    if (x == 0) {
        console.log("2");
        speech.text = document.querySelector("textarea").value;
        window.speechSynthesis.speak(speech);
    } else if (x == 1) {
        console.log("x=1");
        window.speechSynthesis.cancel();
    }else {
        $('.msg').fadeIn(700);
        $('.msg').css({ 'display': 'flex' });
        $('.msg_box').fadeIn();
        setTimeout(function () {
            $('.msg_box').fadeOut();
            $('.msg').fadeOut();
        }, 1500);
    }
}

function close(x) {  //清除按鈕
    $('.go').css({ 'color': '' });
    $('.go').find('.go_bk').fadeOut(300);
    // console.log("3");
}
