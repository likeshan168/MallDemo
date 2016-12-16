using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //1
    public partial class sysdiagramsDAO
	{
   		     
		public bool Exists(string name,int principal_id,int diagram_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sysdiagrams");
			strSql.Append(" where ");
			                                       strSql.Append(" name = @name and  ");
                                                                   strSql.Append(" principal_id = @principal_id and  ");
                                                                   strSql.Append(" diagram_id = @diagram_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,128),
					new SqlParameter("@principal_id", SqlDbType.Int,4),
					new SqlParameter("@diagram_id", SqlDbType.Int,4)			};
			parameters[0].Value = name;
			parameters[1].Value = principal_id;
			parameters[2].Value = diagram_id;

			return SqlHelper.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lks.Mall.Model.sysdiagrams model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sysdiagrams(");			
            strSql.Append("name,principal_id,version,definition");
			strSql.Append(") values (");
            strSql.Append("@name,@principal_id,@version,@definition");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@name", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@principal_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@version", SqlDbType.Int,4) ,            
                        new SqlParameter("@definition", SqlDbType.VarBinary,-1)             
              
            };
			            
            parameters[0].Value = model.name;                        
            parameters[1].Value = model.principal_id;                        
            parameters[2].Value = model.version;                        
            parameters[3].Value = model.definition;                        
			   
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
		public bool Update(lks.Mall.Model.sysdiagrams model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sysdiagrams set ");
			                        
            strSql.Append(" name = @name , ");                                    
            strSql.Append(" principal_id = @principal_id , ");                                                            
            strSql.Append(" version = @version , ");                                    
            strSql.Append(" definition = @definition  ");            			
			strSql.Append(" where diagram_id=@diagram_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@name", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@principal_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@diagram_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@version", SqlDbType.Int,4) ,            
                        new SqlParameter("@definition", SqlDbType.VarBinary,-1)             
              
            };
						            
            parameters[0].Value = model.name;                        
            parameters[1].Value = model.principal_id;                        
            parameters[2].Value = model.diagram_id;                        
            parameters[3].Value = model.version;                        
            parameters[4].Value = model.definition;                        
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
		public bool Delete(int diagram_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sysdiagrams ");
			strSql.Append(" where diagram_id=@diagram_id");
						SqlParameter[] parameters = {
					new SqlParameter("@diagram_id", SqlDbType.Int,4)
			};
			parameters[0].Value = diagram_id;


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
		public bool DeleteList(string diagram_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sysdiagrams ");
			strSql.Append(" where ID in ("+diagram_idlist + ")  ");
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
		public lks.Mall.Model.sysdiagrams GetModel(int diagram_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select name, principal_id, diagram_id, version, definition  ");			
			strSql.Append("  from sysdiagrams ");
			strSql.Append(" where diagram_id=@diagram_id");
						SqlParameter[] parameters = {
					new SqlParameter("@diagram_id", SqlDbType.Int,4)
			};
			parameters[0].Value = diagram_id;

			
			lks.Mall.Model.sysdiagrams model=new lks.Mall.Model.sysdiagrams();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.name= ds.Tables[0].Rows[0]["name"].ToString();
																												if(ds.Tables[0].Rows[0]["principal_id"].ToString()!="")
				{
					model.principal_id=int.Parse(ds.Tables[0].Rows[0]["principal_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["diagram_id"].ToString()!="")
				{
					model.diagram_id=int.Parse(ds.Tables[0].Rows[0]["diagram_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["version"].ToString()!="")
				{
					model.version=int.Parse(ds.Tables[0].Rows[0]["version"].ToString());
				}
																																								if(ds.Tables[0].Rows[0]["definition"].ToString()!="")
				{
					model.definition= (byte[])ds.Tables[0].Rows[0]["definition"];
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
			strSql.Append(" FROM sysdiagrams ");
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
			strSql.Append(" FROM sysdiagrams ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

