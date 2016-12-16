using System;
using System.Collections.Generic;
using System.Data;
using lks.Mall.Utility;

namespace lks.Mall.BLL
{
    //1
    public partial class UserStatesService
    {

        private readonly lks.Mall.DAL.UserStatesDAO dal = new lks.Mall.DAL.UserStatesDAO();
        public UserStatesService()
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
        public int Add(lks.Mall.Model.UserStates model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lks.Mall.Model.UserStates model)
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
        public lks.Mall.Model.UserStates GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public lks.Mall.Model.UserStates GetModelByCache(int Id)
        {

            string CacheKey = "UserStatesModel-" + Id;
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
            return (lks.Mall.Model.UserStates)objModel;
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
        public List<lks.Mall.Model.UserStates> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lks.Mall.Model.UserStates> DataTableToList(DataTable dt)
        {
            List<lks.Mall.Model.UserStates> modelList = new List<lks.Mall.Model.UserStates>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lks.Mall.Model.UserStates model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lks.Mall.Model.UserStates();
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