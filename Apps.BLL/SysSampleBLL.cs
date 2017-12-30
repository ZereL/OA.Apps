using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Apps.Models;
using Apps.Common;
using Apps.Models.Sys;
using Apps.IBLL;
using Apps.IDAL;

namespace Apps.BLL
{
    public class SysSampleBLL : ISysSampleBLL
    {
        DBContainer db = new DBContainer();
        [Dependency]
        public ISysSampleRepository Rep { get; set; }
        /// <summary>
        /// GetList
        /// </summary>
        /// <param name="queryStr">query</param>
        /// <returns>List<T></returns>
        public List<SysSampleModel> GetList(ref GridPager pager)
        {

            IQueryable<SysSample> queryData = null;
            queryData = Rep.GetList(db);

            //排序
            if (pager.order == "desc")
            {
                switch (pager.order)
                {
                    case "Id":
                        queryData = queryData.OrderByDescending(c => c.Id);
                        break;
                    case "Name":
                        queryData = queryData.OrderByDescending(c => c.Name);
                        break;
                    default:
                        queryData = queryData.OrderByDescending(c => c.CreateTime);
                        break;
                }
            }
            else
            {

                switch (pager.order)
                {
                    case "Id":
                        queryData = queryData.OrderBy(c => c.Id);
                        break;
                    case "Name":
                        queryData = queryData.OrderBy(c => c.Name);
                        break;
                    default:
                        queryData = queryData.OrderBy(c => c.CreateTime);
                        break;
                }
            }
            return CreateModelList(ref pager, ref queryData);
        }
        /// <summary>
        /// Create Model List
        /// </summary>
        /// <param name="queryData">Generate the list</param>
        /// <returns>List</returns>
        private List<SysSampleModel> CreateModelList(ref GridPager pager, ref IQueryable<SysSample> queryData)
        {

            pager.totalRows = queryData.Count();
            if (pager.totalRows > 0)
            {
                if (pager.page <= 1)
                {
                    queryData = queryData.Take(pager.totalRows);
                }
                else
                {
                    queryData = queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
                }
            }
            List<SysSampleModel> modelList = (from r in queryData
                                              select new SysSampleModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  Age = r.Age,
                                                  Bir = r.Bir,
                                                  Photo = r.Photo,
                                                  Note = r.Note,
                                                  CreateTime = r.CreateTime,

                                              }).ToList();

            return modelList;
        }

        /// <summary>
        /// Create a model 
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>true or false</returns>
        public bool Create(SysSampleModel model)
        {
            try
            {
                SysSample entity = Rep.GetById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysSample();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = model.CreateTime;

                if (Rep.Create(entity) == 1)
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
        /// Delete model
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>true or false</returns>
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
                return false;
            }
        }

        /// <summary>
        /// Edit model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>true or false</returns>
        public bool Edit(SysSampleModel model)
        {
            try
            {
                SysSample entity = Rep.GetById(model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;


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
        /// check model exist
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>true or false</returns>
        public bool IsExists(string id)
        {
            if (db.SysSample.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// return model by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Model</returns>
        public SysSampleModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysSample entity = Rep.GetById(id);
                SysSampleModel model = new SysSampleModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Age = entity.Age;
                model.Bir = entity.Bir;
                model.Photo = entity.Photo;
                model.Note = entity.Note;
                model.CreateTime = entity.CreateTime;

                return model;
            }
            else
            {
                return new SysSampleModel();
            }
        }

        /// <summary>
        /// Check isExist
        /// </summary>
        /// <param name="id">id</param>
        /// <returns> true or false</returns>
        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }
    }
}