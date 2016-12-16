using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //Cart
    public partial class CartDAO
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cart");
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
		public int Add(lks.Mall.Model.Cart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cart(");			
            strSql.Append("UserId,BookId,Count");
			strSql.Append(") values (");
            strSql.Append("@UserId,@BookId,@Count");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@BookId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.UserId;                        
            parameters[1].Value = model.BookId;                        
            parameters[2].Value = model.Count;                        
			   
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
		public bool Update(lks.Mall.Model.Cart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cart set ");
			                                                
            strSql.Append(" UserId = @UserId , ");                                    
            strSql.Append(" BookId = @BookId , ");                                    
            strSql.Append(" Count = @Count  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@BookId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.UserId;                        
            parameters[2].Value = model.BookId;                        
            parameters[3].Value = model.Count;                        
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
			strSql.Append("delete from Cart ");
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
			strSql.Append("delete from Cart ");
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
		public lks.Mall.Model.Cart GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, UserId, BookId, Count  ");			
			strSql.Append("  from Cart ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			lks.Mall.Model.Cart model=new lks.Mall.Model.Cart();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["BookId"].ToString()!="")
				{
					model.BookId=int.Parse(ds.Tables[0].Rows[0]["BookId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
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
			strSql.Append(" FROM Cart ");
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
			strSql.Append(" FROM Cart ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

