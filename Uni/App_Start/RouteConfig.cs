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
            routes.MapPageRoute("admin", "admin", "~/Pages/Admin/Default.aspx", true);
            routes.MapPageRoute("teacher", "teacher", "~/Pages/Teacher/AssignStudent.aspx", true);
            routes.MapPageRoute("student", "student", "~/Pages/Students.aspx");
            routes.MapPageRoute(null, "admin/student", "~/Pages/Admin/Student.aspx");
        }
    }
}