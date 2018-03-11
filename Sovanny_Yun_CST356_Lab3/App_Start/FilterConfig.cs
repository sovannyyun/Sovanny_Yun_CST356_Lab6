using System.Web;
using System.Web.Mvc;

namespace Sovanny_Yun_CST356_Lab3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
