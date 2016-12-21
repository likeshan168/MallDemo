using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using lks.Mall.Model;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //Categories
    public partial class CategoriesDAO
    {

        public bool Exists(int Id, string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Categories");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" Name = @Name  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@Name", SqlDbType.NVarChar,200)           };
            parameters[0].Value = Id;
            parameters[1].Value = Name;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Categories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Categories(");
            strSql.Append("Name");
            strSql.Append(") values (");
            strSql.Append("@Name");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Name", SqlDbType.NVarChar,200)

            };

            parameters[0].Value = model.Name;

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
        public bool Update(Categories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Categories set ");

            strSql.Append(" Name = @Name  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@Name", SqlDbType.NVarChar,200)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
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
            strSql.Append("delete from Categories ");
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
            strSql.Append("delete from Categories ");
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
        public Categories GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Name  ");
            strSql.Append("  from Categories ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            Categories model = new Categories();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();

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
            strSql.Append(" FROM Categories ");
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
            strSql.Append(" FROM Categories ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>返回条数</returns>
        public int QueryCount(object wheres)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(Id)");
            strSql.Append("  from Categories ");
            string where = SqlHelper.GetWhere(wheres);
            strSql.Append(where);
            return SqlHelper.ExecuteScalar<int>(strSql.ToString());
        }
        /// <summary>
        /// 获取指定页的数据列表
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">每一页显示的条数</param>
        /// <param name="wheres">查询条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <returns>数据列表</returns>
        public IEnumerable<Categories> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        {
            string sql = SqlHelper.GenerateQuerySql("Categories", null, index, size, wheres, orderField, isDesc);
            return SqlHelper.GetList<Categories>(sql, null);
        }
        /// <summary>
        /// 根据条件获取单条数据
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>指定条件的数据</returns>
        public Categories QuerySingle(object wheres)
        {
            string sql = SqlHelper.GenerateQuerySql("Categories", null, 1, 1, wheres, "Id");
            return SqlHelper.QuerySingle<Categories>(sql, null);
        }

    }
}

