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

namespace Uni.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string name = Request.Form["name"];
                string password = Request.Form["password"];
                if (name != string.Empty && password != string.Empty && FormsAuthentication.Authenticate(name, password))
                {
                    
                    FormsAuthentication.SetAuthCookie(name, false);
                    Response.Redirect("/Admin"); 
                    //App app = DataHelper.GetApp();
                    //UserRepository rep = new UserRepository();
                    //rep.App = app;
                    //User user = new DataLayer.Entity.User();
                    //user.Login = name;
                    //user.Password = password;
                    //if (rep.Check(user))
                    //{
                    //    UserRole role = rep.GetUserRole(user);
                    //    Response.Redirect("/" + role.Name);
                    //}
                    
                }
                else
                {
                    ModelState.AddModelError("fail", "Login failed. Please try again");
                }
            }
        }
    }
}