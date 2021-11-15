using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EMS.BLL;
using System.Web.UI.WebControls;

namespace EMS.Web
{
    public partial class login : System.Web.UI.Page
    {
        VisiterService visiterService = new VisiterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //获取用户id
                int visiterId = visiterService.CheckLogin(username_box.Text.Trim(), password_box.Text.Trim());
                //对用户id进行判断
                if (visiterId > 0)//用户名和密码正确
                {
                    Session.Clear();//清除Session中保存的内容
                    if (visiterService.Is_admin(visiterId))//管理员登录
                    {
                        Session["AdminId"] = visiterId;
                        Session["AdminName"] = username_box.Text;
                        Response.Redirect("~/admin/Default.aspx");//重导到管理员页面
                    }
                    else//一般用户登录
                    {
                        Session["VisiterId"] = visiterId;
                        Session["VisiterName"] = username_box.Text;
                        Response.Redirect("~/Default.aspx");//重导到普通用户页面
                    }
                }
                else
                {
                    ////通过注册脚本实现弹窗
                    //string js = "<script stye='text / javascript'>funtion message(){alert('账号或密码错误');}</script>";
                    //ClientScript.RegisterStartupScript(GetType(), "message", js);
                    lblMsg.Text = "用户名或密码错误！";
                }
            }
        }
    }
}