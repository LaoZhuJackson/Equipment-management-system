<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EMS.Web.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="~/css/login.css" rel="stylesheet" type="text/css" />
<title>login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="login-box">
                <h1>登录</h1>
                <div class="output-frame">
                    <asp:Label ID="username" runat="server" Text="账号"></asp:Label>
                    <asp:TextBox ID="username_box" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username_box" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="validator" Font-Bold="True" Font-Size="XX-Large">*</asp:RequiredFieldValidator>
                </div>
                <div class="output-frame">
                    <asp:Label ID="password" runat="server" Text="密码"></asp:Label>
                    <asp:TextBox ID="password_box" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password_box" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="validator" Font-Bold="True" Font-Size="XX-Large">*</asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblMsg" runat="server" Text=" "></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="登录" class="login-btn" OnClick="Button1_Click" />
                <div class="help">
                    <a href="newUser.aspx">我要注册</a>
                    <a href="forget.aspx">忘记密码</a>
                </div>
            </div>
        </div>
    </form>
<%--    <script type="text/javascript">
        function checkUserName() {
            var fname = document.myform.username_box.value;
            if (fname == "") {
                alert("用户名不能为空！");
                return false;
            }
            return true;
        }
        function checkPassword() {
            var userpass = document.myform.password_box.value;
            if (userpass == "") {
                alert("密码不能为空！");
                return false;
            }
            return true;
        }
        function validateform() {
            if (checkUserName() && checkPassword())
                return true;
            else
                return false;
        }
    </script>--%>
</body>
</html>
