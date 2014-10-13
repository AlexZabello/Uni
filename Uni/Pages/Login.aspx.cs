using DataLayer.Core;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uni.Helpers;
using DataLayer.Entity;
using System.Web.Security;
using System.Web.Routing;

namespace Uni.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string user = Request["name"];
                string password = Request["password"];
                string action = Request["action"];

                App app = DataHelper.GetApp();
                UserRepository rep = new UserRepository();
                rep.App = app;
                if (action == "login" && rep.Check(new User { Login = user, Password = password }))
                {
                    FormsAuthentication.RedirectFromLoginPage(user, false);
                    //FormsAuthentication.SetAuthCookie(user, false);
                    //string url = RouteTable.Routes.GetVirtualPath(null, "auth", new RouteValueDictionary()).VirtualPath;
                    //Response.Redirect(url);
                }
                else
                {
                    message.Style["visibility"] = "visible";
                }
            }
            if (Request.IsAuthenticated)
            {
                Response.StatusCode = 403;
                Response.SuppressContent = true;
                Context.ApplicationInstance.CompleteRequest();
            }
                

                //if (name != string.Empty && password != string.Empty && FormsAuthentication.Authenticate(name, password))
                //{
                    
                //    FormsAuthentication.SetAuthCookie(name, false);
                //    Response.Redirect("/Admin"); 
                //    //App app = DataHelper.GetApp();
                //    //UserRepository rep = new UserRepository();
                //    //rep.App = app;
                //    //User user = new DataLayer.Entity.User();
                //    //user.Login = name;
                //    //user.Password = password;
                //    //if (rep.Check(user))
                //    //{
                //    //    UserRole role = rep.GetUserRole(user);
                //    //    Response.Redirect("/" + role.Name);
                //    //}
                    
                //}
                //else
                //{
                //    ModelState.AddModelError("fail", "Login failed. Please try again");
                //}
            
        }

        protected string GetUser()
        {
            return Context.User.Identity.Name;
        }

        protected bool GetRequestStatus()
        {
            return Request.IsAuthenticated;
        }
    }
}