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

            <div class="content">

                <div id="voice_and_inputText">
                    <select id="voices"></select>
                    <!-- 有必要嗎 沒有的話就刪掉 -->
                    <br />
                    <br />
                    <textarea id="userInput"></textarea>
                    <!-- style="width: 1480px; height: 280px" placeholder="Your Name"-->
                </div>

                <div class="select" id="unicodeImg">
                    <!-- 測試文字顯示效果 -->
                    <button class="test">⇦</button>
                    <!-- 在這放文字 測試效果 可以刪掉 -->
                    <button class="test">母</button>
                    <button class="test">母</button>
                    <button class="test">母</button>
                    <button class="test">母</button>
                    <button class="test">母</button>
                    <button class="test">母</button>
                    <button class="test">母</button>
                    <!-- 在這放文字 -->
                    <button class="test">⇨</button>
                </div>
            </div>
        </div>

        <div class="Keyboard" id="phonetic_button">

            <div class="Pinyin">

                <div id="into1" style="display: block;">
                    <button id="ㄅ" onclick="type1()" >ㄅ</button>
                    <button id="ㄆ" onclick="type1()" >ㄆ</button>
                    <button id="ㄇ" onclick="type1()" >ㄇ</button>
                    <button id="ㄈ" onclick="type1()" >ㄈ</button>
                    <button id="ㄉ" onclick="type1()" >ㄉ</button>
                    <button id="ㄊ" onclick="type1()" >ㄊ</button>
                    <button id="ㄋ" onclick="type1()" >ㄋ</button>
                </div>

                <div id="into2" style="display: none;">
                    <button id="ㄌ" onclick="type1()" >ㄌ</button>
                    <button id="ㄍ" onclick="type1()" >ㄍ</button>
                    <button id="ㄎ" onclick="type1()" >ㄎ</button>
                    <button id="ㄏ" onclick="type1()" >ㄏ</button>
                    <button id="ㄐ" onclick="type1()" >ㄐ</button>
                    <button id="ㄑ" onclick="type1()" >ㄑ</button>
                    <button id="ㄒ" onclick="type1()" >ㄒ</button>
                </div>

                <div id="into3" style="display: none;">
                    <button id="ㄓ" onclick="type1()" >ㄓ</button>
                    <button id="ㄔ" onclick="type1()" >ㄔ</button>
                    <button id="ㄕ" onclick="type1()" >ㄕ</button>
                    <button id="ㄖ" onclick="type1()" >ㄖ</button>
                    <button id="ㄗ" onclick="type1()" >ㄗ</button>
                    <button id="ㄘ" onclick="type1()" >ㄘ</button>
                    <button id="ㄙ" onclick="type1()" >ㄙ</button>
                </div>

                <div id="into4" style="display: none;">
                    <button id="ㄧ" onclick="type1()" >ㄧ</button>
                    <button id="ㄨ" onclick="type1()" >ㄨ</button>
                    <button id="ㄩ" onclick="type1()" >ㄩ</button>
                </div>

                <div id="into5" style="display: none;">
                    <button id="ㄚ" onclick="type1()" >ㄚ</button>
                    <button id="ㄛ" onclick="type1()" >ㄛ</button>
                    <button id="ㄜ" onclick="type1()" >ㄜ</button>
                    <button id="ㄝ" onclick="type1()" >ㄝ</button>
                    <button id="ㄞ" onclick="type1()" >ㄞ</button>
                    <button id="ㄟ" onclick="type1()" >ㄟ</button>
                    <button id="ㄠ" onclick="type1()" >ㄠ</button>
                </div>

                <div id="into6" style="display: none;">
                    <button id="ㄡ" onclick="type1()">ㄡ</button>
                    <button id="ㄢ" onclick="type1()">ㄢ</button>
                    <button id="ㄣ" onclick="type1()">ㄣ</button>
                    <button id="ㄤ" onclick="type1()">ㄤ</button>
                    <button id="ㄥ" onclick="type1()">ㄥ</button>
                    <button id="ㄦ" onclick="type1()">ㄦ</button>
                </div>

                <div id="into7" style="display: none;">
                    <button id="ˊ" onclick="type1()">ˊ</button>
                    <button id="ˇ" onclick="type1()">ˇ</button>
                    <button id="ˋ" onclick="type1()">ˋ</button>
                    <button id="˙" onclick="type1()">˙</button>
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
                <button class="Cancel" click="cancel" id="cancel">CANCEL</button> <!-- 我覺得可以改成到退鍵 -->
            </div>
        </div>

    </div>

    <script src="jquery-3.4.1.min.js"></script>
    <script src="index.js"></script>
    <script src="tts.js"></script>
    <!-- 文字轉語音 -->

    <script>
        let userInput = document.getElementById('userInput');

        function type1() {
            userInput.textContent += event.target.textContent;
            const resUnicode = getUnicode(userInput.textContent);
            if (resUnicode.length) {
                $('#unicodeImg').text('');
                for (let u of resUnicode) {
                    const unicodeValue = `0x${u}`;
                    console.log(String.fromCharCode(unicodeValue)); // 誧 
                    $("#unicodeImg").append(`<img src="https://www.cns11643.gov.tw/char/kai/96/${u}.png">`);
                }
            } else {
                $('#unicodeImg').text("查無資料!");
            }
        }

        function getUnicode(phonetic_notation) {
            $.ajax({
                url: '<%= ResolveUrl("~/sqlTest.aspx/Get_Unicode") %>',
                method: 'POST',
                data: JSON.stringify({ 'pinyin': phonetic_notation }),
                contentType: 'application/json; charset=urf-8',
                success(result) {
                    for (let u of result['d']) {
                        const unicodeValue = `0x${u}`;
                        console.log(String.fromCharCode(unicodeValue)); // 誧 
                        $("#unicodeImg").append(`<img src="https://www.cns11643.gov.tw/char/kai/96/${u}.png">`);
                    }
                },
                error() {

                }
            })
        }

        function PinyinClick(type) { //注音鍵點擊事件

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
            DisplayChange(temp, )
        }

        function FontChange(type) { // 切換文字

        }
    </script>

</body>
</html>
