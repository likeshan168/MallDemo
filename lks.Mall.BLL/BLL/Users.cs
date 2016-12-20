using System;
using System.Collections.Generic;
using System.Data;
using lks.Mall.Model;
using lks.Mall.Model.Enum;
using lks.Mall.Utility;
using System.Linq;

namespace lks.Mall.BLL
{
    //Users
    public partial class UsersService
    {

        private readonly lks.Mall.DAL.UsersDAO dal = new lks.Mall.DAL.UsersDAO();
        public UsersService()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id, string LoginId, string Mail)
        {
            return dal.Exists(Id, LoginId, Mail);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LoginId)
        {
            return dal.Exists(LoginId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lks.Mall.Model.Users model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lks.Mall.Model.Users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        public LoginResult Login(string userName, string password, out Users user)
        {
            user = null;
            Users temp = GetModelList($"LoginId='{userName}'").FirstOrDefault();

            if (temp == null)
            {
                return LoginResult.用户名不存在;
            }
            else
            {
                if (temp.LoginPwd.Equals(password))
                {
                    user = temp;
                    return LoginResult.登录成功;
                }
                else
                {
                    return LoginResult.密码错误;
                }
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lks.Mall.Model.Users GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public lks.Mall.Model.Users GetModelByCache(int Id)
        {

            string CacheKey = "UsersModel-" + Id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (lks.Mall.Model.Users)objModel;
        }

        public int Register(string userName, string password, out Users user)
        {
            user = null;
            //1. 判断注册的用户名是否存储
            if (Exists(userName))
            {
                return 1;
            }

            //2. 添加该注册用户到数据库
            user = new Users
            {
                LoginId = userName,
                LoginPwd = password,
                Address = string.Empty,
                Mail = string.Empty,
                Name = string.Empty,
                Phone = string.Empty,
                UserStateId = 1
            };

            int id = Add(user);
            if (id > 0)
            {
                user.Id = id;
                return 0;
            }
            else
            {
                return 2;
            }

        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lks.Mall.Model.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lks.Mall.Model.Users> DataTableToList(DataTable dt)
        {
            List<lks.Mall.Model.Users> modelList = new List<lks.Mall.Model.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lks.Mall.Model.Users model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lks.Mall.Model.Users();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.LoginId = dt.Rows[n]["LoginId"].ToString();
                    model.LoginPwd = dt.Rows[n]["LoginPwd"].ToString();
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.Mail = dt.Rows[n]["Mail"].ToString();
                    if (dt.Rows[n]["UserStateId"].ToString() != "")
                    {
                        model.UserStateId = int.Parse(dt.Rows[n]["UserStateId"].ToString());
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #endregion

    }
}