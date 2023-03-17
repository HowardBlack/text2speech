<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sf.aspx.cs" Inherits="_1113_t2.sf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="preset.css">
    <link rel="stylesheet" href="sf.css">
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
            <div class="row">
                <div class="item color_r">
                    <div class="go_bk bk_r"></div>
                    <div class="i_img">
                        <img src="img/0.png">
                    </div>
                    <div class="i_txt">
                        頭部
                    </div>
                </div>
                <div class="item color_r">
                    <div class="go_bk bk_r"></div>
                    <div class="i_img">
                        <img src="img/1.png">
                    </div>
                    <div class="i_txt">
                        肩頸
                    </div>
                </div>
                <div class="item color_o">
                    <div class="go_bk bk_o"></div>
                    <div class="i_img">
                        <img src="img/2.png">
                    </div>
                    <div class="i_txt">
                        胸部
                    </div>
                </div>
                <div class="item color_o">
                    <div class="go_bk bk_o"></div>
                    <div class="i_img">
                        <img src="img/3.png">
                    </div>
                    <div class="i_txt">
                        手部
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="item color_g">
                    <div class="go_bk bk_g"></div>
                    <div class="i_img">
                        <img src="img/4.png">
                    </div>
                    <div class="i_txt">
                        腹部
                    </div>
                </div>
                <div class="item color_g">
                    <div class="go_bk bk_g"></div>
                    <div class="i_img">
                        <img src="img/5.png">
                    </div>
                    <div class="i_txt">
                        腰部
                    </div>
                </div>
                <div class="item color_b">
                    <div class="go_bk bk_b"></div>
                    <div class="i_img">
                        <img src="img/6.png">
                    </div>
                    <div class="i_txt">
                        臀部
                    </div>
                </div>
                <div class="item color_b">
                    <div class="go_bk bk_b"></div>
                    <div class="i_img">
                        <img src="img/7.png">
                    </div>
                    <div class="i_txt">
                        腳部
                    </div>
                </div>
            </div>
            <div class="row gohome">
                <div class="item color_p">
                    <div class="go_bk bk_p"></div>
                    <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="sign-out-alt"
                        class="svg-inline--fa fa-sign-out-alt fa-w-16" role="img" viewBox="0 0 512 512">
                        <path class="color_p" fill="currentColor"
                            d="M497 273L329 441c-15 15-41 4.5-41-17v-96H152c-13.3 0-24-10.7-24-24v-96c0-13.3 10.7-24 24-24h136V88c0-21.4 25.9-32 41-17l168 168c9.3 9.4 9.3 24.6 0 34zM192 436v-40c0-6.6-5.4-12-12-12H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h84c6.6 0 12-5.4 12-12V76c0-6.6-5.4-12-12-12H96c-53 0-96 43-96 96v192c0 53 43 96 96 96h84c6.6 0 12-5.4 12-12z">
                        </path>
                    </svg>
                </div>
            </div>
        </div>
    </form>
    <script src="jquery-3.4.1.min.js"></script>
    <script src="sf.js"></script>
</body>
</html>
