using System.Web;
using System.Web.Mvc;

namespace WEB_API_CRUD_LINQ_SQL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
