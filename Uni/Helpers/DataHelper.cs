using DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Uni.Helpers
{
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