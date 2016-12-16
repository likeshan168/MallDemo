using lks.Mall.Utility;
using System;
using System.Collections.Generic;
using System.Data;
namespace lks.Mall.BLL
{
    //Orders
    public partial class OrdersService
	{
   		     
		private readonly lks.Mall.DAL.OrdersDAO dal=new lks.Mall.DAL.OrdersDAO();
		public OrdersService()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string OrderId)
		{
			return dal.Exists(OrderId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(lks.Mall.Model.Orders model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lks.Mall.Model.Orders model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string OrderId)
		{
			
			return dal.Delete(OrderId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lks.Mall.Model.Orders GetModel(string OrderId)
		{
			
			return dal.GetModel(OrderId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public lks.Mall.Model.Orders GetModelByCache(string OrderId)
		{
			
			string CacheKey = "OrdersModel-" + OrderId;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OrderId);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (lks.Mall.Model.Orders)objModel;
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
		public List<lks.Mall.Model.Orders> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lks.Mall.Model.Orders> DataTableToList(DataTable dt)
		{
			List<lks.Mall.Model.Orders> modelList = new List<lks.Mall.Model.Orders>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lks.Mall.Model.Orders model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lks.Mall.Model.Orders();					
																	model.OrderId= dt.Rows[n]["OrderId"].ToString();
																												if(dt.Rows[n]["OrderDate"].ToString()!="")
				{
					model.OrderDate=DateTime.Parse(dt.Rows[n]["OrderDate"].ToString());
				}
																																if(dt.Rows[n]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
				}
																																if(dt.Rows[n]["TotalPrice"].ToString()!="")
				{
					model.TotalPrice=decimal.Parse(dt.Rows[n]["TotalPrice"].ToString());
				}
																																				model.PostAddress= dt.Rows[n]["PostAddress"].ToString();
																												if(dt.Rows[n]["state"].ToString()!="")
				{
					model.state=int.Parse(dt.Rows[n]["state"].ToString());
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