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

namespace Uni.Pages.Teacher
{
    public partial class AssignStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                repeaterGroup.DataSource = GetStudentsInGroup();
                repeaterGroup.DataBind();
                DDLGroup.DataSource = GetGroups();
                DDLGroup.DataBind();
                DDLGroup.SelectedIndex = -1;
            }
        }

        public System.Collections.IEnumerable GetStudents()
        {
            App app = DataHelper.GetApp();
            StudentRepository rep = new StudentRepository();
            rep.App = app;

            
            return rep.GetAll().Where(p=>p.Group == null);
        }

        public IEnumerable<Group> GetGroups()
        {
            App app = DataHelper.GetApp();
            TeacherRepository tRep = new TeacherRepository();
            tRep.App = app;
            DataLayer.Entity.Teacher t = tRep.GetByUser(new DataLayer.Entity.User() { Login = User.Identity.Name });
            GroupRepository rep = new GroupRepository();
            rep.App = app;
            IEnumerable<Group> g = rep.GetAllForSubject(new Subject(){ SubjectId = t.SubjectId});
            return g;
        }

        protected void DDLGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            repeaterGroup.DataSource = null;
            repeaterGroup.DataSource = GetStudentsInGroup();
            repeaterGroup.DataBind();
        }

        public IEnumerable<Student> GetStudentsInGroup()
        {
            App app = DataHelper.GetApp();
            StudentRepository rep = new StudentRepository();
            rep.App = app;
            int id = 0;
            if (DDLGroup.Items.Count >0)
            {
                id = Convert.ToInt32(DDLGroup.SelectedValue);
            }

            return rep.GetAll().Where(p => (p.Group != null && p.Group.GroupId == id));
        }

        protected void bLeft_Click(object sender, EventArgs e)
        {
            App app = DataHelper.GetApp();
            StudentRepository rep = new StudentRepository();
            rep.App = app;

            
        }

        protected void bRight_Click(object sender, EventArgs e)
        {

        }

    }
}