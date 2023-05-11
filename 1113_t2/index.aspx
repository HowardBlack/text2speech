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
                <div style="display: flex; justify-content: center;">
                    <textarea id="PinyinInput0" disabled="disabled"></textarea>
                    <textarea id="WordText0" disabled="disabled"></textarea>

                    <button class="test" id="pinyinDelete" onclick="PinyinDelete()">⇦backspace</button>
                </div>
            </div>
            <div class="select" id="unicodeImg">
                <button onclick="FontChange(-1)">⇦</button>
                <button id="Word0" onclick=""></button>
                <button id="Word1" onclick=""></button>
                <button id="Word2" onclick=""></button>
                <button id="Word3" onclick=""></button>
                <button id="Word4" onclick=""></button>
                <button id="Word5" onclick=""></button>                
                <button onclick="FontChange(1)">⇨</button>
            </div>
        </div>

        <div class="Keyboard" id="phonetic_button">

            <div class="Pinyin">

                <div class="Show" id="into1" style="display: flex;">
                    <button id="Pinyin0" onclick="PinyinClick()">ㄅ</button>
                    <button id="Pinyin1" onclick="PinyinClick()">ㄆ</button>
                    <button id="Pinyin2" onclick="PinyinClick()">ㄇ</button>
                    <button id="Pinyin3" onclick="PinyinClick()">ㄈ</button>
                    <button id="Pinyin4" onclick="PinyinClick()">ㄉ</button>
                    <button id="Pinyin5" onclick="PinyinClick()">ㄊ</button>
                    <button id="Pinyin6" onclick="PinyinClick()">ㄋ</button>
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

            <div class="Voice">
                <button class="Play" click="start" id="play">PLAY</button>
                <button class="Cancel" click="cancel" id="cancel">CANCEL</button>
            </div>

        </div>

    </div>

    <script src="jquery-3.4.1.min.js"></script>
    <script src="index.js"></script>
    <script src="tts.js"></script>
</body>
</html>
