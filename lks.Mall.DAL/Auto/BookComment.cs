using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //BookComment
    public partial class BookCommentDAO
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BookComment");
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
		public int Add(lks.Mall.Model.BookComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BookComment(");			
            strSql.Append("Msg,CreateDateTime,BookId");
			strSql.Append(") values (");
            strSql.Append("@Msg,@CreateDateTime,@BookId");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Msg", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@CreateDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@BookId", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Msg;                        
            parameters[1].Value = model.CreateDateTime;                        
            parameters[2].Value = model.BookId;                        
			   
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
		public bool Update(lks.Mall.Model.BookComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BookComment set ");
			                                                
            strSql.Append(" Msg = @Msg , ");                                    
            strSql.Append(" CreateDateTime = @CreateDateTime , ");                                    
            strSql.Append(" BookId = @BookId  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Msg", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@CreateDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@BookId", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.Msg;                        
            parameters[2].Value = model.CreateDateTime;                        
            parameters[3].Value = model.BookId;                        
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
			strSql.Append("delete from BookComment ");
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
			strSql.Append("delete from BookComment ");
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
		public lks.Mall.Model.BookComment GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, Msg, CreateDateTime, BookId  ");			
			strSql.Append("  from BookComment ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			lks.Mall.Model.BookComment model=new lks.Mall.Model.BookComment();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																				model.Msg= ds.Tables[0].Rows[0]["Msg"].ToString();
																												if(ds.Tables[0].Rows[0]["CreateDateTime"].ToString()!="")
				{
					model.CreateDateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateDateTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["BookId"].ToString()!="")
				{
					model.BookId=int.Parse(ds.Tables[0].Rows[0]["BookId"].ToString());
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
			strSql.Append(" FROM BookComment ");
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
			strSql.Append(" FROM BookComment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

