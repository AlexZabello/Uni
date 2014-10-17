//-----------------------------------------------------------------------
// <copyright file="Register.aspx.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DataLayer.Core;
    using DataLayer.Repository;
    using Uni.Helpers;
    
    /// <summary>
    /// Register Page
    /// </summary>
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                App app = DataHelper.GetApp();
                UserRepository rep = new UserRepository(app);

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