<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EMS.Web.admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.0/font/bootstrap-icons.css" />
    <link rel="stylesheet" href="../css/default.css" />
    <title>管理员页面</title>
    <script type="text/javascript">
        function please_login() {
            alert('还未登录，请登录~(￣▽￣)~*');
            window.location.href = '../login2.aspx';
        }
        function alert_message(text) {
            alert(text);
        }
        //进行页面定位
        function search_page(page_num) {
            if (page_num == "1") {
                var page = document.getElementById('search_equip_link_select');
            }
            else if (page_num == "2") {
                var page = document.getElementById('search_dept_link_select');
            }
            else if (page_num == "3") {
                var page = document.getElementById('search_emp_link_select');
            }
            else if (page_num == "4") {
                var page = document.getElementById('change_pwd_link_select');
            }
            else if (page_num == "5") {
                var page = document.getElementById('add_equip_link_select');
            }
            else if (page_num == "6") {
                var page = document.getElementById('add_dept_link_select');
            }
            else {
                var page = document.getElementById('add_emp_link_select');
            }
            var $now_page = $(page);
            $now_page.siblings('div').hide();
            $now_page.show();
        }
    </script>
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
                        <div class="iocn-link">
                            <a href="#" id="search">
                                <i class="bi bi-send"></i>
                                <span class="link_name">Search</span>
                            </a>
                            <!-- 下拉按钮 -->
                            <i class="bi bi-caret-down arrow"></i>
                        </div>
                        <ul class="sub-menu">
                            <li><a class="link_name" href="#">Search</a></li>
                            <li><a href="#" id="search_equip_link">Search Equipment</a></li>
                            <li><a href="#" id="search_dept_link">Search Department</a></li>
                            <li><a href="#" id="search_emp_link">Search Employee</a></li>
                        </ul>
                    </li>
                    <!-- 插入列 -->
                    <li>
                        <div class="iocn-link">
                            <a href="#" id="add">
                                <i class="bi bi-plus-square"></i>
                                <span class="link_name">Add</span>
                            </a>
                            <!-- 下拉按钮 -->
                            <i class="bi bi-caret-down arrow"></i>
                        </div>
                        <ul class="sub-menu">
                            <li><a class="link_name" href="#">Add</a></li>
                            <li><a href="#" id="add_equip_link">Add Equipment</a></li>
                            <li><a href="#" id="add_dept_link">Add Department</a></li>
                            <li><a href="#" id="add_emp_link">Add Employee</a></li>
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
                        <%--通过linkbutton实现退出session清除--%>
                        <asp:LinkButton ID="quit_button" runat="server" OnClick="quit_button_Click"><i class="bi bi-box-arrow-right"></i><span class="link_name">Quit</span></asp:LinkButton>
                        <ul class="sub-menu blank">
                            <li><a class="link_name" href="#">Quit</a></li>
                        </ul>
                    </li>
                    <!-- 头像列 -->
                    <li>
                        <div class="profile-details">
                            <div class="profile-content">
                                <!-- alt:替代文本 -->
                                <img src="../images/laozhu.gif" alt="profile" />
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
                    <span class="text">管理员页面</span>
                </div>
                <!-- 右上欢迎语，单独放出来是为了固定在右上角 -->
                <div class="welcome">
                    <asp:Label ID="welcome_label" runat="server" Text="欢迎你"></asp:Label>
                    <asp:LinkButton ID="login" runat="server" CssClass="button" Visible="True">登录</asp:LinkButton>
                </div>
                <div class="select">
                    <div class="content" id="search_equip_link_select">
                        <div class="operation">
                            <asp:DropDownList ID="select_drop_down_list" runat="server" CssClass="drop_down_list">
                                <asp:ListItem Selected="True" Value="1">设备编号</asp:ListItem>
                                <asp:ListItem Value="2">设备名称</asp:ListItem>
                                <asp:ListItem Value="3">设备规格</asp:ListItem>
                                <asp:ListItem Value="4">购入日期</asp:ListItem>
                                <asp:ListItem Value="5">存放位置</asp:ListItem>
                                <asp:ListItem Value="6">负责人编号</asp:ListItem>
                                <asp:ListItem Value="7">部门名称</asp:ListItem>
                                <asp:ListItem Value="8">全部设备</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="data_text" runat="server" placeholder="Corresponding data..."></asp:TextBox>
                            <asp:LinkButton ID="search_btn" runat="server" CssClass="button" OnClick="search_Click"><i class="bi bi-search"></i>&nbsp Search</asp:LinkButton>
                        </div>
                        <div class="admin_result">
                            <div class="grid_background visible">
                                <asp:GridView ID="result_grid" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:ImageField DataImageUrlField="picture_path" HeaderText="images">
                                        </asp:ImageField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                                <asp:Button ID="ok" runat="server" Text="Close" CssClass="button" OnClick="ok_Click" />
                            </div>
                            <div class="admin">
                                <div class="change">
                                    <div class="input_area">
                                        <h3>修改数据</h3>
                                        <asp:TextBox ID="change_data_id_equip" runat="server" placeholder="select id"></asp:TextBox>
                                        <asp:DropDownList ID="select_item_dropdownlist_equip" runat="server">
                                            <asp:ListItem Selected="True" Value="1">设备名称</asp:ListItem>
                                            <asp:ListItem Value="2">设备规格</asp:ListItem>
                                            <asp:ListItem Value="3">购入价格</asp:ListItem>
                                            <asp:ListItem Value="4">购入日期</asp:ListItem>
                                            <asp:ListItem Value="5">存放位置</asp:ListItem>
                                            <asp:ListItem Value="6">负责人编号</asp:ListItem>
                                            <asp:ListItem Value="7">图片</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="data_change_text_equip" runat="server" placeholder="Modified value"></asp:TextBox>
                                        <asp:FileUpload ID="FileUpload2" runat="server" Visible="False" />
                                    </div>
                                    <asp:Button ID="change_equip_btn" runat="server" Text="change" CssClass="button" OnClick="change_equip_btn_click" />
                                </div>
                                <div class="delete">
                                    <div class="input_area">
                                        <h3>删除数据</h3>
                                        <asp:TextBox ID="delete_id_text_equip" runat="server" placeholder="select id"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="delete_equip_btn" runat="server" Text="delete" CssClass="button" OnClick="delete_equip_btn_click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="content" id="search_dept_link_select" style="display: none;">
                        <div class="operation">
                            <asp:DropDownList ID="DropDownList_dept" runat="server" CssClass="drop_down_list">
                                <asp:ListItem Selected="True" Value="1">部门编号</asp:ListItem>
                                <asp:ListItem Value="2">部门名称</asp:ListItem>
                                <asp:ListItem Value="3">负责人编号</asp:ListItem>
                                <asp:ListItem Value="4">全部部门</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBox_dept" runat="server" placeholder="Corresponding data..."></asp:TextBox>
                            <asp:LinkButton ID="LinkButton_dept" runat="server" CssClass="button" OnClick="search_Click_dept"><i class="bi bi-search"></i>&nbsp Search</asp:LinkButton>
                        </div>
                        <div class="admin_result">
                            <div class="grid_background visible">
                                <asp:GridView ID="GridView_dept" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                                <asp:Button ID="Button_dept" runat="server" Text="Close" CssClass="button" OnClick="ok_Click_dept" />
                            </div>
                            <div class="admin">
                                <div class="change">
                                    <div class="input_area">
                                        <h3>修改数据</h3>
                                        <asp:TextBox ID="change_data_id_dept" runat="server" placeholder="select id"></asp:TextBox>
                                        <asp:DropDownList ID="select_item_dropdownlist_dept" runat="server">
                                            <asp:ListItem Selected="True" Value="1">部门名称</asp:ListItem>
                                            <asp:ListItem Value="2">负责人编号</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="data_change_text_dept" runat="server" placeholder="Modified value"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="change_dept_btn" runat="server" Text="change" CssClass="button" OnClick="change_dept_btn_click" />
                                </div>
                                <div class="delete">
                                    <div class="input_area">
                                        <h3>删除数据</h3>
                                        <asp:TextBox ID="delete_id_text_dept" runat="server" placeholder="select id"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="delete_dept_btn" runat="server" Text="delete" CssClass="button" OnClick="delete_dept_btn_click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="content" id="search_emp_link_select" style="display: none;">
                        <div class="operation">
                            <asp:DropDownList ID="DropDownList_emp" runat="server" CssClass="drop_down_list">
                                <asp:ListItem Selected="True" Value="1">人员编号</asp:ListItem>
                                <asp:ListItem Value="2">姓名</asp:ListItem>
                                <asp:ListItem Value="3">部门名称</asp:ListItem>
                                <asp:ListItem Value="4">全部人员</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBox_emp" runat="server" placeholder="Corresponding data..."></asp:TextBox>
                            <asp:LinkButton ID="LinkButton_emp" runat="server" CssClass="button" OnClick="search_Click_emp"><i class="bi bi-search"></i>&nbsp Search</asp:LinkButton>
                        </div>
                        <div class="admin_result">
                            <div class="grid_background visible">
                                <asp:GridView ID="GridView_emp" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                                <asp:Button ID="Button_emp" runat="server" Text="Close" CssClass="button" OnClick="ok_Click_emp" />
                            </div>
                            <div class="admin">
                                <div class="change">
                                    <div class="input_area">
                                        <h3>修改数据</h3>
                                        <asp:TextBox ID="change_data_id_emp" runat="server" placeholder="select id"></asp:TextBox>
                                        <asp:DropDownList ID="select_item_dropdownlist_emp" runat="server">
                                            <asp:ListItem Selected="True" Value="1">姓名</asp:ListItem>
                                            <asp:ListItem Value="2">密码</asp:ListItem>
                                            <asp:ListItem Value="3">电话</asp:ListItem>
                                            <asp:ListItem Value="4">管理员权限</asp:ListItem>
                                            <asp:ListItem Value="5">部门名称</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="data_change_text_emp" runat="server" placeholder="Modified value"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="change_emp_btn" runat="server" Text="change" CssClass="button" OnClick="change_emp_btn_click" />
                                </div>
                                <div class="delete">
                                    <div class="input_area">
                                        <h3>删除数据</h3>
                                        <asp:TextBox ID="delete_id_text_emp" runat="server" placeholder="select id"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="delete_emp_btn" runat="server" Text="delete" CssClass="button" OnClick="delete_emp_btn_click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="change_pwd" id="change_pwd_link_select" style="display: none;">
                        <div class="change_background">
                            <h2>Change Password</h2>
                            <asp:TextBox ID="oldpwd_text" runat="server" placeholder="Old password..."></asp:TextBox>
                            <asp:TextBox ID="newpwd_text" runat="server" placeholder="New password..." TextMode="Password"></asp:TextBox>
                            <asp:TextBox ID="confirmpwd_text" runat="server" placeholder="Confirm password..." TextMode="Password"></asp:TextBox>
                            <asp:Button ID="save" runat="server" Text="Save" CssClass="button" OnClick="save_click" />
                        </div>
                    </div>
                    <div class="add_content" id="add_equip_link_select" style="display: none;">
                        <div class="add_area">
                            <h2>添加设备</h2>
                            <div class="input_add">
                                <asp:TextBox ID="equip_name_text" runat="server" placeholder="name"></asp:TextBox>
                                <asp:TextBox ID="equip_spec_text" runat="server" placeholder="specification"></asp:TextBox>
                                <asp:TextBox ID="equip_price_text" runat="server" placeholder="price"></asp:TextBox>
                                <asp:TextBox ID="equip_date_text" runat="server" placeholder="date"></asp:TextBox>
                                <asp:TextBox ID="equip_location_text" runat="server" placeholder="location"></asp:TextBox>
                                <asp:TextBox ID="equip_person_id_text" runat="server" placeholder="person id"></asp:TextBox>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                            <asp:Button ID="add_equip_btn" runat="server" Text="submit" CssClass="button" OnClick="add_equip_btn_click" />
                        </div>
                    </div>
                    <div class="add_content" id="add_dept_link_select" style="display: none;">
                        <div class="add_area">
                            <h2>添加部门</h2>
                            <div class="input_add">
                                <asp:TextBox ID="dept_name_text" runat="server" placeholder="name"></asp:TextBox>
                                <asp:TextBox ID="dept_person_id_text" runat="server" placeholder="person id"></asp:TextBox>
                            </div>
                            <asp:Button ID="add_dept_btn" runat="server" Text="submit" CssClass="button" OnClick="add_dept_btn_click" />
                        </div>
                    </div>
                    <div class="add_content" id="add_emp_link_select" style="display: none;">
                        <div class="add_area">
                            <h2>添加人员</h2>
                            <div class="input_add">
                                <asp:TextBox ID="emp_name_text" runat="server" placeholder="name"></asp:TextBox>
                                <asp:TextBox ID="emp_password_text" runat="server" placeholder="password"></asp:TextBox>
                                <asp:TextBox ID="emp_phone_text" runat="server" placeholder="phone" TextMode="Phone"></asp:TextBox>
                                <asp:DropDownList ID="is_admin_emp_dropdownlist" runat="server" CssClass="drop_down_list">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="2">否</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="emp_dept_text" runat="server" placeholder="department"></asp:TextBox>
                            </div>
                            <asp:Button ID="add_emp_btn" runat="server" Text="submit" CssClass="button" OnClick="add_emp_btn_click" />
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
            <script src="../js/default.js"></script>
        </div>
    </form>
</body>
</html>
