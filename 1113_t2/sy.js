$('.center').fadeIn(2000);

function hover(x) {
    $('.item:eq(' + x + ')').css({ 'width': '250px', 'height': '250px' });
    $('.item:eq(' + x + ')').find('.go_bk').fadeIn();
}

function close() {
    $('.item').css({ 'width': '200px', 'height': '200px' });
    $('.item').find('.go_bk').fadeOut(300);
}

function click(x) {
    $('.pm').fadeOut(0);
    $('.pm').find('img').attr('src','img/' + x +'.png');
        switch (x) {
            case 0:
                $('.pm').find('h1').text('頭部');
                break;
            case 1:
                $('.pm').find('h1').text('肩頸');
                break;
            case 2:
                $('.pm').find('h1').text('胸部');
                break;
            case 3:
                $('.pm').find('h1').text('手部');
                break;
            case 4:
                $('.pm').find('h1').text('腹部');
                break;
            case 5:
                $('.pm').find('h1').text('腰部');
                break;
            case 6:
                $('.pm').find('h1').text('臀部');
                break;
            case 7:
                $('.pm').find('h1').text('腳部');
                break;
            default:
                $('.center').fadeOut()
                $('.msg').fadeIn(700);
                $('.msg').css({ 'display': 'flex' });
                $('.msg_box').fadeIn();
                setTimeout(function () {
                    $('.msg_box').fadeOut();
                    $('.msg').fadeOut();
                }, 1500);
                setTimeout(function () { location = "index.aspx"; }, 2000);
                break;
    }
    $('.pm').fadeIn(1000);
}