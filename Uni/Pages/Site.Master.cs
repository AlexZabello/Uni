using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Routing;

namespace Uni.Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
                    authAction.InnerText = "Log Out";
                }
                else
                {
                    userName.Visible = false;
                    authAction.InnerText = "Log In";
                }
            }
            else if (IsPostBack && Request["authAction"] == "auth")
            {
                if (Request.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect(Request.Path);
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            else if (IsPostBack && Request["authAction"] == "reg")
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