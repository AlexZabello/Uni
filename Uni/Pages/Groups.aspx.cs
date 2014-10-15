using DataLayer.Core;
using DataLayer.Entity;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uni.Helpers;
using Uni.Models;

namespace Uni.Pages
{
    public partial class Groups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Uni.Models.GroupModel> GetGroups()
        {
            App app = DataHelper.GetApp();
            GroupRepository rep = new GroupRepository(app);
            

            IEnumerable<Group> groups = rep.GetAll();

            List<GroupModel> list = new List<GroupModel>();
            foreach (Group gr in groups)
            {
                GroupModel model = new GroupModel();
                model.GroupId = gr.GroupId;
                model.Name = gr.Name;
                model.ProfName = string.Format("{0} {1}", gr.Prof.FirstName, gr.Prof.LastName);
                model.SubjectName = gr.Subject.Name;

                list.Add(model);
            }
            return list;
        }

        public int GroupCount()
        {
            return Repeater1.Items.Count;
        }
    }
}