using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //OrderBook
    public partial class OrderBookDAO
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OrderBook");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return SqlHelper.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lks.Mall.Model.OrderBook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrderBook(");			
            strSql.Append("OrderID,BookID,Quantity,UnitPrice");
			strSql.Append(") values (");
            strSql.Append("@OrderID,@BookID,@Quantity,@UnitPrice");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@OrderID", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@BookID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.OrderID;                        
            parameters[1].Value = model.BookID;                        
            parameters[2].Value = model.Quantity;                        
            parameters[3].Value = model.UnitPrice;                        
			   
			object obj = SqlHelper.GetSingle(strSql.ToString(),parameters);			
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
		public bool Update(lks.Mall.Model.OrderBook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrderBook set ");
			                                                
            strSql.Append(" OrderID = @OrderID , ");                                    
            strSql.Append(" BookID = @BookID , ");                                    
            strSql.Append(" Quantity = @Quantity , ");                                    
            strSql.Append(" UnitPrice = @UnitPrice  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrderID", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@BookID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.OrderID;                        
            parameters[2].Value = model.BookID;                        
            parameters[3].Value = model.Quantity;                        
            parameters[4].Value = model.UnitPrice;                        
            int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrderBook ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;


			int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrderBook ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			int rows=SqlHelper.ExecuteSql(strSql.ToString());
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
		public lks.Mall.Model.OrderBook GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, OrderID, BookID, Quantity, UnitPrice  ");			
			strSql.Append("  from OrderBook ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			lks.Mall.Model.OrderBook model=new lks.Mall.Model.OrderBook();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																				model.OrderID= ds.Tables[0].Rows[0]["OrderID"].ToString();
																												if(ds.Tables[0].Rows[0]["BookID"].ToString()!="")
				{
					model.BookID=int.Parse(ds.Tables[0].Rows[0]["BookID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Quantity"].ToString()!="")
				{
					model.Quantity=int.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM OrderBook ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM OrderBook ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

