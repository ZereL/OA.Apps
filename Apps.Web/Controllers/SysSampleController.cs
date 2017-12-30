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
using Apps.Common;

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
            //List<SysSampleModel> list = m_BLL.GetList("");
            return View();
        }

        [HttpPost]
        public JsonResult GetList(GridPager pager)
        {
            int total = 0;
            List<SysSampleModel> list = m_BLL.GetList(ref pager);
            var json = new
            {
                total = list.Count,
                //rows = list直接这样就可以,不明白为什么返回的就是个list还要在controller在接一遍,在赋值一次
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