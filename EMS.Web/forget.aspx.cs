using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.BLL;

namespace EMS.Web
{
    public partial class forget : System.Web.UI.Page
    {
        VisiterService visiterService = new VisiterService();
        String message = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!(visiterService.is_none(username_forget.Text.Trim())|| visiterService.is_none(phone_forget.Text.Trim())))
            {
                if (!visiterService.IsNameExist(username_forget.Text.Trim()))//用户名不存在
                {
                    message = "用户名不存在┐(ﾟ～ﾟ)┌";
                    ClientScript.RegisterStartupScript(this.GetType(), "not_exist", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                }
                else//用户名存在
                {
                    if (visiterService.confirm_phone(username_forget.Text.Trim(),phone_forget.Text.Trim()))//电话号码正确
                    {
                        string password = visiterService.get_password(username_forget.Text.Trim());
                        ClientScript.RegisterStartupScript(this.GetType(), "get_password", "password_message('"+password+"')",true);
                    }
                    else//电话号码不正确
                    {
                        message = "电话号码错误(●—●)";
                        ClientScript.RegisterStartupScript(this.GetType(), "phone_error_alert", "<script type='text/javascript'>alert_message('" + message + "');</script>");
                    }
                }
            }
            else
            {
                message = "所有选项不能为空ヽ(`Д´)ﾉ";
                ClientScript.RegisterStartupScript(this.GetType(), "is_none", "<script type='text/javascript'>alert_message('" + message + "');</script>");
            }
        }
    }
}