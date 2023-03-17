<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sy.aspx.cs" Inherits="_1113_t2.sy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>sy</title>
    <link rel="stylesheet" href="preset.css" />
    <link rel="stylesheet" href="sy.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="center">
            <div class="main color_p">
                <div class="row ig">
                    <div class="pm">
                        <div class="pm_img">
                            <img src="img/0.png">
                        </div>
                        <h1>頭部</h1>
                    </div>
                </div>
                <div class="row mes">
                    <div class="ms color_g">
                        沒問題!
                        <div class="s color_g"></div>
                    </div>
                    <div class="ms color_o">
                        有點怪怪的?
                        <div class="s color_o"></div>
                    </div>
                    <div class="ms color_r">
                        不大好!
                        <div class="s color_r"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="item color_g">
                        <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="smile"
                            class="svg-inline--fa fa-smile fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 496 512">
                            <path class="color_g" fill="currentColor"
                                d="M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zm0 448c-110.3 0-200-89.7-200-200S137.7 56 248 56s200 89.7 200 200-89.7 200-200 200zm-80-216c17.7 0 32-14.3 32-32s-14.3-32-32-32-32 14.3-32 32 14.3 32 32 32zm160 0c17.7 0 32-14.3 32-32s-14.3-32-32-32-32 14.3-32 32 14.3 32 32 32zm4 72.6c-20.8 25-51.5 39.4-84 39.4s-63.2-14.3-84-39.4c-8.5-10.2-23.7-11.5-33.8-3.1-10.2 8.5-11.5 23.6-3.1 33.8 30 36 74.1 56.6 120.9 56.6s90.9-20.6 120.9-56.6c8.5-10.2 7.1-25.3-3.1-33.8-10.1-8.4-25.3-7.1-33.8 3.1z">
                            </path>
                        </svg>
                        <div class="go_bk go_bk_g"></div>
                    </div>
                    <div class="item color_o">
                        <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="meh"
                            class="svg-inline--fa fa-meh fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 496 512">
                            <path class="color_o" fill="currentColor"
                                d="M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zm0 448c-110.3 0-200-89.7-200-200S137.7 56 248 56s200 89.7 200 200-89.7 200-200 200zm-80-216c17.7 0 32-14.3 32-32s-14.3-32-32-32-32 14.3-32 32 14.3 32 32 32zm160-64c-17.7 0-32 14.3-32 32s14.3 32 32 32 32-14.3 32-32-14.3-32-32-32zm8 144H160c-13.2 0-24 10.8-24 24s10.8 24 24 24h176c13.2 0 24-10.8 24-24s-10.8-24-24-24z">
                            </path>
                        </svg>
                        <div class="go_bk go_bk_o"></div>
                    </div>
                    <div class="item color_r">
                        <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="frown"
                            class="svg-inline--fa fa-frown fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 496 512">
                            <path class="color_r" fill="currentColor"
                                d="M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zm0 448c-110.3 0-200-89.7-200-200S137.7 56 248 56s200 89.7 200 200-89.7 200-200 200zm-80-216c17.7 0 32-14.3 32-32s-14.3-32-32-32-32 14.3-32 32 14.3 32 32 32zm160-64c-17.7 0-32 14.3-32 32s14.3 32 32 32 32-14.3 32-32-14.3-32-32-32zm-80 128c-40.2 0-78 17.7-103.8 48.6-8.5 10.2-7.1 25.3 3.1 33.8 10.2 8.4 25.3 7.1 33.8-3.1 16.6-19.9 41-31.4 66.9-31.4s50.3 11.4 66.9 31.4c8.1 9.7 23.1 11.9 33.8 3.1 10.2-8.5 11.5-23.6 3.1-33.8C326 321.7 288.2 304 248 304z">
                            </path>
                        </svg>
                        <div class="go_bk go_bk_r"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="msg">
            <div class="msg_box">
                已完成檢查
            </div>
        </div>
    </form>

    <script src="jquery-3.4.1.min.js"></script>
    <script src="sy.js"></script>
</body>
</html>
