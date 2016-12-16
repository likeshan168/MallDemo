using lks.Mall.Utility;
using System;
using System.Collections.Generic;
using System.Data;
namespace lks.Mall.BLL
{
    //1
    public partial class sysdiagramsService
	{
   		     
		private readonly lks.Mall.DAL.sysdiagramsDAO dal=new lks.Mall.DAL.sysdiagramsDAO();
		public sysdiagramsService()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string name,int principal_id,int diagram_id)
		{
			return dal.Exists(name,principal_id,diagram_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(lks.Mall.Model.sysdiagrams model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lks.Mall.Model.sysdiagrams model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int diagram_id)
		{
			
			return dal.Delete(diagram_id);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string diagram_idlist )
		{
			return dal.DeleteList(diagram_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lks.Mall.Model.sysdiagrams GetModel(int diagram_id)
		{
			
			return dal.GetModel(diagram_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public lks.Mall.Model.sysdiagrams GetModelByCache(int diagram_id)
		{
			
			string CacheKey = "sysdiagramsModel-" + diagram_id;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(diagram_id);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (lks.Mall.Model.sysdiagrams)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lks.Mall.Model.sysdiagrams> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lks.Mall.Model.sysdiagrams> DataTableToList(DataTable dt)
		{
			List<lks.Mall.Model.sysdiagrams> modelList = new List<lks.Mall.Model.sysdiagrams>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lks.Mall.Model.sysdiagrams model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lks.Mall.Model.sysdiagrams();					
																	model.name= dt.Rows[n]["name"].ToString();
																												if(dt.Rows[n]["principal_id"].ToString()!="")
				{
					model.principal_id=int.Parse(dt.Rows[n]["principal_id"].ToString());
				}
																																if(dt.Rows[n]["diagram_id"].ToString()!="")
				{
					model.diagram_id=int.Parse(dt.Rows[n]["diagram_id"].ToString());
				}
																																if(dt.Rows[n]["version"].ToString()!="")
				{
					model.version=int.Parse(dt.Rows[n]["version"].ToString());
				}
																																								if(dt.Rows[n]["definition"].ToString()!="")
				{
					model.definition= (byte[])dt.Rows[n]["definition"];
				}
																		
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}