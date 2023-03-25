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
                    <!-- 有必要嗎 沒有的話就刪掉 -->
                    <select id="voices"></select>                   

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
    <!-- 文字轉語音 -->

    <script>     
        


        function PinyinClick() { //注音鍵點擊事件
            let userInput = document.getElementById('userInput');
            userInput.textContent += event.target.textContent;

            $.ajax({
                url: '<%= ResolveUrl("~/sqlTest.aspx/Get_Unicode") %>',
                method: 'POST',
                data: JSON.stringify({ 'pinyin': userInput.textContent }),
                contentType: 'application/json; charset=urf-8',
                success(result) {
                    str = String.fromCodePoint(parseInt('8AA7', 16))
                    console.log(str)

                    for (let u of result['d']) {
                        console.log(String.fromCodePoint(parseInt(u, 16)), u); // 誧 
                        
                        
                        //console.log(String.fromCharCode('0x' + u) , u); // 誧 
                        //$("#unicodeImg").append(`<img src="https://www.cns11643.gov.tw/char/kai/96/${u}.png">`);
                    }
                },
                error() {

                }
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
            DisplayChange(temp,)
        }

        function FontChange(type) { // 切換文字

        }
    </script>

</body>
</html>
