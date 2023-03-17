<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hb.aspx.cs" Inherits="_1113_t2.hb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="preset.css" />
    <link rel="stylesheet" href="hb.css" />
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

            <div class="center">
                <div class="row color_r">
                    <div class="item_hover item_hover_r"></div>
                    <div class="title color_r">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="bed"
                            class="title_svg svg-inline--fa fa-bed fa-w-20" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 640 512">
                            <path class="color_r" fill="currentColor"
                                d="M176 256c44.11 0 80-35.89 80-80s-35.89-80-80-80-80 35.89-80 80 35.89 80 80 80zm352-128H304c-8.84 0-16 7.16-16 16v144H64V80c0-8.84-7.16-16-16-16H16C7.16 64 0 71.16 0 80v352c0 8.84 7.16 16 16 16h32c8.84 0 16-7.16 16-16v-48h512v48c0 8.84 7.16 16 16 16h32c8.84 0 16-7.16 16-16V240c0-61.86-50.14-112-112-112z">
                            </path>
                        </svg>
                        <text>頭部高度</text>
                    </div>

                    <div class="item go_bk_r color_r">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-up"
                            class="svg-inline--fa fa-chevron-up fa-w-14" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 448 512">
                            <path class="color_r" fill="currentColor"
                                d="M240.971 130.524l194.343 194.343c9.373 9.373 9.373 24.569 0 33.941l-22.667 22.667c-9.357 9.357-24.522 9.375-33.901.04L224 227.495 69.255 381.516c-9.379 9.335-24.544 9.317-33.901-.04l-22.667-22.667c-9.373-9.373-9.373-24.569 0-33.941L207.03 130.525c9.372-9.373 24.568-9.373 33.941-.001z">
                            </path>
                        </svg>
                        <div class="go_bk bk_r"></div>
                    </div>
                    <div class="item go_bk_k color_r">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-down"
                            class="svg-inline--fa fa-chevron-down fa-w-14" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 448 512">
                            <path fill="currentColor"
                                d="M207.029 381.476L12.686 187.132c-9.373-9.373-9.373-24.569 0-33.941l22.667-22.667c9.357-9.357 24.522-9.375 33.901-.04L224 284.505l154.745-154.021c9.379-9.335 24.544-9.317 33.901.04l22.667 22.667c9.373 9.373 9.373 24.569 0 33.941L240.971 381.476c-9.373 9.372-24.569 9.372-33.942 0z">
                            </path>
                        </svg>
                        <div class="go_bk bk_k"></div>
                    </div>
                </div>
                <div class="row color_b">
                    <div class="item_hover item_hover_b"></div>
                    <div class="title color_b">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="socks"
                            class="title_svg svg-inline--fa fa-socks fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 512 512">
                            <path class="color_b" fill="currentColor"
                                d="M214.66 311.01L288 256V96H128v176l-86.65 64.61c-39.4 29.56-53.86 84.42-29.21 127.06C30.39 495.25 63.27 512 96.08 512c20.03 0 40.25-6.25 57.52-19.2l21.86-16.39c-29.85-55.38-13.54-125.84 39.2-165.4zM288 32c0-11.05 3.07-21.3 8.02-30.38C293.4.92 290.85 0 288 0H160c-17.67 0-32 14.33-32 32v32h160V32zM480 0H352c-17.67 0-32 14.33-32 32v32h192V32c0-17.67-14.33-32-32-32zM320 272l-86.13 64.61c-39.4 29.56-53.86 84.42-29.21 127.06 18.25 31.58 50.61 48.33 83.42 48.33 20.03 0 40.25-6.25 57.52-19.2l115.2-86.4A127.997 127.997 0 0 0 512 304V96H320v176z">
                            </path>
                        </svg>
                        <text>腳部高度</text>
                    </div>
                    <div class="item go_bk_b color_b">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-up"
                            class="svg-inline--fa fa-chevron-up fa-w-14" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 448 512">
                            <path class="color_b" fill="currentColor"
                                d="M240.971 130.524l194.343 194.343c9.373 9.373 9.373 24.569 0 33.941l-22.667 22.667c-9.357 9.357-24.522 9.375-33.901.04L224 227.495 69.255 381.516c-9.379 9.335-24.544 9.317-33.901-.04l-22.667-22.667c-9.373-9.373-9.373-24.569 0-33.941L207.03 130.525c9.372-9.373 24.568-9.373 33.941-.001z">
                            </path>
                        </svg>
                        <div class="go_bk bk_b"></div>
                    </div>
                    <div class="item go_bk_k color_b">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-down"
                            class="svg-inline--fa fa-chevron-down fa-w-14" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 448 512">
                            <path fill="currentColor"
                                d="M207.029 381.476L12.686 187.132c-9.373-9.373-9.373-24.569 0-33.941l22.667-22.667c9.357-9.357 24.522-9.375 33.901-.04L224 284.505l154.745-154.021c9.379-9.335 24.544-9.317 33.901.04l22.667 22.667c9.373 9.373 9.373 24.569 0 33.941L240.971 381.476c-9.373 9.372-24.569 9.372-33.942 0z">
                            </path>
                        </svg>
                        <div class="go_bk bk_k"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="item_hover item_hover_k"></div>
                    <div class="out">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="sign-out-alt"
                            class="svg-inline--fa fa-sign-out-alt fa-w-16" role="img" viewBox="0 0 512 512">
                            <path fill="currentColor"
                                d="M497 273L329 441c-15 15-41 4.5-41-17v-96H152c-13.3 0-24-10.7-24-24v-96c0-13.3 10.7-24 24-24h136V88c0-21.4 25.9-32 41-17l168 168c9.3 9.4 9.3 24.6 0 34zM192 436v-40c0-6.6-5.4-12-12-12H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h84c6.6 0 12-5.4 12-12V76c0-6.6-5.4-12-12-12H96c-53 0-96 43-96 96v192c0 53 43 96 96 96h84c6.6 0 12-5.4 12-12z">
                            </path>
                        </svg>
                    </div>
                </div>
            </div>
            <div class="msg">
                <div class="msg_box">
                    已呼叫醫護人員
                </div>
            </div>
    </form>

    <script src="jquery-3.4.1.min.js"></script>
    <script src="hb.js"></script>
</body>
</html>
