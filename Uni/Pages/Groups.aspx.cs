//-----------------------------------------------------------------------
// <copyright file="Groups.aspx.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DataLayer.Core;
    using DataLayer.Entity;
    using DataLayer.Repository;
    using Uni.Helpers;
    using Uni.Models;
    
    /// <summary>
    /// Groups Page
    /// </summary>
    public partial class Groups : System.Web.UI.Page
    {
        public IEnumerable<Uni.Models.GroupViewModel> GetGroups()
        {
            App app = DataHelper.GetApp();
            GroupRepository groupRepository = new GroupRepository(app);
            
            IEnumerable<Group> groups = groupRepository.GetAll();

            List<GroupViewModel> list = new List<GroupViewModel>();
            foreach (Group group in groups)
            {
                GroupViewModel model = new GroupViewModel();
                model.GroupId = group.GroupId;
                model.Name = group.Name;
                model.ProfName = string.Format("{0} {1}", group.Prof.FirstName, group.Prof.LastName);
                model.SubjectName = group.Subject.Name;
                list.Add(model);
            }

            return list;
        }

        public int GroupCount()
        {
            return this.Repeater1.Items.Count;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}