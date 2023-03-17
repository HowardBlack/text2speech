<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ec.aspx.cs" Inherits="_1113_t2.ec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="preset.css" />
    <link rel="stylesheet" href="ec.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="center">
                <div class="row color_r">
                    <div class="item_hover item_hover_r"></div>
                    <div class="title color_r">
                        <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="lightbulb"
                            class="title_svg svg-inline--fa fa-lightbulb fa-w-11" role="img" viewBox="0 0 352 512">
                            <path class="color_r" fill="currentColor"
                                d="M176 80c-52.94 0-96 43.06-96 96 0 8.84 7.16 16 16 16s16-7.16 16-16c0-35.3 28.72-64 64-64 8.84 0 16-7.16 16-16s-7.16-16-16-16zM96.06 459.17c0 3.15.93 6.22 2.68 8.84l24.51 36.84c2.97 4.46 7.97 7.14 13.32 7.14h78.85c5.36 0 10.36-2.68 13.32-7.14l24.51-36.84c1.74-2.62 2.67-5.7 2.68-8.84l.05-43.18H96.02l.04 43.18zM176 0C73.72 0 0 82.97 0 176c0 44.37 16.45 84.85 43.56 115.78 16.64 18.99 42.74 58.8 52.42 92.16v.06h48v-.12c-.01-4.77-.72-9.51-2.15-14.07-5.59-17.81-22.82-64.77-62.17-109.67-20.54-23.43-31.52-53.15-31.61-84.14-.2-73.64 59.67-128 127.95-128 70.58 0 128 57.42 128 128 0 30.97-11.24 60.85-31.65 84.14-39.11 44.61-56.42 91.47-62.1 109.46a47.507 47.507 0 0 0-2.22 14.3v.1h48v-.05c9.68-33.37 35.78-73.18 52.42-92.16C335.55 260.85 352 220.37 352 176 352 78.8 273.2 0 176 0z">
                            </path>
                        </svg>
                        <text>電燈</text>
                    </div>

                    <div class="item go_bk_r color_r">

                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="sun" class="svg-inline--fa fa-sun fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                            <path class="color_r" fill="currentColor" d="M256 160c-52.9 0-96 43.1-96 96s43.1 96 96 96 96-43.1 96-96-43.1-96-96-96zm246.4 80.5l-94.7-47.3 33.5-100.4c4.5-13.6-8.4-26.5-21.9-21.9l-100.4 33.5-47.4-94.8c-6.4-12.8-24.6-12.8-31 0l-47.3 94.7L92.7 70.8c-13.6-4.5-26.5 8.4-21.9 21.9l33.5 100.4-94.7 47.4c-12.8 6.4-12.8 24.6 0 31l94.7 47.3-33.5 100.5c-4.5 13.6 8.4 26.5 21.9 21.9l100.4-33.5 47.3 94.7c6.4 12.8 24.6 12.8 31 0l47.3-94.7 100.4 33.5c13.6 4.5 26.5-8.4 21.9-21.9l-33.5-100.4 94.7-47.3c13-6.5 13-24.7.2-31.1zm-155.9 106c-49.9 49.9-131.1 49.9-181 0-49.9-49.9-49.9-131.1 0-181 49.9-49.9 131.1-49.9 181 0 49.9 49.9 49.9 131.1 0 181z"></path></svg>
                        <div class="go_bk bk_r"></div>
                    </div>
                    <div class="item go_bk_k color_r">

                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="moon" class="svg-inline--fa fa-moon fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                            <path fill="currentColor" d="M283.211 512c78.962 0 151.079-35.925 198.857-94.792 7.068-8.708-.639-21.43-11.562-19.35-124.203 23.654-238.262-71.576-238.262-196.954 0-72.222 38.662-138.635 101.498-174.394 9.686-5.512 7.25-20.197-3.756-22.23A258.156 258.156 0 0 0 283.211 0c-141.309 0-256 114.511-256 256 0 141.309 114.511 256 256 256z"></path></svg>
                        <div class="go_bk bk_k"></div>
                    </div>
                </div>
                <div class="row color_g">
                    <div class="item_hover item_hover_g"></div>
                    <div class="title color_g">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="person-booth"
                            class="title_svg svg-inline--fa fa-person-booth fa-w-18" role="img"
                            xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512">
                            <path class="color_g" fill="currentColor"
                                d="M192 496c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16V320h-64v176zm32-272h-50.9l-45.2-45.3C115.8 166.6 99.7 160 82.7 160H64c-17.1 0-33.2 6.7-45.3 18.8C6.7 190.9 0 207 0 224.1L.2 320 0 480c0 17.7 14.3 32 31.9 32 17.6 0 32-14.3 32-32l.1-100.7c.9.5 1.6 1.3 2.5 1.7l29.1 43v56c0 17.7 14.3 32 32 32s32-14.3 32-32v-56.5c0-9.9-2.3-19.8-6.7-28.6l-41.2-61.3V253l20.9 20.9c9.1 9.1 21.1 14.1 33.9 14.1H224c17.7 0 32-14.3 32-32s-14.3-32-32-32zM64 128c26.5 0 48-21.5 48-48S90.5 32 64 32 16 53.5 16 80s21.5 48 48 48zm224-96l31.5 223.1-30.9 154.6c-4.3 21.6 13 38.3 31.4 38.3 15.2 0 28-9.1 32.3-30.4.9 16.9 14.6 30.4 31.7 30.4 17.7 0 32-14.3 32-32 0 17.7 14.3 32 32 32s32-14.3 32-32V0H288v32zm-96 0v160h64V0h-32c-17.7 0-32 14.3-32 32zM544 0h-32v496c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16V32c0-17.7-14.3-32-32-32z">
                            </path>
                        </svg>
                        <text>拉簾</text>
                    </div>
                    <div class="item go_bk_g color_g">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-up"
                            class="svg-inline--fa fa-chevron-up fa-w-14" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 448 512">
                            <path class="color_g" fill="currentColor"
                                d="M240.971 130.524l194.343 194.343c9.373 9.373 9.373 24.569 0 33.941l-22.667 22.667c-9.357 9.357-24.522 9.375-33.901.04L224 227.495 69.255 381.516c-9.379 9.335-24.544 9.317-33.901-.04l-22.667-22.667c-9.373-9.373-9.373-24.569 0-33.941L207.03 130.525c9.372-9.373 24.568-9.373 33.941-.001z">
                            </path>
                        </svg>
                        <div class="go_bk bk_g"></div>
                    </div>
                    <div class="item go_bk_k color_g">
                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-down"
                            class="svg-inline--fa fa-chevron-down fa-w-14" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 448 512">
                            <path class="color_k" fill="currentColor"
                                d="M207.029 381.476L12.686 187.132c-9.373-9.373-9.373-24.569 0-33.941l22.667-22.667c9.357-9.357 24.522-9.375 33.901-.04L224 284.505l154.745-154.021c9.379-9.335 24.544-9.317 33.901.04l22.667 22.667c9.373 9.373 9.373 24.569 0 33.941L240.971 381.476c-9.373 9.372-24.569 9.372-33.942 0z">
                            </path>
                        </svg>
                        <div class="go_bk bk_k"></div>
                    </div>
                </div>
                <div class="row color_b">
                    <div class="item_hover item_hover_b"></div>
                    <div class="title color_b">

                        <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="snowflake"
                            class="title_svg svg-inline--fa fa-snowflake fa-w-14" role="img" xmlns="http://www.w3.org/2000/svg"
                            viewBox="0 0 448 512">
                            <path class="color_b" fill="currentColor"
                                d="M440.1 355.2l-39.2-23 34.1-9.3c8.4-2.3 13.4-11.1 11.1-19.6l-4.1-15.5c-2.2-8.5-10.9-13.6-19.3-11.3L343 298.2 271.2 256l71.9-42.2 79.7 21.7c8.4 2.3 17-2.8 19.3-11.3l4.1-15.5c2.2-8.5-2.7-17.3-11.1-19.6l-34.1-9.3 39.2-23c7.5-4.4 10.1-14.2 5.8-21.9l-7.9-13.9c-4.3-7.7-14-10.3-21.5-5.9l-39.2 23 9.1-34.7c2.2-8.5-2.7-17.3-11.1-19.6l-15.2-4.1c-8.4-2.3-17 2.8-19.3 11.3l-21.3 81-71.9 42.2v-84.5L306 70.4c6.1-6.2 6.1-16.4 0-22.6l-11.1-11.3c-6.1-6.2-16.1-6.2-22.2 0l-24.9 25.4V16c0-8.8-7-16-15.7-16h-15.7c-8.7 0-15.7 7.2-15.7 16v46.1l-24.9-25.4c-6.1-6.2-16.1-6.2-22.2 0L142.1 48c-6.1 6.2-6.1 16.4 0 22.6l58.3 59.3v84.5l-71.9-42.2-21.3-81c-2.2-8.5-10.9-13.6-19.3-11.3L72.7 84c-8.4 2.3-13.4 11.1-11.1 19.6l9.1 34.7-39.2-23c-7.5-4.4-17.1-1.8-21.5 5.9l-7.9 13.9c-4.3 7.7-1.8 17.4 5.8 21.9l39.2 23-34.1 9.1c-8.4 2.3-13.4 11.1-11.1 19.6L6 224.2c2.2 8.5 10.9 13.6 19.3 11.3l79.7-21.7 71.9 42.2-71.9 42.2-79.7-21.7c-8.4-2.3-17 2.8-19.3 11.3l-4.1 15.5c-2.2 8.5 2.7 17.3 11.1 19.6l34.1 9.3-39.2 23c-7.5 4.4-10.1 14.2-5.8 21.9L10 391c4.3 7.7 14 10.3 21.5 5.9l39.2-23-9.1 34.7c-2.2 8.5 2.7 17.3 11.1 19.6l15.2 4.1c8.4 2.3 17-2.8 19.3-11.3l21.3-81 71.9-42.2v84.5l-58.3 59.3c-6.1 6.2-6.1 16.4 0 22.6l11.1 11.3c6.1 6.2 16.1 6.2 22.2 0l24.9-25.4V496c0 8.8 7 16 15.7 16h15.7c8.7 0 15.7-7.2 15.7-16v-46.1l24.9 25.4c6.1 6.2 16.1 6.2 22.2 0l11.1-11.3c6.1-6.2 6.1-16.4 0-22.6l-58.3-59.3v-84.5l71.9 42.2 21.3 81c2.2 8.5 10.9 13.6 19.3 11.3L375 428c8.4-2.3 13.4-11.1 11.1-19.6l-9.1-34.7 39.2 23c7.5 4.4 17.1 1.8 21.5-5.9l7.9-13.9c4.6-7.5 2.1-17.3-5.5-21.7z">
                            </path>
                        </svg>
                        <text>空調</text>
                    </div>
                    <div class="item go_bk_b color_b">

                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="power-off" class="svg-inline--fa fa-power-off fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                            <path class="color_b" fill="currentColor" d="M400 54.1c63 45 104 118.6 104 201.9 0 136.8-110.8 247.7-247.5 248C120 504.3 8.2 393 8 256.4 7.9 173.1 48.9 99.3 111.8 54.2c11.7-8.3 28-4.8 35 7.7L162.6 90c5.9 10.5 3.1 23.8-6.6 31-41.5 30.8-68 79.6-68 134.9-.1 92.3 74.5 168.1 168 168.1 91.6 0 168.6-74.2 168-169.1-.3-51.8-24.7-101.8-68.1-134-9.7-7.2-12.4-20.5-6.5-30.9l15.8-28.1c7-12.4 23.2-16.1 34.8-7.8zM296 264V24c0-13.3-10.7-24-24-24h-32c-13.3 0-24 10.7-24 24v240c0 13.3 10.7 24 24 24h32c13.3 0 24-10.7 24-24z"></path>
                        </svg>
                        <div class="go_bk bk_b"></div>
                    </div>
                    <div class="item go_bk_k color_b">

                        <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="slash" class="svg-inline--fa fa-slash fa-w-20" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512">
                            <path fill="currentColor" d="M594.53 508.63L6.18 53.9c-6.97-5.42-8.23-15.47-2.81-22.45L23.01 6.18C28.43-.8 38.49-2.06 45.47 3.37L633.82 458.1c6.97 5.42 8.23 15.47 2.81 22.45l-19.64 25.27c-5.42 6.98-15.48 8.23-22.46 2.81z"></path>
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
    </form>
    <script src="jquery-3.4.1.min.js"></script>
    <script src="ec.js"></script>
</body>
</html>
