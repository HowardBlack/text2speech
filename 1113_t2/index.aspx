<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_1113_t2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文字轉語音</title>
    <link href="./css/index.css" rel="stylesheet" />
</head>

<body>

    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

    <div class="container">

        <div class="Showblock">
            <div id="voice_and_inputText">
                <select id="voices"></select>
                <!-- 有必要嗎 沒有的話就刪掉 -->
                <br />
                <div style="display:flex; justify-content: center;">
                    <textarea id="userInput" disabled="disabled"></textarea>
                    <textarea id="choiceText" disabled="disabled"></textarea>
                    <button class="test" id="pinyinDelete" onclick="PinyinDelete()">⇦backspace</button>
                </div>
            </div>
            <div class="select" id="unicodeImg">
                <!-- 測試文字顯示效果 -->
                <button class="test" onclick="FontChange(-1)">⇦</button>
                <div id="textShow"></div>
                <!-- 在這放文字 -->
                <button class="test" onclick="FontChange(1)">⇨</button>
            </div>
        </div>

        <div class="Keyboard" id="phonetic_button">

            <div class="Pinyin">

                <div id="into1" style="display: block;">
                    <button id="ㄅ" onclick="PinyinClick()">ㄅ</button>
                    <button id="ㄆ" onclick="PinyinClick()">ㄆ</button>
                    <button id="ㄇ" onclick="PinyinClick()">ㄇ</button>
                    <button id="ㄈ" onclick="PinyinClick()">ㄈ</button>
                    <button id="ㄉ" onclick="PinyinClick()">ㄉ</button>
                    <button id="ㄊ" onclick="PinyinClick()">ㄊ</button>
                    <button id="ㄋ" onclick="PinyinClick()">ㄋ</button>
                </div>

                <div id="into2" style="display: none;">
                    <button id="ㄌ" onclick="PinyinClick()">ㄌ</button>
                    <button id="ㄍ" onclick="PinyinClick()">ㄍ</button>
                    <button id="ㄎ" onclick="PinyinClick()">ㄎ</button>
                    <button id="ㄏ" onclick="PinyinClick()">ㄏ</button>
                    <button id="ㄐ" onclick="PinyinClick()">ㄐ</button>
                    <button id="ㄑ" onclick="PinyinClick()">ㄑ</button>
                    <button id="ㄒ" onclick="PinyinClick()">ㄒ</button>
                </div>

                <div id="into3" style="display: none;">
                    <button id="ㄓ" onclick="PinyinClick()">ㄓ</button>
                    <button id="ㄔ" onclick="PinyinClick()">ㄔ</button>
                    <button id="ㄕ" onclick="PinyinClick()">ㄕ</button>
                    <button id="ㄖ" onclick="PinyinClick()">ㄖ</button>
                    <button id="ㄗ" onclick="PinyinClick()">ㄗ</button>
                    <button id="ㄘ" onclick="PinyinClick()">ㄘ</button>
                    <button id="ㄙ" onclick="PinyinClick()">ㄙ</button>
                </div>

                <div id="into4" style="display: none;">
                    <button id="ㄧ" onclick="PinyinClick()">ㄧ</button>
                    <button id="ㄨ" onclick="PinyinClick()">ㄨ</button>
                    <button id="ㄩ" onclick="PinyinClick()">ㄩ</button>
                </div>

                <div id="into5" style="display: none;">
                    <button id="ㄚ" onclick="PinyinClick()">ㄚ</button>
                    <button id="ㄛ" onclick="PinyinClick()">ㄛ</button>
                    <button id="ㄜ" onclick="PinyinClick()">ㄜ</button>
                    <button id="ㄝ" onclick="PinyinClick()">ㄝ</button>
                    <button id="ㄞ" onclick="PinyinClick()">ㄞ</button>
                    <button id="ㄟ" onclick="PinyinClick()">ㄟ</button>
                    <button id="ㄠ" onclick="PinyinClick()">ㄠ</button>
                </div>

                <div id="into6" style="display: none;">
                    <button id="ㄡ" onclick="PinyinClick()">ㄡ</button>
                    <button id="ㄢ" onclick="PinyinClick()">ㄢ</button>
                    <button id="ㄣ" onclick="PinyinClick()">ㄣ</button>
                    <button id="ㄤ" onclick="PinyinClick()">ㄤ</button>
                    <button id="ㄥ" onclick="PinyinClick()">ㄥ</button>
                    <button id="ㄦ" onclick="PinyinClick()">ㄦ</button>
                </div>

                <div id="into7" style="display: none;">
                    <button id="ˊ" onclick="PinyinClick()">ˊ</button>
                    <button id="ˇ" onclick="PinyinClick()">ˇ</button>
                    <button id="ˋ" onclick="PinyinClick()">ˋ</button>
                    <button id="˙" onclick="PinyinClick()">˙</button>
                </div>

                <div class="Group" id="change_pinyin">
                    <button class="Change" id="change_pinyin1" onclick="PinyinChange(1)">
                        ㄅ~ㄋ<br />
                        聲母</button>

                    <button class="Change" id="change_pinyin2" onclick="PinyinChange(2)">
                        ㄌ~ㄒ<br />
                        聲母</button>

                    <button class="Change" id="change_pinyin3" onclick="PinyinChange(3)">
                        ㄓ~ㄙ<br />
                        聲母</button>

                    <button class="Change" id="change_pinyin4" onclick="PinyinChange(4)">
                        ㄧ~ㄩ<br />
                        介音</button>

                    <button class="Change" id="change_pinyin5" onclick="PinyinChange(5)">
                        ㄚ~ㄠ<br />
                        韻母</button>

                    <button class="Change" id="change_pinyin6" onclick="PinyinChange(6)">
                        ㄡ~ㄦ<br />
                        韻母</button>

                    <button class="Change" id="change_pinyin7" onclick="PinyinChange(7)">
                        聲調<br />
                    </button>

                </div>
            </div>

            <!-- 控制聲音 -->
            <div class="Voice">
                <button class="Play" click="start" id="play">PLAY</button>
                <button class="Cancel" click="cancel" id="cancel">CANCEL</button>
                <!-- 我覺得可以改成到退鍵 -->
            </div>
        </div>

    </div>

    <script src="jquery-3.4.1.min.js"></script>
    <script src="index.js"></script>
    <script src="tts.js"></script>
    <script>
        // 設定 currentPage 為當前頁面 及 countPage 為頁面總數
        let currentPage, countPage;

        function PinyinClick() { //注音鍵點擊事件
            let userInput = document.getElementById('userInput');
            userInput.textContent += event.target.textContent;

            $.ajax({
                url: '<%= ResolveUrl("~/sqlTest.aspx/Get_Unicode") %>',
                method: 'POST',
                data: JSON.stringify({ 'pinyin': userInput.textContent }),
                contentType: 'application/json; charset=urf-8',
                success(result) {
                    // 清除先前文字選項
                    $('#textShow').empty();
                    // 將 unicode 陣列放置 resCode 變數
                    const resCode = result['d'];
                    // 判斷 resCode 是否有資料
                    if (resCode.length) {
                        // 設定 頁面總數 及 當前頁面 都是 1
                        countPage = currentPage = 1;
                        resCode.forEach((code, index) => {
                            // 為方便待會判斷，將 index + 1
                            index++;
                            // 將 unicode 轉成 16 進制                            
                            const unicodeText = String.fromCharCode(parseInt(code, 16));
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
            temp.style.display = "block";
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

        // 暫時有bug，頁面實際已經刪除，但html文字還在
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

    </script>

</body>
</html>
