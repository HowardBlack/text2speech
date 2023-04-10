
function test(blockName, item) {

}

/*
var api_url = 'api/Text2Speache';
// 設定 currentPage 為當前頁面 及 countPage 為頁面總數

let currentPage, countPage;

function testapi() {
    $.ajax({
        url: api_url,
        method: 'GET',
        data: `pinyin=ㄅㄨˇ`,
        success(result) {
           console.log(result)
        },
        error(error) {
            // 顯示連線錯誤訊息...
            console.log(error);
        }
    })
}

function PinyinClick() { //注音鍵點擊事件
    let userInput = document.getElementById('userInput');
    userInput.textContent += event.target.textContent;

    console.log(userInput.textContent)
    $.ajax({
        url: api_url,
        method: 'GET',
        data: `pinyin=${userInput.textContent}`,
        contentType: 'application/json; charset=urf-8',
        success(result) {
            // 清除先前文字選項
            $('#textShow').empty();
            // 將 unicode 陣列放置 resCode 變數
            const resCode = $.parseJSON(result);
            console.log(resCode)
            // 判斷 resCode 是否有資料
            if (resCode.length) {
                // 設定 頁面總數 及 當前頁面 都是 1
                countPage = currentPage = 1;
                resCode.forEach((code, index) => {
                    // 為方便待會判斷，將 index + 1
                    index++;
                    // 將 unicode 轉成 16 進制                            
                    const unicodeText = String.fromCharCode(parseInt(code["unicode"], 16));
                    // 判斷每頁元素是否存在，如果不存在即新增
                    if (!$(`.test${countPage}`).length)
                        $('#textShow').append(`<div class="test${countPage}"></div>`);
                    // 新增每個文字至對應的頁面。尚未寫 button call function event
                    $(`.test${countPage}`).append(`<button class="test" onclick="InsertText('${unicodeText}')">${unicodeText}</button>`);
                    // 判斷 index 是否整除 6，如果整除就 countPage + 1，區分不同頁面的 類別編號
                    if (index % 6 == 0) countPage++;
                })
                // 初始化所有頁面看不到
                for (let i = 1; i <= countPage; i++)
                    $(`.test${i}`).css('display', 'none');
                // 預設顯示第一頁
                $(`.test${currentPage}`).css('display', 'block');
            } else {
                // 查無資料做什麼事情...
                console.log("查無資料");
            }
        },
        error(error) {
            // 顯示連線錯誤訊息...
            console.log(error);
        }
    })
}

function initOption() {
    $('.pinyinWord').each((e) => {
        e.style('')
    })
}

function PinyinChange(type) { //切換注音
    function init() {
        for (var i = 1; i < 8; i++) {
            let temp = document.getElementById("into" + i);
            temp.style.display = "none";
        }
    }

    init();

    let temp = document.getElementById("into" + type);
    temp.style.display = "flex";
    // DisplayChange(temp,)
}

function FontChange(p) { // 切換文字
    const newPage = currentPage + p;
    if (newPage > 0 && newPage <= countPage) {
        $(`.test${currentPage}`).css('display', 'none');
        $(`.test${newPage}`).css('display', 'block');
        currentPage = newPage;
    }
}

function InsertText(text) { // 新增點選文字至 choiceText textarea
    // 加入選取文字至 choiceText
    $('#choiceText').append(text);
    // 清空 userInput textarea 以輸入下一個注音
    $('#userInput').empty();
    // 清空 textShow
    $('#textShow').empty();
}

function PinyinDelete() { // 刪除 注音 或 選取文字
    // 如果 userInput 有長度，帶入 userInput，反之帶入 choiceText
    let textarea = ($('#userInput').val().length) ? $('#userInput') : $('#choiceText');
    // 取出 textarea 原始文字
    let originText = textarea.text();
    // 刪除 textarea 最後一個字
    let newText = originText.slice(0, -1);
    // 將結果重新放回 textarea
    textarea.text(newText);
}

function hover(x) {  //觸碰按鈕
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
    //console.log("無效");
}

function test() {
    console.log("test有效");
}
*/