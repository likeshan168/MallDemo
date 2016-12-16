using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //Orders
    public partial class OrdersDAO
    {

        public bool Exists(string OrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Orders");
            strSql.Append(" where ");
            strSql.Append(" OrderId = @OrderId  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.NVarChar,50)         };
            parameters[0].Value = OrderId;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(lks.Mall.Model.Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Orders(");
            strSql.Append("OrderId,OrderDate,UserId,TotalPrice,PostAddress,state");
            strSql.Append(") values (");
            strSql.Append("@OrderId,@OrderDate,@UserId,@TotalPrice,@PostAddress,@state");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OrderId", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@OrderDate", SqlDbType.DateTime) ,
                        new SqlParameter("@UserId", SqlDbType.Int,4) ,
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@PostAddress", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@state", SqlDbType.Int,4)

            };

            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderDate;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.TotalPrice;
            parameters[4].Value = model.PostAddress;
            parameters[5].Value = model.state;
            SqlHelper.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lks.Mall.Model.Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Orders set ");

            strSql.Append(" OrderId = @OrderId , ");
            strSql.Append(" OrderDate = @OrderDate , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" TotalPrice = @TotalPrice , ");
            strSql.Append(" PostAddress = @PostAddress , ");
            strSql.Append(" state = @state  ");
            strSql.Append(" where OrderId=@OrderId  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OrderId", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@OrderDate", SqlDbType.DateTime) ,
                        new SqlParameter("@UserId", SqlDbType.Int,4) ,
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@PostAddress", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@state", SqlDbType.Int,4)

            };

            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderDate;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.TotalPrice;
            parameters[4].Value = model.PostAddress;
            parameters[5].Value = model.state;
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
        public bool Delete(string OrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Orders ");
            strSql.Append(" where OrderId=@OrderId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.NVarChar,50)         };
            parameters[0].Value = OrderId;


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
        /// 得到一个对象实体
        /// </summary>
        public lks.Mall.Model.Orders GetModel(string OrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderId, OrderDate, UserId, TotalPrice, PostAddress, state  ");
            strSql.Append("  from Orders ");
            strSql.Append(" where OrderId=@OrderId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.NVarChar,50)         };
            parameters[0].Value = OrderId;


            lks.Mall.Model.Orders model = new lks.Mall.Model.Orders();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.OrderId = ds.Tables[0].Rows[0]["OrderId"].ToString();
                if (ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalPrice"].ToString() != "")
                {
                    model.TotalPrice = decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
                }
                model.PostAddress = ds.Tables[0].Rows[0]["PostAddress"].ToString();
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
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
            strSql.Append(" FROM Orders ");
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
            strSql.Append(" FROM Orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }


    }
}

