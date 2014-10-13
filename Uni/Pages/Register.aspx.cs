using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer.Core;
using Uni.Helpers;
using DataLayer.Repository;
using System.Web.Security;

namespace Uni.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                App app = DataHelper.GetApp();
                UserRepository rep = new UserRepository();
                rep.App = app;

                DataLayer.Entity.User user = new DataLayer.Entity.User();
                user.Login = txtLogin.Text;
                user.Password = txtPassword.Text;

                if (rep.Insert(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Login, false);
                    Response.RedirectToRoute("auth");
                }
            }
        }
    }
}