<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_1113_t2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>start</title>
    <link rel="stylesheet" href="preset.css" />
    <link rel="stylesheet" href="start.css" />
    <link rel="stylesheet" href="select.css"/>
    
    <style>
        body
        {
            font-family: 微軟正黑體;
            font-size: 50px;
            background: url(https://images.unsplash.com/photo-1625777719130-0a8e07086117?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1500&q=80) no-repeat center fixed;            
            
            background-size: cover;
        }
        div
        {
            text-align: center;
        }        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
        <div class="center">
            <div class="row">
                <div class="box col-5 color_b">
                    <h1>                        
                        身體逐項檢查
                        <br />
                        身體重點檢查
                    </h1>
                    <div class="item color_b">
                        <div class="go_bk bk_b"></div>
                        開始檢查
                    </div>
                </div>
                <div class="box col-5 color_p">
                    <h1>                        
                        文字轉語音
                        <br />
                        與我們對話
                    </h1>
                    <div class="item color_p">
                        <div class="go_bk bk_p"></div>
                        表達訊息
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="jquery-3.4.1.min.js"></script>
    <script src="start.js"></script>
            
</body>
</html>
