using System.Web;
using System.Web.Mvc;

namespace MVC_Ajax请求数据
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
