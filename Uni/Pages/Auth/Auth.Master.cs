﻿//-----------------------------------------------------------------------
// <copyright file="Auth.Master.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Pages.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Authentication Page
    /// </summary>
    public partial class Auth : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string GetContent()
        {
            if (Request.IsAuthenticated)
            {
                string menu = string.Empty;
                if (Page.User.IsInRole("admin"))
                {
                    menu = string.Format("<a href=\"{0}\">{1}</a>", RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "admin", null } }).VirtualPath, "Administrate");
                }
                else if (Page.User.IsInRole("teacher"))
                {
                    menu = string.Format("<a href=\"{0}\">{1}</a>", "teacher", "Managing");
                }

                return HttpUtility.HtmlDecode(menu);
            }

            return string.Empty;
        }
    }
}