using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using MVC_Ajax请求数据;

namespace MVC_Ajax请求数据.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Ajax()
        {
            return View();
        }

        #region mvc中ajax必须返回jsonresult  否则会执行错误代码
        [HttpPost]
        public JsonResultModel<IEnumerable<People>> AjaxGet(int id, string name)
        {
            List<People> peoples = new List<People>();
            People p1 = new People();
            p1.Id = id;
            p1.name = name;
            People p2 = new People();
            p2.Id = 2;
            p2.name = "lg";
            peoples.Add(p1);
            peoples.Add(p2);
            return JsonResultModel<IEnumerable<People>>.ReturnSuccess(peoples);


        }
        [HttpGet]
        public JsonResultModel<IEnumerable<People>> AjaxGet()
        {
            List<People> peoples = new List<People>();
            People p1 = new People();
            p1.Id = 1;
            p1.name = "ly";
            People p2 = new People();
            p2.Id = 2;
            p2.name = "lg";
            peoples.Add(p1);
            peoples.Add(p2);
            return JsonResultModel<IEnumerable<People>>.ReturnSuccess(peoples);


        } 
        #endregion
        [HttpPost]
        public JsonResult JsonGet(int id, string name)
        {
            List<People> peoples = new List<People>();
            People p1 = new People();
            p1.Id = id;
            p1.name = name;
            People p2 = new People();
            p2.Id = 2;
            p2.name = "lg";
            peoples.Add(p1);
            peoples.Add(p2);
            return Json(new { data = peoples, result = "true" }, JsonRequestBehavior.AllowGet);


        }
        [HttpGet]
        public JsonResult Json()
        {
            List<People> peoples = new List<People>();
            People p1 = new People();
            p1.Id = 1;
            p1.name = "ly";
            People p2 = new People();
            p2.Id = 2;
            p2.name = "lg";
            peoples.Add(p1);
            peoples.Add(p2);
            return Json(new { peoples, result = "true" }, JsonRequestBehavior.AllowGet);


        }
        [DataContract]
        public class People
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string name { get; set; }

        }
    }

}
