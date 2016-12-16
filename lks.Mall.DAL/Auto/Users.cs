using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //Users
    public partial class UsersDAO
    {

        public bool Exists(int Id, string LoginId, string Mail)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" LoginId = @LoginId and  ");
            strSql.Append(" Mail = @Mail  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@LoginId", SqlDbType.NVarChar,50),
                    new SqlParameter("@Mail", SqlDbType.NVarChar,100)           };
            parameters[0].Value = Id;
            parameters[1].Value = LoginId;
            parameters[2].Value = Mail;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string LoginId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where ");
            strSql.Append(" LoginId = @LoginId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LoginId", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = LoginId;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lks.Mall.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("LoginId,LoginPwd,Name,Address,Phone,Mail,UserStateId");
            strSql.Append(") values (");
            strSql.Append("@LoginId,@LoginPwd,@Name,@Address,@Phone,@Mail,@UserStateId");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@LoginId", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@LoginPwd", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Name", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Address", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@Phone", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@Mail", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@UserStateId", SqlDbType.Int,4)

            };

            parameters[0].Value = model.LoginId;
            parameters[1].Value = model.LoginPwd;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Mail;
            parameters[6].Value = model.UserStateId;

            object obj = SqlHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lks.Mall.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");

            strSql.Append(" LoginId = @LoginId , ");
            strSql.Append(" LoginPwd = @LoginPwd , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" Phone = @Phone , ");
            strSql.Append(" Mail = @Mail , ");
            strSql.Append(" UserStateId = @UserStateId  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@LoginId", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@LoginPwd", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Name", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Address", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@Phone", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@Mail", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@UserStateId", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.LoginId;
            parameters[2].Value = model.LoginPwd;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Mail;
            parameters[7].Value = model.UserStateId;
            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = SqlHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lks.Mall.Model.Users GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, LoginId, LoginPwd, Name, Address, Phone, Mail, UserStateId  ");
            strSql.Append("  from Users ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            lks.Mall.Model.Users model = new lks.Mall.Model.Users();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                model.LoginPwd = ds.Tables[0].Rows[0]["LoginPwd"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Mail = ds.Tables[0].Rows[0]["Mail"].ToString();
                if (ds.Tables[0].Rows[0]["UserStateId"].ToString() != "")
                {
                    model.UserStateId = int.Parse(ds.Tables[0].Rows[0]["UserStateId"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }


    }
}

