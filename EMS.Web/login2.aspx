<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="EMS.Web.login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录页面</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.0/font/bootstrap-icons.css" />
    <link rel="stylesheet" href="~/css/login2.css" />
    <script type="text/javascript">
        function alert_message(text) {
            alert(text);
        }
        function sign_up() {
            container = document.getElementsByClassName('container')[0];
            container.classList.add('active');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 创建容器 -->
        <div class="container">
            <!-- 注册页面 -->
            <div class="form-container sign-up-container">
                <div class="form">
                    <h2>Sign up</h2>
                    <div class="social-container">
                        <a href="#" class="social"><i class="bi bi-chat-left-dots-fill"></i></a>
                        <a href="#" class="social"><i class="bi bi-cup-fill"></i></a>
                        <a href="#" class="social"><i class="bi bi-box-arrow-up-right"></i></a>
                    </div>
                    <asp:TextBox ID="username_up" runat="server" placeholder="Username..." CssClass="input"></asp:TextBox>
                    <asp:TextBox ID="phone_up" runat="server" TextMode="Phone" placeholder="Phone..." CssClass="input"></asp:TextBox>
                    <asp:TextBox ID="password_up" runat="server" placeholder="Password..." CssClass="input" TextMode="Password"></asp:TextBox>
                    <asp:TextBox ID="confirm_password_up" runat="server" placeholder="Confirm Password..." CssClass="input" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="sign_up_btn" runat="server" Text="Sign Up" CssClass="button" OnClick="sign_up_btn_Click" />
                </div>
            </div>
            <!-- 登录页面 -->
            <div class="form-container sign-in-container">
                <div class="form">
                    <h2>Sign in</h2>
                    <div class="social-container">
                        <a href="#" class="social"><i class="bi bi-chat-left-dots-fill"></i></a>
                        <a href="#" class="social"><i class="bi bi-cup-fill"></i></a>
                        <a href="#" class="social"><i class="bi bi-box-arrow-up-right"></i></a>
                    </div>
                    <asp:TextBox ID="username_in" runat="server" placeholder="Username..." CssClass="input"></asp:TextBox>
                    <asp:TextBox ID="password_in" runat="server" placeholder="Password..." CssClass="input" TextMode="Password"></asp:TextBox>
                    <a href="forget.aspx" class="forget">forget your password</a>
                    <asp:Button ID="sign_in_btn" runat="server" Text="Sign In" CssClass="button" OnClick="sign_in_btn_Click" />
                </div>
            </div>
            <!-- 覆盖容器 -->
            <div class="overlay-container">
                <div class="overlay">
                    <!-- 右边 -->
                    <div class="overlay-panel overlay-right-container">
                        <h2>Welcome back!</h2>
                        <p>To keey connected with us please login with your personal info</p>
                        <asp:Button ID="sign_in" runat="server" Text="sign in" CssClass="button" UseSubmitBehavior="False" OnClientClick="return false;" />
                    </div>
                    <!-- 左边 -->
                    <div class="overlay-panel overlay-left-container">
                        <h2>Hello Friend!</h2>
                        <p>Enter your personal details and start journey with us</p>
                        <asp:Button ID="sign_up" runat="server" Text="sign up" CssClass="button" UseSubmitBehavior="False" OnClientClick="return false;" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="./js/login.js"></script>
</body>
</html>
