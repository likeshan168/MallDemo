using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using lks.Mall.Model;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //Books
    public partial class BooksDAO
    {

        public bool Exists(int Id, string ISBN)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Books");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id and  ");
            strSql.Append(" ISBN = @ISBN  ");
            SqlParameter[] parameters =
            {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@ISBN", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = Id;
            parameters[1].Value = ISBN;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Books model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Books(");
            strSql.Append("Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks");
            strSql.Append(") values (");
            strSql.Append("@Title,@Author,@PublisherId,@PublishDate,@ISBN,@WordsCount,@UnitPrice,@ContentDescription,@AurhorDescription,@EditorComment,@TOC,@CategoryId,@Clicks");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Title", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@Author", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@PublisherId", SqlDbType.Int,4) ,
                        new SqlParameter("@PublishDate", SqlDbType.DateTime) ,
                        new SqlParameter("@ISBN", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@WordsCount", SqlDbType.Int,4) ,
                        new SqlParameter("@UnitPrice", SqlDbType.Money,8) ,
                        new SqlParameter("@ContentDescription", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@AurhorDescription", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@EditorComment", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@TOC", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@CategoryId", SqlDbType.Int,4) ,
                        new SqlParameter("@Clicks", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Title;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.PublisherId;
            parameters[3].Value = model.PublishDate;
            parameters[4].Value = model.ISBN;
            parameters[5].Value = model.WordsCount;
            parameters[6].Value = model.UnitPrice;
            parameters[7].Value = model.ContentDescription;
            parameters[8].Value = model.AurhorDescription;
            parameters[9].Value = model.EditorComment;
            parameters[10].Value = model.TOC;
            parameters[11].Value = model.CategoryId;
            parameters[12].Value = model.Clicks;

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
        public bool Update(Books model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Books set ");

            strSql.Append(" Title = @Title , ");
            strSql.Append(" Author = @Author , ");
            strSql.Append(" PublisherId = @PublisherId , ");
            strSql.Append(" PublishDate = @PublishDate , ");
            strSql.Append(" ISBN = @ISBN , ");
            strSql.Append(" WordsCount = @WordsCount , ");
            strSql.Append(" UnitPrice = @UnitPrice , ");
            strSql.Append(" ContentDescription = @ContentDescription , ");
            strSql.Append(" AurhorDescription = @AurhorDescription , ");
            strSql.Append(" EditorComment = @EditorComment , ");
            strSql.Append(" TOC = @TOC , ");
            strSql.Append(" CategoryId = @CategoryId , ");
            strSql.Append(" Clicks = @Clicks  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@Title", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@Author", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@PublisherId", SqlDbType.Int,4) ,
                        new SqlParameter("@PublishDate", SqlDbType.DateTime) ,
                        new SqlParameter("@ISBN", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@WordsCount", SqlDbType.Int,4) ,
                        new SqlParameter("@UnitPrice", SqlDbType.Money,8) ,
                        new SqlParameter("@ContentDescription", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@AurhorDescription", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@EditorComment", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@TOC", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@CategoryId", SqlDbType.Int,4) ,
                        new SqlParameter("@Clicks", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Author;
            parameters[3].Value = model.PublisherId;
            parameters[4].Value = model.PublishDate;
            parameters[5].Value = model.ISBN;
            parameters[6].Value = model.WordsCount;
            parameters[7].Value = model.UnitPrice;
            parameters[8].Value = model.ContentDescription;
            parameters[9].Value = model.AurhorDescription;
            parameters[10].Value = model.EditorComment;
            parameters[11].Value = model.TOC;
            parameters[12].Value = model.CategoryId;
            parameters[13].Value = model.Clicks;
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
            strSql.Append("delete from Books ");
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
            strSql.Append("delete from Books ");
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
        public lks.Mall.Model.Books GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Title, Author, PublisherId, PublishDate, ISBN, WordsCount, UnitPrice, ContentDescription, AurhorDescription, EditorComment, TOC, CategoryId, Clicks  ");
            strSql.Append("  from Books ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            lks.Mall.Model.Books model = new lks.Mall.Model.Books();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                if (ds.Tables[0].Rows[0]["PublisherId"].ToString() != "")
                {
                    model.PublisherId = int.Parse(ds.Tables[0].Rows[0]["PublisherId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PublishDate"].ToString() != "")
                {
                    model.PublishDate = DateTime.Parse(ds.Tables[0].Rows[0]["PublishDate"].ToString());
                }
                model.ISBN = ds.Tables[0].Rows[0]["ISBN"].ToString();
                if (ds.Tables[0].Rows[0]["WordsCount"].ToString() != "")
                {
                    model.WordsCount = int.Parse(ds.Tables[0].Rows[0]["WordsCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitPrice"].ToString() != "")
                {
                    model.UnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                }
                model.ContentDescription = ds.Tables[0].Rows[0]["ContentDescription"].ToString();
                model.AurhorDescription = ds.Tables[0].Rows[0]["AurhorDescription"].ToString();
                model.EditorComment = ds.Tables[0].Rows[0]["EditorComment"].ToString();
                model.TOC = ds.Tables[0].Rows[0]["TOC"].ToString();
                if (ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Clicks"].ToString() != "")
                {
                    model.Clicks = int.Parse(ds.Tables[0].Rows[0]["Clicks"].ToString());
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
            strSql.Append(" FROM Books ");
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
            strSql.Append(" FROM Books ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
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
        public IEnumerable<Books> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        {
            string sql = SqlHelper.GenerateQuerySql("Books", null, index, size, wheres, orderField, isDesc);
            return SqlHelper.GetList<Books>(sql, null);
        }
        /// <summary>
        /// 根据条件获取单条数据
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>指定条件的数据</returns>
        public Books QuerySingle(object wheres)
        {
            string sql = SqlHelper.GenerateQuerySql("Books", null, 1, 1, wheres, "Id");
            return SqlHelper.QuerySingle<Books>(sql, null);
        }
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>返回条数</returns>
        public int QueryCount(object wheres)
        {
            string where = SqlHelper.GetWhere(wheres);
            string sql = $"select count(Id) from Books {where}";
            return SqlHelper.ExecuteScalar<int>(sql);
        }

    }
}

