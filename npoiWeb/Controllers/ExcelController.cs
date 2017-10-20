using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace npoiWeb.Controllers
{
    public class ExcelController : Controller
    {
        // 基本的excel文件
        public ActionResult Index()
        {
            #region 创建基本的excel文件
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            hssfworkbook.CreateSheet("mySheet1");

            hssfworkbook.CreateSheet("mySheet2");

            hssfworkbook.CreateSheet("mySheet3");

            string path = Server.MapPath("/");

            FileStream file = new FileStream(path + "\\test.xls", FileMode.Create);

            hssfworkbook.Write(file);

            file.Close(); 
            #endregion

            ViewBag.data ="success";
            return View();
        }

        //DocummentSummaryInformation和SummaryInformation
        public ActionResult Index2()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            SummaryInformation  si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.DocumentSummaryInformation = dsi;
            hssfworkbook.SummaryInformation = si;

            hssfworkbook.CreateSheet("mySheet1");

            hssfworkbook.CreateSheet("mySheet2");

            hssfworkbook.CreateSheet("mySheet3");

            string path = Server.MapPath("/");

            FileStream file = new FileStream(path + "\\test1_2.xls", FileMode.Create);

            hssfworkbook.Write(file);

            file.Close();

            return View();
        }
    }
}