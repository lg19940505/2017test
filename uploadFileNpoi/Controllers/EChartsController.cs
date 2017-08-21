using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uploadFileNpoi.Controllers
{
    public class EChartsController : Controller
    {
        //参考官网  http://echarts.baidu.com/
        // GET: ECharts
        public ActionResult Index()
        {
            return View();
        }
        //个性化图表
        public ActionResult Personal()
        {
            return View();
        }
        //异步加载
        public ActionResult async()
        {
            return View();
        }
        //更新
        public ActionResult updata()
        {
            return View();
        }

        //交互组件
        public ActionResult dataZoom()
        {
            return View();
        }
     
    }
}