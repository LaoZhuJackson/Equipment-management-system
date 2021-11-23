using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.BLL;

namespace EMS.Web.admin
{
    public partial class Default : System.Web.UI.Page
    {
        default_method method = new default_method();
        VisiterService visiterService = new VisiterService();
        String message = "";
        //进行登录验证
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["AdminId"] != null || Session["AdminName"] != null)//用户已登录
            //{
            //    //初始化页面
            //    if (Session["login_count_admin"].ToString() == "first")//如果是第一次登录
            //    {
            //        Session["login_count_admin"] = "not_first";
            //        message = "登录成功(ﾉﾟ▽ﾟ)ﾉ";
            //        ClientScript.RegisterStartupScript(this.GetType(), "login_success", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            //    }
            //    welcome_label.Text = Session["AdminName"] + "管理员，欢迎你";
            //    login.Visible = false;
            //}
            //else//用户未登录
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "login_message", "<script type='text/javascript'>please_login();</script>");
            //    login.Visible = true;
            //}
        }
        /// <summary>
        /// 进行页面定位
        /// </summary>
        /// <param name="page_num"></param>
        public void page_select(String page_num)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "page_select", "<script type='text/javascript'>search_page('" + page_num + "');</script>");
        }
        /// <summary>
        /// 设备查询部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void search_Click(object sender, EventArgs e)
        {
            if (visiterService.is_none(data_text.Text.Trim()))//如果是空值
            {
                message = "查到一只兰陵王┐(￣ー￣)┌";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else//不为空值
            {
                //根据下拉列表进行判断查询
                String value = select_drop_down_list.SelectedValue;
                switch (value)
                {
                    //按编号查询
                    case "1":
                        if (method.isNum(data_text.Text.Trim()))
                        {
                            result_grid.DataSource = method.Search_ById(Convert.ToInt32(data_text.Text.Trim()));
                            //绑定数据
                            result_grid.DataBind();
                        }
                        else
                        {
                            message = "请输入数字编号(╬￣皿￣)";
                            ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                        }
                        break;
                    //按设备名称查询
                    case "2":
                        result_grid.DataSource = method.Search_ByName(data_text.Text.Trim());
                        result_grid.DataBind();
                        break;
                    //按设备规格查询
                    case "3":
                        result_grid.DataSource = method.Search_BySpec(data_text.Text.Trim());
                        result_grid.DataBind();
                        break;
                    //按购入日期（年）查询
                    case "4":
                        if (method.isNum(data_text.Text.Trim()))
                        {
                            result_grid.DataSource = method.Search_ByDate(data_text.Text.Trim());
                            result_grid.DataBind();
                        }
                        else
                        {
                            message = "请输入数字日期(╬￣皿￣)";
                            ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                        }
                        break;
                    //按存放位置查询
                    case "5":
                        result_grid.DataSource = method.Search_ByLocation(data_text.Text.Trim());
                        result_grid.DataBind();
                        break;
                    //按设备负责人编号查询
                    case "6":
                        if (method.isNum(data_text.Text.Trim()))
                        {
                            result_grid.DataSource = method.Search_ByPerson_Id(Convert.ToInt32(data_text.Text.Trim()));
                            //绑定数据
                            result_grid.DataBind();
                        }
                        else
                        {
                            message = "请输入数字编号(╬￣皿￣)";
                            ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                        }
                        break;
                        //TODO
                }
                //显示表格
                result_grid.Visible = true;
            }
            page_select("1");
        }
        //单击close按钮
        protected void ok_Click(object sender, EventArgs e)
        {
            page_select("1");
            result_grid.Visible = false;
        }
        /// <summary>
        /// 部门查询部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void search_Click_dept(object sender, EventArgs e)
        {
            if (visiterService.is_none(TextBox_dept.Text.Trim()))
            {
                message = "查到一只兰陵王┐(￣ー￣)┌";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else
            {
                String value = DropDownList_dept.SelectedValue;
                switch (value)
                {
                    //部门编号
                    case "1":
                        if (method.isNum(TextBox_dept.Text.Trim()))
                        {
                            GridView_dept.DataSource = method.Search_ById_dept(Convert.ToInt32(TextBox_dept.Text.Trim()));
                            //绑定数据
                            GridView_dept.DataBind();
                        }
                        else
                        {
                            message = "请输入数字编号(╬￣皿￣)";
                            ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                        }
                        break;
                    //部门名称
                    case "2":
                        GridView_dept.DataSource = method.Search_ByName_dept(TextBox_dept.Text.Trim());
                        GridView_dept.DataBind();
                        break;
                    //负责人名称
                    case "3":
                        GridView_dept.DataSource = method.Search_ByPerson_dept(Convert.ToInt32(TextBox_dept.Text.Trim()));
                        GridView_dept.DataBind();
                        break;
                }
                //显示表格
                GridView_dept.Visible = true;
            }
            page_select("2");
        }
        protected void ok_Click_dept(object sender, EventArgs e)
        {
            page_select("2");
            GridView_dept.Visible = false;
        }
        /// <summary>
        /// 人员查询部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void search_Click_emp(object sender, EventArgs e)
        {
            if (visiterService.is_none(TextBox_emp.Text.Trim()))
            {
                message = "查到一只兰陵王┐(￣ー￣)┌";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else
            {
                String value = DropDownList_emp.SelectedValue;
                switch (value)
                {
                    //人员编号
                    case "1":
                        if (method.isNum(TextBox_emp.Text.Trim()))
                        {
                            GridView_emp.DataSource = method.Search_ById_emp(Convert.ToInt32(TextBox_emp.Text.Trim()));
                            //绑定数据
                            GridView_emp.DataBind();
                        }
                        else
                        {
                            message = "请输入数字编号(╬￣皿￣)";
                            ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                        }
                        break;
                    //姓名
                    case "2":
                        GridView_emp.DataSource = method.Search_ByName_emp(TextBox_emp.Text.Trim());
                        GridView_emp.DataBind();
                        break;
                    //部门名称
                    case "3":
                        GridView_emp.DataSource = method.Search_ByDept_emp(TextBox_emp.Text.Trim());
                        GridView_emp.DataBind();
                        break;
                }
                GridView_emp.Visible = true;
            }
            page_select("3");
        }
        protected void ok_Click_emp(object sender, EventArgs e)
        {
            page_select("3");
            GridView_emp.Visible = false;
        }
        //对登出进行session清除
        protected void quit_button_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../login2.aspx");
        }
        //修改页面保存
        protected void save_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(oldpwd_text.Text.Trim()) || visiterService.is_none(newpwd_text.Text.Trim()) || visiterService.is_none(confirmpwd_text.Text.Trim()))
            {
                message = "请输入完整(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else//没有空值
            {
                if (visiterService.confirm_password(newpwd_text.Text.Trim(), confirmpwd_text.Text.Trim()))//进行两次的密码判断
                {
                    //获取id
                    int id = Convert.ToInt32(Session["VisiterId"]);
                    if (method.ChangePassword(id, oldpwd_text.Text.Trim(), newpwd_text.Text.Trim()))//修改成功
                    {
                        message = "修改成功٩(๑>◡<๑)۶";
                        ClientScript.RegisterStartupScript(this.GetType(), "change_success", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                    else//验证身份出错
                    {
                        message = "旧密码错误┐(´∀｀)┌";
                        ClientScript.RegisterStartupScript(this.GetType(), "confirm_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                }
                else
                {
                    message = "两次密码输入不相同(｡・`ω´･) ";
                    ClientScript.RegisterStartupScript(this.GetType(), "different_pwd", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    confirmpwd_text.Text = "";
                }
            }
            //页面定位
            page_select("4");
        }
        protected void add_equip_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(equip_name_text.Text.Trim()) || visiterService.is_none(equip_spec_text.Text.Trim()) || visiterService.is_none(equip_price_text.Text.Trim()) || visiterService.is_none(equip_date_text.Text.Trim()) || visiterService.is_none(equip_location_text.Text.Trim()) || visiterService.is_none(equip_person_id_text.Text.Trim()) || visiterService.is_none(equip_image_text.Text.Trim()))
            {
                message = "请输入完整(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else//不为空
            {
                if (method.isNum(equip_price_text.Text.Trim()) || method.isNum(equip_person_id_text.Text.Trim()))
                {
                    //转换格式
                    int price = Convert.ToInt32(equip_price_text.Text.Trim());
                    DateTime date = Convert.ToDateTime(equip_date_text.Text.Trim());
                    int id = Convert.ToInt32(equip_person_id_text.Text.Trim());
                    //调用方法
                    method.Insert(equip_name_text.Text.Trim(), equip_spec_text.Text.Trim(), price, date, equip_location_text.Text.Trim(), id, equip_image_text.Text.Trim());
                }
                else//数字格式错误
                {
                    message = "请输入数字价格或编号(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            //页面定位
            page_select("5");
        }

        protected void add_dept_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(dept_name_text.Text.Trim()) || visiterService.is_none(dept_person_id_text.Text.Trim()))
            {
                message = "请输入完整(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else
            {
                if (method.isNum(dept_person_id_text.Text.Trim()))//数字格式正确
                {
                    method.Insert(dept_name_text.Text.Trim(), Convert.ToInt32(dept_person_id_text.Text.Trim()));
                }
                else
                {
                    message = "请输入数字编号(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            //页面定位
            page_select("6");
        }
        protected void add_emp_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(emp_name_text.Text.Trim()) || visiterService.is_none(emp_password_text.Text.Trim()) || visiterService.is_none(emp_phone_text.Text.Trim()) || visiterService.is_none(emp_dept_text.Text.Trim()))
            {
                message = "请输入完整(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else
            {
                if (method.isNum(emp_phone_text.Text.Trim()))
                {
                    bool is_admin = true;
                    string str = is_admin_emp_dropdownlist.SelectedValue;
                    switch (str)
                    {
                        case "1"://是管理员
                            method.Insert(emp_name_text.Text.Trim(), emp_password_text.Text.Trim(), emp_phone_text.Text.Trim(), is_admin, emp_dept_text.Text.Trim());
                            break;
                        case "2"://不是管理员
                            is_admin = false;
                            method.Insert(emp_name_text.Text.Trim(), emp_password_text.Text.Trim(), emp_phone_text.Text.Trim(), is_admin, emp_dept_text.Text.Trim());
                            break;
                    }
                }
                else
                {
                    message = "请输入数字电话(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            //页面定位
            page_select("7");
        }
        /// <summary>
        /// 设备的管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void change_equip_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(data_change_text_equip.Text.Trim()) || visiterService.is_none(change_data_id_equip.Text.Trim()))
            {
                message = "请输入完整(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else//不为空值
            {
                if (method.isNum(change_data_id_equip.Text.Trim()))
                {
                    string value = select_item_dropdownlist_equip.SelectedValue;
                    int id = Convert.ToInt32(change_data_id_equip.Text.Trim());
                    switch (value)
                    {
                        case "1":
                            if (method.equip_change_name(id, data_change_text_equip.Text.Trim()))
                            {
                                message = "修改成功(๑╹◡╹)ﾉ";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            else
                            {
                                message = "未查询到该编号数据╮(・o・)╭";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "2":
                            if (method.equip_change_spec(id, data_change_text_equip.Text.Trim()))
                            {
                                message = "修改成功(๑╹◡╹)ﾉ";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            else
                            {
                                message = "未查询到该编号数据╮(・o・)╭";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "3":
                            if (method.isNum(data_change_text_equip.Text.Trim()))
                            {
                                if (method.equip_change_price(id, Convert.ToInt32(data_change_text_equip.Text.Trim())))
                                {
                                    message = "修改成功(๑╹◡╹)ﾉ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                                else
                                {
                                    message = "未查询到该编号数据╮(・o・)╭";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                            }
                            else//输入的不是数字
                            {
                                message = "请输入数字价格(╬￣皿￣)";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "4":
                            if (method.isDate(data_change_text_equip.Text.Trim()))
                            {
                                if (method.equip_change_date(id, Convert.ToDateTime(data_change_text_equip.Text.Trim())))
                                {
                                    message = "修改成功(๑╹◡╹)ﾉ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                                else
                                {
                                    message = "未查询到该编号数据╮(・o・)╭";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                            }
                            else//日期格式转换失败
                            {
                                message = "请按日期格式输入(╬￣皿￣)";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "5":
                            if (method.equip_change_location(id, data_change_text_equip.Text.Trim()))
                            {
                                message = "修改成功(๑╹◡╹)ﾉ";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            else
                            {
                                message = "未查询到该编号数据╮(・o・)╭";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "6":
                            if (method.isNum(data_change_text_equip.Text.Trim()))
                            {
                                if (method.equip_change_personId(id, Convert.ToInt32(data_change_text_equip.Text.Trim())))
                                {
                                    message = "修改成功(๑╹◡╹)ﾉ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                                else
                                {
                                    message = "未查询到该编号数据╮(・o・)╭";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                            }
                            else//输入的不是数字
                            {
                                message = "请输入数字编号(╬￣皿￣)";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "7":
                            if (method.equip_change_image(id, data_change_text_equip.Text.Trim()))
                            {
                                message = "修改成功(๑╹◡╹)ﾉ";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            else
                            {
                                message = "未查询到该编号数据╮(・o・)╭";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                    }
                }
                else//id不是数字
                {
                    message = "要修改的编号只能是数字(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            page_select("1");
        }

        protected void delete_equip_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(delete_id_text_equip.Text.Trim()))
            {
                message = "请输入要删除的编号(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else
            {
                if (method.isNum(delete_id_text_equip.Text.Trim()))
                {
                    int id = Convert.ToInt32(delete_id_text_equip.Text.Trim());
                    if (method.equip_delete(id))
                    {
                        message = "删除成功(๑╹◡╹)ﾉ";
                        ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                    else
                    {
                        message = "未查询到该编号数据╮(・o・)╭";
                        ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                }
                else
                {
                    message = "要删除的编号只能是数字(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            page_select("1");
        }
        /// <summary>
        /// 部门的管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void change_dept_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(data_change_text_dept.Text.Trim()) || visiterService.is_none(change_data_id_dept.Text.Trim()))
            {
                message = "请输入完整(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else//不为空值
            {
                if (method.isNum(change_data_id_dept.Text.Trim()))
                {
                    string value = select_item_dropdownlist_dept.SelectedValue;
                    int id = Convert.ToInt32(change_data_id_dept.Text.Trim());
                    switch (value)
                    {
                        case "1":
                            if (method.dept_change_name(id, data_change_text_dept.Text.Trim()))
                            {
                                message = "修改成功(๑╹◡╹)ﾉ";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            else
                            {
                                message = "未查询到该编号数据╮(・o・)╭";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "2":
                            if (method.isNum(data_change_text_dept.Text.Trim()))
                            {
                                if (method.dept_change_personId(id, Convert.ToInt32(data_change_text_dept.Text.Trim())))
                                {
                                    message = "修改成功(๑╹◡╹)ﾉ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                                else
                                {
                                    message = "未查询到该编号数据╮(・o・)╭";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                            }
                            else//输入的不是数字
                            {
                                message = "请输入数字编号(╬￣皿￣)";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                    }
                }
                else
                {
                    message = "要修改的编号只能是数字(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            page_select("2");
        }

        protected void delete_dept_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(delete_id_text_dept.Text.Trim()))
            {
                message = "请输入要删除的编号(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else
            {
                if (method.isNum(delete_id_text_dept.Text.Trim()))
                {
                    int id = Convert.ToInt32(delete_id_text_dept.Text.Trim());
                    if (method.dept_delete(id))
                    {
                        message = "删除成功(๑╹◡╹)ﾉ";
                        ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                    else
                    {
                        message = "未查询到该编号数据╮(・o・)╭";
                        ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                }
                else
                {
                    message = "要删除的编号只能是数字(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            page_select("2");
        }
        /// <summary>
        /// 人员的管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void change_emp_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(data_change_text_emp.Text.Trim()) || visiterService.is_none(change_data_id_emp.Text.Trim()))
            {
                message = "请输入完整(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else//不为空值
            {
                if (method.isNum(change_data_id_emp.Text.Trim()))
                {
                    string value = select_item_dropdownlist_emp.SelectedValue;
                    int id = Convert.ToInt32(change_data_id_emp.Text.Trim());
                    switch (value)
                    {
                        case "1":
                            if (method.emp_change_name(id, data_change_text_emp.Text.Trim()))
                            {
                                message = "修改成功(๑╹◡╹)ﾉ";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            else
                            {
                                message = "未查询到该编号数据╮(・o・)╭";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "2":
                            if (method.emp_change_pwd(id, data_change_text_emp.Text.Trim()))
                            {
                                message = "修改成功(๑╹◡╹)ﾉ";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            else
                            {
                                message = "未查询到该编号数据╮(・o・)╭";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "3":
                            if (method.isNum(data_change_text_emp.Text.Trim()))
                            {
                                if (method.emp_change_phone(id, data_change_text_emp.Text.Trim()))
                                {
                                    message = "修改成功(๑╹◡╹)ﾉ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                                else
                                {
                                    message = "未查询到该编号数据╮(・o・)╭";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                            }
                            else
                            {
                                message = "请输入数字电话号码(╬￣皿￣)";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "4":
                            bool is_admin = true;
                            if(data_change_text_emp.Text.Trim()=="是"|| data_change_text_emp.Text.Trim() == "1"|| data_change_text_emp.Text.Trim() == "yes")
                            {
                                if (method.emp_change_is_admin(id, is_admin))
                                {
                                    message = "修改成功(๑╹◡╹)ﾉ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                                else
                                {
                                    message = "未查询到该编号数据╮(・o・)╭";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                            }else if(data_change_text_emp.Text.Trim() == "否"|| data_change_text_emp.Text.Trim() == "0"|| data_change_text_emp.Text.Trim() == "no")
                            {
                                is_admin = false;
                                if (method.emp_change_is_admin(id, is_admin))
                                {
                                    message = "修改成功(๑╹◡╹)ﾉ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                                else
                                {
                                    message = "未查询到该编号数据╮(・o・)╭";
                                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                                }
                            }
                            else
                            {
                                message = "请输入有效值(╬￣皿￣)";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                        case "5":
                            if (method.emp_change_dept(id, data_change_text_emp.Text.Trim()))
                            {
                                message = "修改成功(๑╹◡╹)ﾉ";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            else
                            {
                                message = "未查询到该编号数据╮(・o・)╭";
                                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                            }
                            break;
                    }
                }
                else
                {
                    message = "要修改的编号只能是数字(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            page_select("3");
        }

        protected void delete_emp_btn_click(object sender, EventArgs e)
        {
            if (visiterService.is_none(delete_id_text_emp.Text.Trim()))
            {
                message = "请输入要删除的编号(¬_¬)";
                ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
            else
            {
                if (method.isNum(delete_id_text_emp.Text.Trim()))
                {
                    int id = Convert.ToInt32(delete_id_text_emp.Text.Trim());
                    if (method.emp_delete(id))
                    {
                        message = "删除成功(๑╹◡╹)ﾉ";
                        ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                    else
                    {
                        message = "未查询到该编号数据╮(・o・)╭";
                        ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                }
                else
                {
                    message = "要删除的编号只能是数字(╬￣皿￣)";
                    ClientScript.RegisterStartupScript(this.GetType(), "num_error", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
            }
            page_select("3");
        }
    }
}