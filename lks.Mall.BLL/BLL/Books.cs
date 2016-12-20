using System;
using System.Collections.Generic;
using System.Data;
using lks.Mall.DAL;
using lks.Mall.Model;
using lks.Mall.Utility;
namespace lks.Mall.BLL
{
    //Books
    public partial class BooksService
    {

        private readonly BooksDAO dal = new BooksDAO();
        public BooksService()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id, string ISBN)
        {
            return dal.Exists(Id, ISBN);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lks.Mall.Model.Books model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lks.Mall.Model.Books model)
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
        public lks.Mall.Model.Books GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public lks.Mall.Model.Books GetModelByCache(int Id)
        {

            string CacheKey = "BooksModel-" + Id;
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
            return (lks.Mall.Model.Books)objModel;
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
        public List<Books> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public IEnumerable<Books> GetModelList(int index, int size, string wheres, string orderField, bool isDesc = true)
        {
            string sql = SqlHelper.GenerateQuerySql("Books", null, index, size, wheres, "Id", isDesc);
            return SqlHelper.GetList<Books>(sql, null);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Books> DataTableToList(DataTable dt)
        {
            List<lks.Mall.Model.Books> modelList = new List<Books>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lks.Mall.Model.Books model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lks.Mall.Model.Books();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.Author = dt.Rows[n]["Author"].ToString();
                    if (dt.Rows[n]["PublisherId"].ToString() != "")
                    {
                        model.PublisherId = int.Parse(dt.Rows[n]["PublisherId"].ToString());
                    }
                    if (dt.Rows[n]["PublishDate"].ToString() != "")
                    {
                        model.PublishDate = DateTime.Parse(dt.Rows[n]["PublishDate"].ToString());
                    }
                    model.ISBN = dt.Rows[n]["ISBN"].ToString();
                    if (dt.Rows[n]["WordsCount"].ToString() != "")
                    {
                        model.WordsCount = int.Parse(dt.Rows[n]["WordsCount"].ToString());
                    }
                    if (dt.Rows[n]["UnitPrice"].ToString() != "")
                    {
                        model.UnitPrice = decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
                    }
                    model.ContentDescription = dt.Rows[n]["ContentDescription"].ToString();
                    model.AurhorDescription = dt.Rows[n]["AurhorDescription"].ToString();
                    model.EditorComment = dt.Rows[n]["EditorComment"].ToString();
                    model.TOC = dt.Rows[n]["TOC"].ToString();
                    if (dt.Rows[n]["CategoryId"].ToString() != "")
                    {
                        model.CategoryId = int.Parse(dt.Rows[n]["CategoryId"].ToString());
                    }
                    if (dt.Rows[n]["Clicks"].ToString() != "")
                    {
                        model.Clicks = int.Parse(dt.Rows[n]["Clicks"].ToString());
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