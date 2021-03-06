using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DAL;

namespace EMS.BLL
{
    public class VisiterService
    {
        infoDBDataContext db = new infoDBDataContext();
        /// <summary>
        /// 检查是否登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>如果不为空返回Id，否则返回null</returns>
        public int CheckLogin(string name, string password)
        {
            //如果查询的数据不存在， 则返回 null
            Employee_info employee = (from r in db.Employee_info
                                      where r.name == name && r.password == password
                                      select r).FirstOrDefault();
            if (employee != null)
            {
                return employee.Id;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 判断是否重名
        /// </summary>
        /// <param name="name">输入的用户名</param>
        /// <returns>重名时返回true，否则返回false</returns>
        public bool IsNameExist(string name)
        {
            Employee_info employee = (from r in db.Employee_info
                                      where r.name == name
                                      select r).FirstOrDefault();
            if (employee != null)
                return true;
            else
                return false;
        }
        
        /// <summary>
        /// 判断是否为管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Is_admin(int id)
        {
            Employee_info is_admin = (from r in db.Employee_info
                                      where r.Id == id && r.is_admin == true
                                      select r).FirstOrDefault();

            if (is_admin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断两次密码是否相同
        /// </summary>
        /// <param name="password"></param>
        /// <param name="sec_password"></param>
        /// <returns></returns>
        public bool confirm_password(string password, string sec_password)
        {
            if (password == sec_password)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 检测手机号
        /// </summary>
        /// <param name="username"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool confirm_phone(string username,string phone)
        {
            Employee_info Search_succeeded = (from r in db.Employee_info
                                              where username == r.name && phone == r.phone
                                              select r).FirstOrDefault();
            if (Search_succeeded == null)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 获取密码
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string get_password(string username)
        {
            Employee_info search_password = (from r in db.Employee_info
                                              where username == r.name
                                              select r).FirstOrDefault();
            if (search_password != null)
                return search_password.password;
            else
                return "";
        }
        /// <summary>
        /// 判断是否为空值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool is_none(string text)
        {
            if (text == "")
                return true;
            else
                return false;
        }
    }
}
