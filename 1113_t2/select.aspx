<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select.aspx.cs" Inherits="_1113_t2.select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>select</title>
    <link rel="stylesheet" href="preset.css" />
    <link rel="stylesheet" href="select.css" />
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
            <div class="main row">
                <div class="box col-5 color_r">
                    <h1>
                        <br>
                        將逐一詢問部位
                    <br>
                        詳細程序、須長時間
                    </h1>
                    <div class="item color_r">
                        <div class="go_bk bk_r"></div>
                        逐式檢查
                    </div>
                </div>
                <div class="box col-5 color_b">
                    <h1>
                        <br>
                        直接選擇部位
                    <br>
                        稍少程序、減省時間
                    </h1>
                    <div class="item color_b">
                        <div class="go_bk bk_b"></div>
                        重點檢查
                    </div>
                </div>
            </div>
        </div>

    </form>

    <script src="jquery-3.4.1.min.js"></script>
    <script src="select.js"></script>
</body>
</html>
