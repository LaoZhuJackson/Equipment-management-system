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
                    where r.id == id
                    select r).ToList();
        }
        //按设备名称查询
        public List<Equip_Information> Search_ByName(String name)
        {
            return (from r in db.Equip_Information
                    where SqlMethods.Like(r.name, "%" + name + "%")
                    select r).ToList();
        }
        //按设备规格查询
        public List<Equip_Information> Search_BySpec(String name)
        {
            return (from r in db.Equip_Information
                    where SqlMethods.Like(r.specification, "%" + name + "%")
                    select r).ToList();
        }
        //按购入日期（年）查询
        public List<Equip_Information> Search_ByDate(String date)
        {
            return (from r in db.Equip_Information
                    where SqlMethods.Like(Convert.ToString(r.date), "%" + date + "%")
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
        public bool ChangePassword(int id, string oldpwd, string newpwd)
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
        /// <summary>
        /// 判断是否为日期
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool isDate(String text)
        {
            try//通过转换是否抛出异常来判断
            {
                DateTime i = Convert.ToDateTime(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 各种数据插入
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="phone"></param>
        /// <param name="is_admin"></param>
        /// <param name="dept"></param>
        public void Insert(string name, string password, string phone)//注册时插入
        {
            //选出employee_info表中的最后一条数据的id
            int last_Id = db.Employee_info.AsEnumerable().Last().Id;
            Employee_info employee = new Employee_info
            {
                Id = last_Id + 1,
                name = name,
                password = password,
                phone = phone,
            };
            db.Employee_info.InsertOnSubmit(employee);
            db.SubmitChanges();
        }
        //管理员添加部门
        public bool Insert(string name, int person_id)
        {
            int last_Id = db.dept_info.AsEnumerable().Last().Id;
            try
            {
                dept_info dept = new dept_info
                {
                    Id = last_Id + 1,
                    name = name,
                    person_id = person_id
                };
                db.dept_info.InsertOnSubmit(dept);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //管理员添加员工
        public void Insert(string name, string password, string phone, bool is_admin, string dept)
        {
            int last_Id = db.Employee_info.AsEnumerable().Last().Id;
            Employee_info employee = new Employee_info
            {
                Id = last_Id + 1,
                name = name,
                password = password,
                phone = phone,
                is_admin = is_admin,
                dept = dept
            };
            db.Employee_info.InsertOnSubmit(employee);
            db.SubmitChanges();
        }
        //管理员添加设备
        public void Insert(string name, string spec, int price, DateTime date, string location, int person_id, string image)
        {
            int last_Id = db.Equip_Information.AsEnumerable().Last().id;
            Equip_Information equip = new Equip_Information
            {
                id = last_Id + 1,
                name = name,
                specification = spec,
                price = price,
                date = date,
                location = location,
                person_id = person_id,
                images = image
            };
            db.Equip_Information.InsertOnSubmit(equip);
            db.SubmitChanges();
        }
        /// <summary>-------------------------------------------------------------
        /// 各种数据修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool equip_change_name(int id, string name)//修改设备名称
        {
            Equip_Information row = (from r in db.Equip_Information
                                     where r.id == id
                                     select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.name = name;
                db.SubmitChanges();
                return true;
            }
        }
        public bool equip_change_spec(int id, string spec)//修改设备规格
        {
            Equip_Information row = (from r in db.Equip_Information
                                     where r.id == id
                                     select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.specification = spec;
                db.SubmitChanges();
                return true;
            }
        }
        public bool equip_change_price(int id, int price)//修改设备价格
        {
            Equip_Information row = (from r in db.Equip_Information
                                     where r.id == id
                                     select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.price = price;
                db.SubmitChanges();
                return true;
            }
        }
        public bool equip_change_date(int id, DateTime date)//修改设备购入日期
        {
            Equip_Information row = (from r in db.Equip_Information
                                     where r.id == id
                                     select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.date = date;
                db.SubmitChanges();
                return true;
            }
        }
        public bool equip_change_location(int id, string location)//修改设备位置
        {
            Equip_Information row = (from r in db.Equip_Information
                                     where r.id == id
                                     select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.location = location;
                db.SubmitChanges();
                return true;
            }
        }
        public bool equip_change_personId(int id, int person_id)//修改设备负责人id
        {
            Equip_Information row = (from r in db.Equip_Information
                                     where r.id == id
                                     select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.person_id = person_id;
                db.SubmitChanges();
                return true;
            }
        }
        public bool equip_change_image(int id, string image)//修改设备图片路径
        {
            Equip_Information row = (from r in db.Equip_Information
                                     where r.id == id
                                     select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.images = image;
                db.SubmitChanges();
                return true;
            }
        }
        //------------------------------部门修改---------------------
        public bool dept_change_name(int id, string name)//修改部门名称
        {
            dept_info row = (from r in db.dept_info
                             where r.Id == id
                             select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.name = name;
                db.SubmitChanges();
                return true;
            }
        }
        public bool dept_change_personId(int id, int person_id)//修改部门负责人id
        {
            dept_info row = (from r in db.dept_info
                             where r.Id == id
                             select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.person_id = person_id;
                db.SubmitChanges();
                return true;
            }
        }
        public bool emp_change_name(int id, string name)//修改人员姓名
        {
            Employee_info row = (from r in db.Employee_info
                             where r.Id == id
                             select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.name = name;
                db.SubmitChanges();
                return true;
            }
        }
        public bool emp_change_pwd(int id, string pwd)//修改人员密码
        {
            Employee_info row = (from r in db.Employee_info
                                 where r.Id == id
                                 select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.password = pwd;
                db.SubmitChanges();
                return true;
            }
        }
        public bool emp_change_phone(int id, string phone)//修改人员电话
        {
            Employee_info row = (from r in db.Employee_info
                                 where r.Id == id
                                 select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.phone=phone;
                db.SubmitChanges();
                return true;
            }
        }
        public bool emp_change_is_admin(int id, bool is_admin)//修改人员管理员权限
        {
            Employee_info row = (from r in db.Employee_info
                                 where r.Id == id
                                 select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.is_admin = is_admin;
                db.SubmitChanges();
                return true;
            }
        }
        public bool emp_change_dept(int id, string dept)//修改人员部门名称
        {
            Employee_info row = (from r in db.Employee_info
                                 where r.Id == id
                                 select r).FirstOrDefault();
            if (row == null)//修改失败
            {
                return false;
            }
            else//修改成功
            {
                row.dept = dept;
                db.SubmitChanges();
                return true;
            }
        }
        //-----------------------------------------------各种表的删除---------------------------------------
        public bool equip_delete(int id)//设备删除
        {
            Equip_Information row = (from r in db.Equip_Information
                                     where r.id == id
                                     select r).FirstOrDefault();
            if (row == null)//删除失败
            {
                return false;
            }
            else//删除成功
            {
                db.Equip_Information.DeleteOnSubmit(row);
                db.SubmitChanges();
                return true;
            }
        }
        public bool dept_delete(int id)//部门删除
        {
            dept_info row = (from r in db.dept_info
                             where r.Id == id
                             select r).FirstOrDefault();
            if (row == null)//删除失败
            {
                return false;
            }
            else//删除成功
            {
                db.dept_info.DeleteOnSubmit(row);
                db.SubmitChanges();
                return true;
            }
        }
        public bool emp_delete(int id)//人员删除
        {
            Employee_info row = (from r in db.Employee_info
                                 where r.Id == id
                                 select r).FirstOrDefault();
            if (row == null)//删除失败
            {
                return false;
            }
            else//删除成功
            {
                db.Employee_info.DeleteOnSubmit(row);
                db.SubmitChanges();
                return true;
            }
        }
    }
}
