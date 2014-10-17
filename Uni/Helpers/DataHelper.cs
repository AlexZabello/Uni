//-----------------------------------------------------------------------
// <copyright file="DataHelper.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Configuration;
    using DataLayer.Core;

    /// <summary>
    /// Class for consolidation data logic
    /// </summary>
    public static class DataHelper
    {
        public static App GetApp()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Uni"].ConnectionString;
            App app = new App(connectionString);
            return app;
        }
    }
}