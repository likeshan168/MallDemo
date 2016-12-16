using lks.Mall.Utility;
using System;
using System.Collections.Generic;
using System.Data;
namespace lks.Mall.BLL
{
    //SysFun
    public partial class SysFunService
	{
   		     
		private readonly lks.Mall.DAL.SysFunDAO dal=new lks.Mall.DAL.SysFunDAO();
		public SysFunService()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NodeId)
		{
			return dal.Exists(NodeId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(lks.Mall.Model.SysFun model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lks.Mall.Model.SysFun model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int NodeId)
		{
			
			return dal.Delete(NodeId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lks.Mall.Model.SysFun GetModel(int NodeId)
		{
			
			return dal.GetModel(NodeId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public lks.Mall.Model.SysFun GetModelByCache(int NodeId)
		{
			
			string CacheKey = "SysFunModel-" + NodeId;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NodeId);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (lks.Mall.Model.SysFun)objModel;
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
		public List<lks.Mall.Model.SysFun> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lks.Mall.Model.SysFun> DataTableToList(DataTable dt)
		{
			List<lks.Mall.Model.SysFun> modelList = new List<lks.Mall.Model.SysFun>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lks.Mall.Model.SysFun model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lks.Mall.Model.SysFun();					
													if(dt.Rows[n]["NodeId"].ToString()!="")
				{
					model.NodeId=int.Parse(dt.Rows[n]["NodeId"].ToString());
				}
																																				model.DisplayName= dt.Rows[n]["DisplayName"].ToString();
																																model.NodeURL= dt.Rows[n]["NodeURL"].ToString();
																												if(dt.Rows[n]["DisplayOrder"].ToString()!="")
				{
					model.DisplayOrder=int.Parse(dt.Rows[n]["DisplayOrder"].ToString());
				}
																																if(dt.Rows[n]["ParentNodeId"].ToString()!="")
				{
					model.ParentNodeId=int.Parse(dt.Rows[n]["ParentNodeId"].ToString());
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