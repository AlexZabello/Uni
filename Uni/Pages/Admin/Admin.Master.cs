using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uni.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
                    <a href='{0}'>Users</a>
            <a href='{1}'>Groups</a>
            <a href='{2}'>Students</a>
         * */
        protected List<string> GetThemes()
        {
            List<string> list = new List<string>();
            list.Add("Student");

            return list;
        }

        protected string CreateLink(string theme)
        {
            string path = Request.CurrentExecutionFilePath+ "/" + theme;

            return string.Format("<a href='{0}'>{1}</a>", path, theme);
        }

    }
}