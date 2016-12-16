using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.BLL
{
    //BookComment
    public partial class BookCommentService
    {

        private readonly DAL.BookCommentDAO dal = new DAL.BookCommentDAO();
        public BookCommentService()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.BookComment model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.BookComment model)
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
        public lks.Mall.Model.BookComment GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public lks.Mall.Model.BookComment GetModelByCache(int Id)
        {

            string CacheKey = "BookCommentModel-" + Id;
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
            return (lks.Mall.Model.BookComment)objModel;
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
        public List<lks.Mall.Model.BookComment> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lks.Mall.Model.BookComment> DataTableToList(DataTable dt)
        {
            List<lks.Mall.Model.BookComment> modelList = new List<lks.Mall.Model.BookComment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lks.Mall.Model.BookComment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lks.Mall.Model.BookComment();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Msg = dt.Rows[n]["Msg"].ToString();
                    if (dt.Rows[n]["CreateDateTime"].ToString() != "")
                    {
                        model.CreateDateTime = DateTime.Parse(dt.Rows[n]["CreateDateTime"].ToString());
                    }
                    if (dt.Rows[n]["BookId"].ToString() != "")
                    {
                        model.BookId = int.Parse(dt.Rows[n]["BookId"].ToString());
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