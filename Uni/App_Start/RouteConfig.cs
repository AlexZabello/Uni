using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Uni.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("admin", "admin", "~/Pages/Admin/Default.aspx");
            routes.MapPageRoute("teacher", "teacher", "~/Pages/Teacher/Default.aspx");
            routes.MapPageRoute("student", "student", "~/Pages/Student/Default.aspx");
            routes.MapPageRoute(null, "admin/student", "~/Pages/Admin/Student.aspx");
        }
    }
}