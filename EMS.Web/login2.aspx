<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="EMS.Web.login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.0/font/bootstrap-icons.css" />
    <link rel="stylesheet" href="~/css/login2.css" />
    <script type="text/javascript">
        function sign_in_alert() {
            alert('账号或密码错误！');
        }
        function none_alert() {
            alert("所有选项不能为空！");
        }
        function name_exist_alert() {
            alert("用户名已存在！");
        }
        function password_alert() {
            alert("两次密码输入不相同！");
        }
        function successful_message() {
            alert("注册成功！");
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
            <asp:TextBox ID="username_up" runat="server" Text="Username..." CssClass="input"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Text="*" CssClass="validator" ControlToValidate="username_up">*</asp:RequiredFieldValidator>--%>
            <asp:TextBox ID="phone_up" runat="server" TextMode="Phone" Text="Phone..." CssClass="input"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" CssClass="validator" Text="*" ControlToValidate="phone_up">*</asp:RequiredFieldValidator>--%>
            <asp:TextBox ID="password_up" runat="server" Text="Password..." CssClass="input" TextMode="Password"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="password_up" CssClass="validator">*</asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="confirm_password_up" runat="server" Text="Confirm Password..." CssClass="input" TextMode="Password"></asp:TextBox>
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
                <asp:TextBox ID="username_in" runat="server" Text="Username..." CssClass="input" ></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="username_in" CssClass="validator">*</asp:RequiredFieldValidator>--%>
            <asp:TextBox ID="password_in" runat="server" Text="Password..." CssClass="input" TextMode="Password"></asp:TextBox>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="password_in" CssClass="validator" ForeColor="White">*</asp:RequiredFieldValidator>--%>
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
    <script type="text/javascript" src="../js/login.js"></script>
</body>
</html>
