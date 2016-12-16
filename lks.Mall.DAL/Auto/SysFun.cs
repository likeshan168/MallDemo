using System.Text;
using System.Data.SqlClient;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.DAL
{
    //SysFun
    public partial class SysFunDAO
	{
   		     
		public bool Exists(int NodeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SysFun");
			strSql.Append(" where ");
			                                       strSql.Append(" NodeId = @NodeId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@NodeId", SqlDbType.Int,4)			};
			parameters[0].Value = NodeId;

			return SqlHelper.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(lks.Mall.Model.SysFun model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SysFun(");			
            strSql.Append("NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId");
			strSql.Append(") values (");
            strSql.Append("@NodeId,@DisplayName,@NodeURL,@DisplayOrder,@ParentNodeId");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@NodeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@DisplayName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@NodeURL", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@DisplayOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParentNodeId", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.NodeId;                        
            parameters[1].Value = model.DisplayName;                        
            parameters[2].Value = model.NodeURL;                        
            parameters[3].Value = model.DisplayOrder;                        
            parameters[4].Value = model.ParentNodeId;                        
			            SqlHelper.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lks.Mall.Model.SysFun model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SysFun set ");
			                        
            strSql.Append(" NodeId = @NodeId , ");                                    
            strSql.Append(" DisplayName = @DisplayName , ");                                    
            strSql.Append(" NodeURL = @NodeURL , ");                                    
            strSql.Append(" DisplayOrder = @DisplayOrder , ");                                    
            strSql.Append(" ParentNodeId = @ParentNodeId  ");            			
			strSql.Append(" where NodeId=@NodeId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@NodeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@DisplayName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@NodeURL", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@DisplayOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParentNodeId", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.NodeId;                        
            parameters[1].Value = model.DisplayName;                        
            parameters[2].Value = model.NodeURL;                        
            parameters[3].Value = model.DisplayOrder;                        
            parameters[4].Value = model.ParentNodeId;                        
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
		public bool Delete(int NodeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysFun ");
			strSql.Append(" where NodeId=@NodeId ");
						SqlParameter[] parameters = {
					new SqlParameter("@NodeId", SqlDbType.Int,4)			};
			parameters[0].Value = NodeId;


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
		/// 得到一个对象实体
		/// </summary>
		public lks.Mall.Model.SysFun GetModel(int NodeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select NodeId, DisplayName, NodeURL, DisplayOrder, ParentNodeId  ");			
			strSql.Append("  from SysFun ");
			strSql.Append(" where NodeId=@NodeId ");
						SqlParameter[] parameters = {
					new SqlParameter("@NodeId", SqlDbType.Int,4)			};
			parameters[0].Value = NodeId;

			
			lks.Mall.Model.SysFun model=new lks.Mall.Model.SysFun();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["NodeId"].ToString()!="")
				{
					model.NodeId=int.Parse(ds.Tables[0].Rows[0]["NodeId"].ToString());
				}
																																				model.DisplayName= ds.Tables[0].Rows[0]["DisplayName"].ToString();
																																model.NodeURL= ds.Tables[0].Rows[0]["NodeURL"].ToString();
																												if(ds.Tables[0].Rows[0]["DisplayOrder"].ToString()!="")
				{
					model.DisplayOrder=int.Parse(ds.Tables[0].Rows[0]["DisplayOrder"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["ParentNodeId"].ToString()!="")
				{
					model.ParentNodeId=int.Parse(ds.Tables[0].Rows[0]["ParentNodeId"].ToString());
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
			strSql.Append(" FROM SysFun ");
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
			strSql.Append(" FROM SysFun ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

