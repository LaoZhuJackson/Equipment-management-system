using EMS.BLL;
using System;
using System.Web.UI;

namespace EMS.Web
{
    public partial class login2 : System.Web.UI.Page
    {
        VisiterService visiterService = new VisiterService();
        String message = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            //初始化清除Session内容
            Session.Clear();
        }

        protected void sign_in_btn_Click(object sender, EventArgs e)
        {
            if (!(visiterService.is_none(username_in.Text.Trim()) || visiterService.is_none(password_in.Text.Trim())))
            {
                //获取用户id
                int visiterId = visiterService.CheckLogin(username_in.Text.Trim(), password_in.Text.Trim());
                //对用户id进行判断
                if (visiterId > 0)//用户名和密码正确
                {
                    Session.Clear();//清除Session中保存的内容
                    if (visiterService.Is_admin(visiterId))//管理员登录
                    {
                        Session["AdminId"] = visiterId;
                        Session["AdminName"] = username_in.Text;
                        //为第一次登录成功通知作准备
                        Session["login_count_admin"] = "first";
                        Response.Redirect("~/admin/Default.aspx");//重导到管理员页面
                    }
                    else//一般用户登录
                    {
                        Session["VisiterId"] = visiterId;
                        Session["VisiterName"] = username_in.Text;
                        Session["login_count_visiter"] = "first";
                        Response.Redirect("~/Default.aspx");//重导到普通用户页面
                    }
                }
                else//账号或密码错误
                {
                    //通过注册脚本实现弹窗
                    message = "账号或密码错误( ･´ω`･ )";
                    ClientScript.RegisterStartupScript(this.GetType(), "sign_in_alert", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    //置空
                    password_in.Text = "";
                }
            }
            else//存在空值
            {
                message = "所有选项不能为空ヽ(`Д´)ﾉ";
                ClientScript.RegisterStartupScript(this.GetType(), "is_none", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
        }

        protected void sign_up_btn_Click(object sender, EventArgs e)
        {
            if (!(visiterService.is_none(username_up.Text.Trim()) || visiterService.is_none(password_up.Text.Trim()) || visiterService.is_none(phone_up.Text.Trim()) || visiterService.is_none(confirm_password_up.Text.Trim())))
            {
                if (visiterService.confirm_password(password_up.Text.Trim(), confirm_password_up.Text.Trim()))//如果两次密码相同
                {
                    if (visiterService.IsNameExist(username_up.Text.Trim()))//如果用户名存在
                    {
                        message = "用户名已存在┐(ﾟ～ﾟ)┌";
                        ClientScript.RegisterStartupScript(this.GetType(), "name_exist", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                        username_up.Text = "Username...";
                        //跳转到注册页面
                        ClientScript.RegisterStartupScript(this.GetType(), "sign_up", "<script type='text/javascript'>sign_up();</script>");
                    }
                    else//全部正确，向数据库插入信息
                    {
                        visiterService.Insert(username_up.Text.Trim(), password_up.Text.Trim(), phone_up.Text.Trim());
                        //提示信息
                        message = "注册成功(｡◕ˇ∀ˇ◕)";
                        ClientScript.RegisterStartupScript(this.GetType(), "sign_up_successful", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                }
                else//两次密码不同
                {
                    message = "两次密码输入不相同(｡・`ω´･)";
                    ClientScript.RegisterStartupScript(this.GetType(), "different_password", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    confirm_password_up.Text = "";
                    //跳转到注册页面
                    ClientScript.RegisterStartupScript(this.GetType(), "sign_up", "<script type='text/javascript'>sign_up();</script>");
                }
            }
            else//存在空值
            {
                message = "所有选项不能为空ヽ(`Д´)ﾉ";
                ClientScript.RegisterStartupScript(this.GetType(), "is_none", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                //跳转到注册页面
                ClientScript.RegisterStartupScript(this.GetType(), "sign_up", "<script type='text/javascript'>sign_up();</script>");
            }
        }
    }
}