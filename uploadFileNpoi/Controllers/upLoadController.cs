using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uploadFileNpoi.Controllers
{
    public class upLoadController : Controller
    {
        // GET: upLoad
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFile()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string dir = Server.MapPath("/") + "IFiles";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmSS") +files[0].FileName;
            files[0].SaveAs(dir +"/"+ fileName);
            return Json(new { src =  "/IFiles/" + fileName },JsonRequestBehavior.AllowGet);
        }
    }
}