using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.BLL;
using Apps.IBLL;
using Apps.Models;
using Apps.Models.Sys;
using Microsoft.Practices.Unity;

namespace Apps.Web.Controllers
{
    public class SysSampleController : Controller
    {
        //
        // GET: /SysSample/
        /// <summary>
        /// Inject BLL
        /// </summary>
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }
        public ActionResult Index()
        {
            List<SysSampleModel> list = m_BLL.GetList("");
            return View(list);
        }

        [HttpPost]
        public JsonResult GetList()
        {
            List<SysSampleModel> list = m_BLL.GetList("");
            var json = new
            {
                total = list.Count,
                //GetList by linq to object
                rows = (from r in list
                        select new SysSampleModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime,

                        }).ToArray()
                //GetList by lambda
                //rows = list.Where(r => r.Id != "").Select(r => new SysSampleModel()
                //{
                //    Id = r.Id,
                //    Name = r.Name,
                //    Age = r.Age,
                //    Bir = r.Bir,
                //    Photo = r.Photo,
                //    Note = r.Note,
                //    CreateTime = r.CreateTime,
                //}).ToArray()
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}