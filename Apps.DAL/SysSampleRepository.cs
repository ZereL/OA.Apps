using Apps.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;

namespace Apps.DAL
{
    public class SysSampleRepository : ISysSampleRepository, IDisposable
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity">dbcontext</param>
        /// <returns></returns>
        public int Create(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysSample>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = db.SysSample.SingleOrDefault(a => a.Id == id);
                db.Set<SysSample>().Remove(entity);
                return db.SaveChanges();
            }
        }
        public void Dispose()
        {
            
        }
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Edit(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysSample.Attach(entity);
                db.Entry<SysSample>(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// Get Model By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysSample GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysSample.SingleOrDefault(a => a.Id == id);
            }
        }
        /// <summary>
        /// Get ModelList
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public IQueryable<SysSample> GetList(DBContainer db)
        {
            IQueryable<SysSample> list = db.SysSample.AsQueryable();
            return list;
        }
        /// <summary>
        /// Check if Model is exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = GetById(id);
                if (entity != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
