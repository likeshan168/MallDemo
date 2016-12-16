using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //Articel_Words
    public partial class Articel_WordsDAO
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Articel_Words");
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
		public int Add(lks.Mall.Model.Articel_Words model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Articel_Words(");			
            strSql.Append("WordPattern,IsForbid,IsMod,ReplaceWord");
			strSql.Append(") values (");
            strSql.Append("@WordPattern,@IsForbid,@IsMod,@ReplaceWord");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@WordPattern", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@IsForbid", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsMod", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ReplaceWord", SqlDbType.NVarChar,50)             
              
            };
			            
            parameters[0].Value = model.WordPattern;                        
            parameters[1].Value = model.IsForbid;                        
            parameters[2].Value = model.IsMod;                        
            parameters[3].Value = model.ReplaceWord;                        
			   
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
		public bool Update(lks.Mall.Model.Articel_Words model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Articel_Words set ");
			                                                
            strSql.Append(" WordPattern = @WordPattern , ");                                    
            strSql.Append(" IsForbid = @IsForbid , ");                                    
            strSql.Append(" IsMod = @IsMod , ");                                    
            strSql.Append(" ReplaceWord = @ReplaceWord  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@WordPattern", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@IsForbid", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsMod", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ReplaceWord", SqlDbType.NVarChar,50)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.WordPattern;                        
            parameters[2].Value = model.IsForbid;                        
            parameters[3].Value = model.IsMod;                        
            parameters[4].Value = model.ReplaceWord;                        
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
			strSql.Append("delete from Articel_Words ");
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
			strSql.Append("delete from Articel_Words ");
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
		public lks.Mall.Model.Articel_Words GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, WordPattern, IsForbid, IsMod, ReplaceWord  ");			
			strSql.Append("  from Articel_Words ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			lks.Mall.Model.Articel_Words model=new lks.Mall.Model.Articel_Words();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																				model.WordPattern= ds.Tables[0].Rows[0]["WordPattern"].ToString();
																																												if(ds.Tables[0].Rows[0]["IsForbid"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsForbid"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsForbid"].ToString().ToLower()=="true"))
					{
					model.IsForbid= true;
					}
					else
					{
					model.IsForbid= false;
					}
				}
																																if(ds.Tables[0].Rows[0]["IsMod"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsMod"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsMod"].ToString().ToLower()=="true"))
					{
					model.IsMod= true;
					}
					else
					{
					model.IsMod= false;
					}
				}
																				model.ReplaceWord= ds.Tables[0].Rows[0]["ReplaceWord"].ToString();
																										
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
			strSql.Append(" FROM Articel_Words ");
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
			strSql.Append(" FROM Articel_Words ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

