using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.BLL
{
    //Articel_Words
    public partial class Articel_WordsService
    {

        private readonly lks.Mall.DAL.Articel_WordsDAO dal = new lks.Mall.DAL.Articel_WordsDAO();
        public Articel_WordsService()
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
        public int Add(lks.Mall.Model.Articel_Words model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lks.Mall.Model.Articel_Words model)
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
        public lks.Mall.Model.Articel_Words GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public lks.Mall.Model.Articel_Words GetModelByCache(int Id)
        {

            string CacheKey = "Articel_WordsModel-" + Id;
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
            return (lks.Mall.Model.Articel_Words)objModel;
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
        public List<lks.Mall.Model.Articel_Words> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lks.Mall.Model.Articel_Words> DataTableToList(DataTable dt)
        {
            List<lks.Mall.Model.Articel_Words> modelList = new List<lks.Mall.Model.Articel_Words>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lks.Mall.Model.Articel_Words model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lks.Mall.Model.Articel_Words();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.WordPattern = dt.Rows[n]["WordPattern"].ToString();
                    if (dt.Rows[n]["IsForbid"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsForbid"].ToString() == "1") || (dt.Rows[n]["IsForbid"].ToString().ToLower() == "true"))
                        {
                            model.IsForbid = true;
                        }
                        else
                        {
                            model.IsForbid = false;
                        }
                    }
                    if (dt.Rows[n]["IsMod"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsMod"].ToString() == "1") || (dt.Rows[n]["IsMod"].ToString().ToLower() == "true"))
                        {
                            model.IsMod = true;
                        }
                        else
                        {
                            model.IsMod = false;
                        }
                    }
                    model.ReplaceWord = dt.Rows[n]["ReplaceWord"].ToString();


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