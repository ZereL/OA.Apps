using Apps.DAL;
using Apps.IBLL;
using Apps.IDAL;
using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BLL
{
    public class SysSampleBLL : ISysSampleBLL
    {
        DBContainer db = new DBContainer();
        ISysSampleRepository Rep = new SysSampleRepository();
        /// <summary>
        /// GetList
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        public List<SysSample> GetList(string queryStr)
        {
            List<SysSample> queryData =  Rep.GetList(db).ToList();
            return queryData;
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Create(SysSample entity)
        {
            return Rep.Create(entity) > 0;
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            try
            {
                if (Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Edit(SysSample entity)
        {
            try
            {
                if (Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {

                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// Check if model exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExists(string id)
        {
            if (db.SysSample.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Get Model by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysSample GetById(string id)
        {
            if (IsExist(id))
            {
                SysSample entity = Rep.GetById(id);


                return entity;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Check if model exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }
    }
}
