using EMS.BLL;
using System;
using System.Web.UI;

namespace EMS.Web
{
    public partial class login2 : System.Web.UI.Page
    {
        VisiterService visiterService = new VisiterService();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            //实现聚焦时去掉文字提示，失焦时出现文字提示
            username_up.Attributes.Add("OnFocus", "if(this.value=='Username...') {this.value=''}");
            username_up.Attributes.Add("OnBlur", "if(this.value=='') {this.value='Username...'}");
            username_in.Attributes.Add("OnFocus", "if(this.value=='Username...') {this.value=''}");
            username_in.Attributes.Add("OnBlur", "if(this.value=='') {this.value='Username...'}");
            phone_up.Attributes.Add("OnFocus", "if(this.value=='Phone...') {this.value=''}");
            phone_up.Attributes.Add("OnBlur", "if(this.value=='') {this.value='Phone...'}");

            //password_up.Attributes.Add("OnFocus", "if(this.value=='Password...') {this.value=''}");
            //password_up.Attributes.Add("OnBlur", "if(this.value=='') {this.value='Password...'}");
            //password_in.Attributes.Add("OnFocus", "if(this.value=='Password...') {this.value=''}");
            //password_in.Attributes.Add("OnBlur", "if(this.value=='') {this.value='Password...'}");
        }

        protected void sign_in_btn_Click(object sender, EventArgs e)
        {
            if (!(visiterService.is_none(username_in.Text.Trim())||visiterService.is_none(password_in.Text.Trim())))
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
                        Response.Redirect("~/admin/Default.aspx");//重导到管理员页面
                    }
                    else//一般用户登录
                    {
                        Session["VisiterId"] = visiterId;
                        Session["VisiterName"] = username_in.Text;
                        Response.Redirect("~/Default.aspx");//重导到普通用户页面
                    }
                }
                else//账号或密码错误
                {
                    //通过注册脚本实现弹窗
                    ClientScript.RegisterStartupScript(this.GetType(), "sign_in_alert", "<script type='text/javascript'>sign_in_alert();</script>");
                    //置空
                    password_in.Text = "";
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "is_none", "<script type='text/javascript'>none_alert();</script>");
            }
        }

        protected void sign_up_btn_Click(object sender, EventArgs e)
        {
            if(!(visiterService.is_none(username_up.Text.Trim()) || visiterService.is_none(password_up.Text.Trim()) || visiterService.is_none(phone_up.Text.Trim()) || visiterService.is_none(confirm_password_up.Text.Trim())))
            {
                if (visiterService.confirm_password(password_up.Text.Trim(), confirm_password_up.Text.Trim()))//如果两次密码相同
                {
                    if (visiterService.IsNameExist(username_up.Text.Trim()))//如果用户名存在
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "name_exist", "<script type='text/javascript'>name_exist_alert();</script>");
                        username_up.Text = "Username...";
                        //跳转到注册页面
                        ClientScript.RegisterStartupScript(this.GetType(), "sign_up", "<script type='text/javascript'>sign_up();</script>");
                    }
                    else//全部正确，向数据库插入信息
                    {
                        visiterService.Insert(username_up.Text.Trim(), password_up.Text.Trim(), phone_up.Text.Trim());
                        //提示信息
                        ClientScript.RegisterStartupScript(this.GetType(), "sign_up_successful", "<script type='text/javascript'>successful_message();</script>");
                    }
                }
                else//两次密码不同
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "different_password", "<script type='text/javascript'>password_alert();</script>");
                    confirm_password_up.Text = "";
                    //跳转到注册页面
                    ClientScript.RegisterStartupScript(this.GetType(), "sign_up", "<script type='text/javascript'>sign_up();</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "is_none", "<script type='text/javascript'>none_alert();</script>");
                //跳转到注册页面
                ClientScript.RegisterStartupScript(this.GetType(), "sign_up", "<script type='text/javascript'>sign_up();</script>");
            }
        }
    }
}