//-----------------------------------------------------------------------
// <copyright file="Site.master.cs" company="CompanyName">
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

    /// <summary>
    /// Site master page
    /// </summary>
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
                    this.authAction.InnerText = "Log Out";
                }
                else
                {
                    this.userName.Visible = false;
                    this.authAction.InnerText = "Log In";
                }
            }
            else if (Page.IsPostBack && Page.Request["authAction"] == "auth")
            {
                if (Page.Request.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Page.Response.Redirect(Page.Request.Path);
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            else if (Page.IsPostBack && Page.Request["authAction"] == "reg")
            {
                Response.RedirectToRoute("register");
            }
        }

        protected string GetUserName()
        {
            return Context.User.Identity.Name;
        }

        protected string GetStudentsUrl()
        {
            return RouteTable.Routes.GetVirtualPath(null, "students", new RouteValueDictionary() { { "students", null } }).VirtualPath;
        }

        protected string GetGroupsUrl()
        {
            return RouteTable.Routes.GetVirtualPath(null, "groups", new RouteValueDictionary() { { "groups", null } }).VirtualPath;
        }

        protected string GetContent()
        {
            if (Request.IsAuthenticated)
            {
                string menu = string.Empty;
          
                if (Page.User.IsInRole("admin"))
                {
                    menu = string.Format("<a href=\"{0}\">{1}</a>", RouteTable.Routes.GetVirtualPath(null, "admin", new RouteValueDictionary() { { "admin", null } }).VirtualPath, "Administrate");
                    menu += " " + string.Format("<a href=\"{0}\">{1}</a>", RouteTable.Routes.GetVirtualPath(null, "manageUsers", new RouteValueDictionary() { { "manageUsers", null } }).VirtualPath, "Manage Users");
                }
                else if (Page.User.IsInRole("teacher"))
                {
                    menu = string.Format("<a href=\"{0}\">{1}</a>", RouteTable.Routes.GetVirtualPath(null, "teacher", new RouteValueDictionary() { { "teacher", null } }).VirtualPath, "Managing");
                }

                return HttpUtility.HtmlDecode(menu);
            }

            return string.Empty;
        }
    }
}