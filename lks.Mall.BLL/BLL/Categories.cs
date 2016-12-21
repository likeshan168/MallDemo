using System;
using System.Collections.Generic;
using System.Data;
using lks.Mall.DAL;
using lks.Mall.Model;
using lks.Mall.Utility;
namespace lks.Mall.BLL
{
    //Categories
    public partial class CategoriesService
    {

        private readonly CategoriesDAO dal = new CategoriesDAO();
        public CategoriesService()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id, string Name)
        {
            return dal.Exists(Id, Name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Categories model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Categories model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Categories GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Categories GetModelByCache(int Id)
        {

            string CacheKey = "CategoriesModel-" + Id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Categories)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Categories> QueryList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获取指定页的数据列表
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">每一页显示的条数</param>
        /// <param name="wheres">查询条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <returns>数据列表</returns>
        public IEnumerable<Categories> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        {
            return dal.QueryList(index, size, wheres, orderField, isDesc);
        }
        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>单条数据项</returns>
        public Categories QuerySingle(object wheres)
        {
            return dal.QuerySingle(wheres);
        }
        /// <summary>
        /// 查询总数
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>总数目</returns>
        public int QueryCount(object wheres)
        {
            return dal.QueryCount(wheres);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Categories> DataTableToList(DataTable dt)
        {
            List<Categories> modelList = new List<Categories>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Categories model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Categories();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();


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