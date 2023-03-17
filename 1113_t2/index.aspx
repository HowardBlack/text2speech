<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_1113_t2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文字轉語音</title>
    <link rel="stylesheet" href="node_modules\kioskboard\dist\kioskboard-2.3.0.min.css" />
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

    <h1 id="title" style="text-align: center">Text to Speech</h1>
    <div class="container">

        <div class="left" id="phonetic_button">
            <div id="into1">
                <button onclick="type1()" id="ㄅ" class="a1">ㄅ</button>
                <button onclick="type1()" id="ㄆ" class="a1">ㄆ</button>
                <button onclick="type1()" id="ㄇ" class="a1">ㄇ</button>
                <button onclick="type1()" id="ㄈ" class="a1">ㄈ</button>
                <button onclick="type1()" id="ㄉ" class="a1">ㄉ</button>
                <button onclick="type1()" id="ㄊ" class="a1">ㄊ</button>
                <button onclick="type1()" id="ㄋ" class="a1">ㄋ</button>
                <button onclick="type1()" id="ㄌ" class="a1">ㄌ</button>
                <button onclick="type1()" id="ㄍ" class="a1">ㄍ</button>
                <button onclick="type1()" id="ㄎ" class="a1">ㄎ</button>
                <button onclick="type1()" id="ㄏ" class="a1">ㄏ</button>
            </div>

            <div id="into2" style="display: block;">
                <p>
                    <button onclick="nexttype()" id="next1" class="a1" style="background-color: #549eee">
                        ㄐ~ㄙ<br />
                        聲母</button>
                </p>
            </div>

            <div id="into3" style="display: none;">
                <button onclick="type1()" id="ㄐ" class="a1">ㄐ</button>
                <button onclick="type1()" id="ㄑ" class="a1">ㄑ</button>
                <button onclick="type1()" id="ㄒ" class="a1">ㄒ</button>
                <button onclick="type1()" id="ㄓ" class="a1">ㄓ</button>
                <button onclick="type1()" id="ㄔ" class="a1">ㄔ</button>
                <button onclick="type1()" id="ㄕ" class="a1">ㄕ</button>
                <button onclick="type1()" id="ㄖ" class="a1">ㄖ</button>
                <button onclick="type1()" id="ㄗ" class="a1">ㄗ</button>
                <button onclick="type1()" id="ㄘ" class="a1">ㄘ</button>
                <button onclick="type1()" id="ㄙ" class="a1">ㄙ</button>
            </div>

            <div id="into4" style="display: none;">
                <p>
                    <button onclick="nexttype2()" id="next2" class="a1" style="background-color: #549eee">
                        ㄅ~ㄏ<br />
                        聲母</button>
                    <button onclick="nexttype3()" id="next3" class="a1" style="background-color: #549eee">
                        ㄧ~ㄩ<br />
                        介音</button>
                </p>
            </div>

            <div id="into5" style="display: none;">
                <p>
                    <button onclick="type1()" id="ㄧ" class="a1">ㄧ</button>
                    <button onclick="type1()" id="ㄨ" class="a1">ㄨ</button>
                    <button onclick="type1()" id="ㄩ" class="a1">ㄩ</button>
                </p>
                <p>
                    <button onclick="nexttype4()" id="next4" class="a1" style="background-color: #549eee">
                        ㄐ~ㄙ<br />
                        聲母</button>
                    <button onclick="nexttype5()" id="next5" class="a1" style="background-color: #549eee">
                        ㄚ~ㄣ<br />
                        韻母</button>
                </p>
            </div>

            <div id="into6" style="display: none;">
                <button onclick="type1()" id="ㄚ" class="a1">ㄚ</button>
                <button onclick="type1()" id="ㄛ" class="a1">ㄛ</button>
                <button onclick="type1()" id="ㄜ" class="a1">ㄜ</button>
                <button onclick="type1()" id="ㄝ" class="a1">ㄝ</button>
                <button onclick="type1()" id="ㄞ" class="a1">ㄞ</button>
                <button onclick="type1()" id="ㄟ" class="a1">ㄟ</button>
                <button onclick="type1()" id="ㄠ" class="a1">ㄠ</button>
                <button onclick="type1()" id="ㄡ" class="a1">ㄡ</button>
                <button onclick="type1()" id="ㄢ" class="a1">ㄢ</button>
                <button onclick="type1()" id="ㄣ" class="a1">ㄣ</button>

            </div>

            <div id="into7" style="display: none;">
                <p>
                    <button onclick="nexttype6()" id="next6" class="a1" style="background-color: #549eee">
                        ㄧ~ㄩ<br />
                        介音</button>
                    <button onclick="nexttype7()" id="next7" class="a1" style="background-color: #549eee">
                        ㄤ~ㄦ韻母<br />
                        聲調</button>
                </p>
            </div>

            <div id="into8" style="display: none;">
                <button onclick="type1()" id="ㄤ" class="a1">ㄤ</button>
                <button onclick="type1()" id="ㄥ" class="a1">ㄥ</button>
                <button onclick="type1()" id="ㄦ" class="a1">ㄦ</button><p></p>
                <button onclick="type1()" id="ˊ" class="a1">ˊ</button>
                <button onclick="type1()" id="ˇ" class="a1">ˇ</button>
                <button onclick="type1()" id="ˋ" class="a1">ˋ</button>
                <button onclick="type1()" id="˙" class="a1">˙</button>

            </div>

            <div id="into9" style="display: none;">
                <p>
                    <button onclick="nexttype8()" id="next8" class="a1" style="background-color: #549eee">
                        ㄚ~ㄣ<br />
                        韻母</button>
                    <button onclick="nexttype9()" id="next9" class="a1" style="background-color: #549eee">
                        ㄅ~ㄏ<br />
                        聲母</button>
                </p>
            </div>
        </div>

        <div class="right">
            <div class="content">
                <div id="voice_and_inputText">
                    <select id="voices"></select><br />
                    <textarea id="userInput" placeholder="Your Name" style="width: 1480px; height: 280px"></textarea>
                </div>
            </div>

            <div class="content" id="unicodeImg"></div>

            <div class="content">
                <button click="start" id="play" class="event btn1">PLAY</button>
                <button click="cancel" id="cancel" class="event btn4">CANCEL</button><br />
            </div>
        </div>

    </div>


    <script src="jquery-3.4.1.min.js"></script>
    <script src="index.js"></script>
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
                    console.log(result);
                },
                error() {

                }
            })
        }

        function nexttype() {
            var a = document.getElementById("into1")
            var b = document.getElementById("into2")
            var c = document.getElementById("into3")
            var d = document.getElementById("into4")
            if (c.style.display === "none") {
                a.style.display = "none";
                b.style.display = "none";
                c.style.display = "block";
                d.style.display = "block";
            }
        }
        function nexttype2() {
            var a = document.getElementById("into1")
            var b = document.getElementById("into2")
            var c = document.getElementById("into3")
            var d = document.getElementById("into4")
            if (a.style.display === "none") {
                a.style.display = "block";
                b.style.display = "block";
                c.style.display = "none";
                d.style.display = "none";
            }
        }
        function nexttype3() {
            var a = document.getElementById("into3")
            var b = document.getElementById("into4")
            var c = document.getElementById("into5")
            if (c.style.display === "none") {
                a.style.display = "none";
                b.style.display = "none";
                c.style.display = "block";
            }
        }
        function nexttype4() {
            var a = document.getElementById("into3")
            var b = document.getElementById("into4")
            var c = document.getElementById("into5")
            if (a.style.display === "none") {
                a.style.display = "block";
                b.style.display = "block";
                c.style.display = "none";
            }
        }
        function nexttype5() {
            var a = document.getElementById("into5")
            var b = document.getElementById("into6")
            var c = document.getElementById("into7")
            if (c.style.display === "none") {
                a.style.display = "none";
                b.style.display = "block";
                c.style.display = "block";
            }
        }
        function nexttype6() {
            var a = document.getElementById("into5")
            var b = document.getElementById("into6")
            var c = document.getElementById("into7")
            if (a.style.display === "none") {
                a.style.display = "block";
                b.style.display = "none";
                c.style.display = "none";
            }
        }
        function nexttype7() {
            var a = document.getElementById("into6")
            var b = document.getElementById("into7")
            var c = document.getElementById("into8")
            var d = document.getElementById("into9")
            if (c.style.display === "none") {
                a.style.display = "none";
                b.style.display = "none";
                c.style.display = "block";
                d.style.display = "block";
            }
        }
        function nexttype8() {
            var a = document.getElementById("into6")
            var b = document.getElementById("into7")
            var c = document.getElementById("into8")
            var d = document.getElementById("into9")
            if (a.style.display === "none") {
                a.style.display = "block";
                b.style.display = "block";
                c.style.display = "none";
                d.style.display = "none";
            }
        }
        function nexttype9() {
            var a = document.getElementById("into8")
            var b = document.getElementById("into9")
            var c = document.getElementById("into1")
            var d = document.getElementById("into2")
            if (c.style.display === "none") {
                a.style.display = "none";
                b.style.display = "none";
                c.style.display = "block";
                d.style.display = "block";
            }
        }
    </script>
    <script src="tts.js"></script>
</body>
</html>
