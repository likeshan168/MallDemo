using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //VidoFile
    public partial class VidoFileDAO
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VidoFile");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lks.Mall.Model.VidoFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VidoFile(");
            strSql.Append("Title,FivPath,Status,FileExt");
            strSql.Append(") values (");
            strSql.Append("@Title,@FivPath,@Status,@FileExt");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Title", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FivPath", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@Status", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FileExt", SqlDbType.NVarChar,50)

            };

            parameters[0].Value = model.Title;
            parameters[1].Value = model.FivPath;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.FileExt;

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
        public bool Update(lks.Mall.Model.VidoFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VidoFile set ");

            strSql.Append(" Title = @Title , ");
            strSql.Append(" FivPath = @FivPath , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" FileExt = @FileExt  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@Title", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FivPath", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@Status", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FileExt", SqlDbType.NVarChar,50)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.FivPath;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.FileExt;
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
            strSql.Append("delete from VidoFile ");
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
            strSql.Append("delete from VidoFile ");
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
        public lks.Mall.Model.VidoFile GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Title, FivPath, Status, FileExt  ");
            strSql.Append("  from VidoFile ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            lks.Mall.Model.VidoFile model = new lks.Mall.Model.VidoFile();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.FivPath = ds.Tables[0].Rows[0]["FivPath"].ToString();
                model.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                model.FileExt = ds.Tables[0].Rows[0]["FileExt"].ToString();

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
            strSql.Append(" FROM VidoFile ");
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
            strSql.Append(" FROM VidoFile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }


    }
}

