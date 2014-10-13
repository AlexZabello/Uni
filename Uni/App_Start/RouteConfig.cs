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
            routes.MapPageRoute("admin", "admin", "~/Pages/Auth/Student.aspx", true);
            routes.MapPageRoute("teacher", "teacher", "~/Pages/Auth/AssignStudent.aspx", true);
            routes.MapPageRoute("students", "students", "~/Pages/Students.aspx");
            routes.MapPageRoute("groups", "groups", "~/Pages/Groups.aspx");
            routes.MapPageRoute("auth", "auth", "~/Pages/Default.aspx", true);
            routes.MapPageRoute("register", "register", "~/Pages/Register.aspx");
            routes.MapPageRoute("manageUsers", "manageUsers", "~/Pages/Auth/ManageUsers.aspx", true);
            //routes.MapPageRoute(null, "admin/student", "~/Pages/Admin/Student.aspx");
        }
    }
}