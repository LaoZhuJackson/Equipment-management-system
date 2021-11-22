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
                    //按购入日期（年）查询
                    case "3":
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
                    case "4":
                        result_grid.DataSource = method.Search_ByLocation(data_text.Text.Trim());
                        result_grid.DataBind();
                        break;
                    //按设备负责人编号查询
                    case "5":
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
        //对表格的密码和电话号码进行隐藏
        protected void GridView_emp_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
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
        /// <summary>
        /// 进行页面定位
        /// </summary>
        /// <param name="page_num"></param>
        public void page_select(String page_num)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "page_select", "<script type='text/javascript'>search_page('" + page_num + "');</script>");
        }
    }
}