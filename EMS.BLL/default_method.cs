using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.SqlClient;//为了实现模糊查询
using System.Text;
using System.Threading.Tasks;
using EMS.DAL;

namespace EMS.BLL
{
    /// <summary>
    /// default页面查询方法类
    /// </summary>
    public class default_method
    {
        //创建数据库实例
        infoDBDataContext db = new infoDBDataContext();
        /// <summary>
        /// 设备查询--------------------------------------------------------------
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //按编号查询
        public List<Equip_Information> Search_ById(int id)
        {
            return (from r in db.Equip_Information
                    where r.id== id
                    select r).ToList();
        }
        //按设备名称查询
        public List<Equip_Information> Search_ByName(String name)
        {
            return (from r in db.Equip_Information
                    where SqlMethods.Like(r.name,"%"+name+"%")
                    select r).ToList();
        }
        //按购入日期（年）查询
        public List<Equip_Information> Search_ByDate(String date)
        {
            return (from r in db.Equip_Information
                    where SqlMethods.Like(Convert.ToString(r.date), "%"+date+"%")
                    select r).ToList();
        }
        //按存放位置查询
        public List<Equip_Information> Search_ByLocation(String location)
        {
            return (from r in db.Equip_Information
                    where SqlMethods.Like(r.location, "%" + location + "%")
                    select r).ToList();
        }
        //按设备负责人名称查询
        public List<Equip_Information> Search_ByPerson_Id(int id)
        {
            return (from r in db.Equip_Information
                    where r.person_id == id
                    select r).ToList();
        }
        /// <summary>
        /// 部门查询-------------------------------------------------------------
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<dept_info> Search_ById_dept(int id)
        {
            return (from r in db.dept_info
                    where r.Id == id
                    select r).ToList();
        }
        public List<dept_info> Search_ByName_dept(String name)
        {
            return (from r in db.dept_info
                    where SqlMethods.Like(r.name, "%" + name + "%")
                    select r).ToList();
        }

        public List<dept_info> Search_ByPerson_dept(int id)
        {
            return (from r in db.dept_info
                    where r.person_id == id
                    select r).ToList();
        }
        /// <summary>
        /// 人员查询---------------------------------------------------------
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Employee_info> Search_ById_emp(int id)
        {
            return (from r in db.Employee_info
                    where r.Id == id
                    select r).ToList();
        }
        
        public List<Employee_info> Search_ByName_emp(String name)
        {
            return (from r in db.Employee_info
                    where SqlMethods.Like(r.name, "%" + name + "%")
                    select r).ToList();
        }
        public List<Employee_info> Search_ByDept_emp(String dept_name)
        {
            return (from r in db.Employee_info
                    where SqlMethods.Like(r.dept, dept_name + "%")
                    select r).ToList();
        }
        /// <summary>
        /// 通过id修改用户密码
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">新密码</param>
        public bool ChangePassword(int id,string oldpwd, string newpwd)
        {
            Employee_info employee = (from r in db.Employee_info
                                      where r.Id == id && r.password == oldpwd
                                      select r).FirstOrDefault();//如果查询的数据不存在， 则抛System.InvalidOperationException异常
            if (employee == null)
            {
                return false;
            }
            else
            {
                employee.password = newpwd;
                db.SubmitChanges();
                return true;
            }
        }
        /// <summary>
        /// 判断用户输入的是否为数字，是否为空值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool isNum(String text)
        {
            try//通过转换是否抛出异常来判断
            {
                int i = Convert.ToInt32(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
