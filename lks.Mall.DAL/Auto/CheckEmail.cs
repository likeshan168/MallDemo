using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //CheckEmail
    public partial class CheckEmailDAO
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CheckEmail");
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
		public int Add(lks.Mall.Model.CheckEmail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CheckEmail(");			
            strSql.Append("Actived,ActiveCode");
			strSql.Append(") values (");
            strSql.Append("@Actived,@ActiveCode");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Actived", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ActiveCode", SqlDbType.NVarChar,50)             
              
            };
			            
            parameters[0].Value = model.Actived;                        
            parameters[1].Value = model.ActiveCode;                        
			   
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
		public bool Update(lks.Mall.Model.CheckEmail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CheckEmail set ");
			                                                
            strSql.Append(" Actived = @Actived , ");                                    
            strSql.Append(" ActiveCode = @ActiveCode  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Actived", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ActiveCode", SqlDbType.NVarChar,50)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.Actived;                        
            parameters[2].Value = model.ActiveCode;                        
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
			strSql.Append("delete from CheckEmail ");
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
			strSql.Append("delete from CheckEmail ");
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
		public lks.Mall.Model.CheckEmail GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, Actived, ActiveCode  ");			
			strSql.Append("  from CheckEmail ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			lks.Mall.Model.CheckEmail model=new lks.Mall.Model.CheckEmail();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Actived"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Actived"].ToString()=="1")||(ds.Tables[0].Rows[0]["Actived"].ToString().ToLower()=="true"))
					{
					model.Actived= true;
					}
					else
					{
					model.Actived= false;
					}
				}
																				model.ActiveCode= ds.Tables[0].Rows[0]["ActiveCode"].ToString();
																										
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
			strSql.Append(" FROM CheckEmail ");
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
			strSql.Append(" FROM CheckEmail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

