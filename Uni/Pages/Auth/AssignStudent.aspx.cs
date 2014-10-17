//-----------------------------------------------------------------------
// <copyright file="AssignStudent.aspx.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Pages.Teacher
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

    /// <summary>
    /// Assign Student Page
    /// </summary>
    public partial class AssignStudent : System.Web.UI.Page
    {
        public System.Collections.IEnumerable GetStudents()
        {
            App app = DataHelper.GetApp();
            StudentRepository rep = new StudentRepository(app);
            
            return rep.GetAll().Where(p => p.Group == null);
        }

        public IEnumerable<Group> GetGroups()
        {
            App app = DataHelper.GetApp();
            TeacherRepository teacherRepository = new TeacherRepository(app);
            DataLayer.Entity.Teacher t = teacherRepository.GetByUser(new DataLayer.Entity.User() { Login = User.Identity.Name });
            GroupRepository rep = new GroupRepository(app);
            IEnumerable<Group> g = rep.GetAllForSubject(new Subject() { SubjectId = t.SubjectId });
            return g;
        }

        public IEnumerable<Student> GetStudentsInGroup()
        {
            App app = DataHelper.GetApp();
            StudentRepository rep = new StudentRepository(app);
            
            int id = 0;
            if (DDLGroup.Items.Count > 0)
            {
                id = Convert.ToInt32(DDLGroup.SelectedValue);
            }

            return rep.GetAll().Where(p => (p.Group != null && p.Group.GroupId == id));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.repeaterGroup.DataSource = this.GetStudentsInGroup();
                this.repeaterGroup.DataBind();
                this.DDLGroup.DataSource = this.GetGroups();
                this.DDLGroup.DataBind();
                this.DDLGroup.SelectedIndex = -1;
            }
        }

        protected void DDLGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            repeaterGroup.DataSource = null;
            repeaterGroup.DataSource = this.GetStudentsInGroup();
            repeaterGroup.DataBind();
        }

        protected void OnButtonLeft_Click(object sender, EventArgs e)
        {
            App app = DataHelper.GetApp();
            StudentRepository rep = new StudentRepository(app);
        }

        protected void OnButtonRight_Click(object sender, EventArgs e)
        {
        }
    }
}