//-----------------------------------------------------------------------
// <copyright file="Login.aspx.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DataLayer.Core;
    using DataLayer.Entity;
    using DataLayer.Repository;
    using Uni.Helpers;
    using Uni.Presenter;
    using Uni.View;

    /// <summary>
    /// Login page
    /// </summary>
    public partial class Login : System.Web.UI.Page, ILoginView
    {
        /// <summary>
        /// Gets or sets login name
        /// </summary>
        public string LoginName
        {
            get
            {
                return txtName.Text;
            }

            set
            {
                txtName.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets password
        /// </summary>
        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
            
            set
            {
                txtPassword.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            #region For Delete
            /*
            if (IsPostBack)
            {
                string user = Request["name"];
                string password = Request["password"];
                string action = Request["action"];

                App app = DataHelper.GetApp();
                UserRepository rep = new UserRepository(app);
                if (action == "login" && rep.Check(new User { Login = user, Password = password }))
                {

                    //FormsAuthentication.SetAuthCookie(user, false);
                    //string url = RouteTable.Routes.GetVirtualPath(null, "auth", new RouteValueDictionary()).VirtualPath;
                    //Response.Redirect(url);
                }
                else
                {

                }
            }
            if (Request.IsAuthenticated)
            {
                Response.StatusCode = 403;
                Response.SuppressContent = true;
                Context.ApplicationInstance.CompleteRequest();
            }

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
            */
            #endregion //For Delete
        }

        protected string GetUser()
        {
            return Context.User.Identity.Name;
        }

        protected bool GetRequestStatus()
        {
            return Request.IsAuthenticated;
        }

        protected void OnButtonLogin_Click(object sender, EventArgs e)
        {
            LoginPresenter presenter = new LoginPresenter(this);

            if (presenter.Login())
            {
                FormsAuthentication.RedirectFromLoginPage(this.txtName.Text, false);
            }
            else
            {
                this.message.Style["visibility"] = "visible";
            }
        }
    }
}