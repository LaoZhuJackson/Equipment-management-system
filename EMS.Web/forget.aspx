<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forget.aspx.cs" Inherits="EMS.Web.forget" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Forget</title>
    <link rel="stylesheet" href="./css/forget.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.0/font/bootstrap-icons.css" />
    <script type="text/javascript">
        function none_alert() {
            alert("所有选项不能为空ヽ(`Д´)ﾉ");
        }
        function name_not_exist_alert() {
            alert("用户名不存在┐(ﾟ～ﾟ)┌ ");
        }
        function phone_error() {
            alert("电话号码错误(●—●)");
        }
        function password_message(password) {
            alert('你的密码是："' + password + '" ᕦ(･ㅂ･)ᕤ别再忘了哦~');
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="form">
            <div class="form_sub">
                <h2>Retrieve password</h2>
                <asp:TextBox ID="username_forget" runat="server" placeholder="Username..."></asp:TextBox>
                <asp:TextBox ID="phone_forget" runat="server" placeholder="Phone..."></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Retrieve"  CssClass="button" OnClick="Button1_Click" />
                <a href="login2.aspx" class="social">Return to login<i class="bi bi-arrow-bar-right"></i></a>
            </div>
        </div>
    </form>
</body>
</html>
