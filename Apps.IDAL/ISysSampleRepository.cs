using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IDAL
{
    public interface ISysSampleRepository
    {
        /// <summary>
        /// GetList
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        IQueryable<SysSample> GetList(DBContainer db);
        /// <summary>
        /// Create an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Create(SysSample entity);
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(string id);
        /// <summary>
        /// Edit an Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Edit(SysSample entity);
        /// <summary>
        /// Get an Entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysSample GetById(string id);
        /// <summary>
        /// Check if entity is Exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsExist(string id);
    }
}
