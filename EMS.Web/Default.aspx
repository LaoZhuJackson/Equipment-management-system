<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EMS.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.0/font/bootstrap-icons.css" />
    <link rel="stylesheet" href="./css/default.css" />
    <title>员工页面</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container_all">
            <!-- 导航栏 -->
            <div class="sidebar close">
                <div class="logo-details">
                    <i class="bi bi-piggy-bank-fill"></i>
                    <!-- <span> 用来组合行内元素，以便通过样式来格式化它们 -->
                    <span class="logo_name">Laozhu</span>
                </div>
                <ul class="nav-links">
                    <!-- 查询列 -->
                    <li>
                        <a href="#" id="search_link">
                            <i class="bi bi-send"></i>
                            <span class="link_name">Search</span>
                        </a>
                        <ul class="sub-menu blank">
                            <li><a class="link_name" href="#">Search</a></li>
                        </ul>
                    </li>
                    <!-- 修改密码列 -->
                    <li>
                        <a href="#" id="change_pwd_link">
                            <i class="bi bi-pencil-square"></i>
                            <span class="link_name">Change Password</span>
                        </a>
                        <ul class="sub-menu blank">
                            <li><a class="link_name" href="#">Change Password</a></li>
                        </ul>
                    </li>
                    <!-- 退出列 -->
                    <li>
                        <a href="./login2.aspx">
                            <i class="bi bi-box-arrow-right"></i>
                            <span class="link_name">Quit</span>
                        </a>
                        <ul class="sub-menu blank">
                            <li><a class="link_name" href="#">Quit</a></li>
                        </ul>
                    </li>
                    <!-- 头像列 -->
                    <li>
                        <div class="profile-details">
                            <div class="profile-content">
                                <!-- alt:替代文本 -->
                                <img src="images/laozhu.gif" alt="profile" />
                            </div>
                            <div class="name-job">
                                <div class="profile_name">Tink twice</div>
                                <div class="sub_name">Code once</div>
                            </div>
                            <i class="bi bi-brightness-high-fill"></i>
                        </div>
                    </li>
                </ul>
            </div>
            <!-- <section> 标签定义文档中的节（section、区段） -->
            <!-- 内容页面 -->
            <section class="home-section">
                <div class="home-content">
                    <i class="bi bi-list"></i>
                    <span class="text">员工页面</span>
                </div>
                <!-- 右上欢迎语，单独放出来是为了固定在右上角 -->
                <div class="welcome">
                    <asp:Label ID="welcome_label" runat="server" Text="欢迎你"></asp:Label>
                </div>
                <div class="select">
                    <div class="content" id="search_link_select">
                        <div class="operation">
                            <asp:DropDownList ID="select" runat="server" CssClass="drop_down_list">
                                <asp:ListItem Selected="True" Value="1">编号</asp:ListItem>
                                <asp:ListItem Value="2">设备名称</asp:ListItem>
                                <asp:ListItem Value="3">购入日期</asp:ListItem>
                                <asp:ListItem Value="4">存放位置</asp:ListItem>
                                <asp:ListItem Value="5">负责人名称</asp:ListItem>
                                <asp:ListItem Value="6">部门名称</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Corresponding data..."></asp:TextBox>
                            <asp:LinkButton ID="search" runat="server" CssClass="button" OnClick="search_Click"><i class="bi bi-search"></i>&nbsp Search</asp:LinkButton>
                        </div>
                        <div class="grid_background visible">
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                            <asp:Button ID="ok" runat="server" Text="Close" CssClass="button" OnClick="ok_Click" />
                        </div>
                    </div>
                    <div class="change_pwd" id="change_pwd_link_select" style="display: none;">
                        <div class="change_background">
                            <h2>Change Password</h2>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Old password..."></asp:TextBox>
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="New password..."></asp:TextBox>
                            <asp:TextBox ID="TextBox4" runat="server" placeholder="Confirm password..."></asp:TextBox>
                            <asp:Button ID="save" runat="server" Text="Save" CssClass="button" />
                        </div>
                    </div>
                </div>
            </section>
            <!-- 在 HTML 页面中插入一段 JavaScript -->
            <script>
                let arrow = document.querySelectorAll(".arrow");
                for (var i = 0; i < arrow.length; i++) {
                    // 用脚本实现点击展示下拉列表功能
                    arrow[i].addEventListener("click", (e) => {
                        // 定位到小三角的父类的父类（li）
                        let arrowParent = e.target.parentElement.parentElement;
                        //给刚才定位到的位置中的class添加showMenu
                        arrowParent.classList.toggle("showMenu");
                    })
                }
                // 选择sidebar类
                let sidebar = document.querySelector(".sidebar");
                let sidebarBtn = document.querySelector(".bi-list");
                console.log(sidebarBtn);
                // 菜单按钮添加点击事件
                sidebarBtn.addEventListener("click", () => {
                    sidebar.classList.toggle("close");
                })
            </script>
            <script src="https://apps.bdimg.com/libs/jquery/2.1.4/jquery.min.js"></script>
            <script src="./js/default.js"></script>
        </div>
    </form>
</body>
</html>
