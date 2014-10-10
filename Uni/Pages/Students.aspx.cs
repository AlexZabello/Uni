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
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = GetStudents();
                Repeater1.DataBind();
                DDLSubject.DataSource = GetSubjects();
                DDLSubject.DataBind();
                DDLSubject.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                DDLSubject.SelectedIndex = 0;

                DDLGroup.DataSource = GetGroup();
                DDLGroup.DataBind();
                DDLGroup.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                DDLGroup.SelectedIndex = 0;
            }
        }

        public IEnumerable<StudentModel> GetStudents()
        {
            return GetStudents(null, null, null, null);
        }

        public IEnumerable<StudentModel> GetStudents(string fName, string lName, int? idSubject, int? idGroup)
        {
            App app = DataHelper.GetApp();
            StudentRepository rep = new StudentRepository();
            rep.App = app;

            IEnumerable<DataLayer.Entity.Student> studs = rep.SearchStudent(fName, lName, idSubject, idGroup);

            List<StudentModel> list = new List<StudentModel>();
            foreach (DataLayer.Entity.Student stud in studs)
            {
                StudentModel model = new StudentModel();
                model.StudentId = stud.StudentId;
                model.FirstName = stud.FirstName;
                model.LastName = stud.LastName;
                model.SubjectId = stud.SubjectId;
                model.SubjectName = stud.Subject.Name;
                if (stud.Group != null)
                {
                    model.GroupId = stud.Group.GroupId;
                    model.GroupName = stud.Group.Name;
                    model.ProfName = string.Format("{0} {1}", stud.Group.Prof.FirstName, stud.Group.Prof.LastName);
                }
                list.Add(model);
            }
            return list;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            App app = DataHelper.GetApp();
            SubjectRepository rep = new SubjectRepository();
            rep.App = app;

            return rep.GetAll();
        }

        public IEnumerable<Group> GetGroup()
        {
            App app = DataHelper.GetApp();
            GroupRepository rep = new GroupRepository();
            rep.App = app;
            IEnumerable<Group> g = rep.GetAll();
            return g;
        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
            string fname = fName.Text;
            string lname = lName.Text;
            int? idSubject;
            if (DDLSubject.SelectedValue == "")
            {
                idSubject = null;
            }
            else
            {
                idSubject = Convert.ToInt32(DDLSubject.SelectedValue);
            }
            int? idGroup;
            if (DDLGroup.SelectedValue == "")
            {
                idGroup = null;
            }
            else
            {
                idGroup = Convert.ToInt32(DDLGroup.SelectedValue);
            }
            Repeater1.DataSource = null;
            Repeater1.DataSource = GetStudents(fname, lname, idSubject, idGroup);
            Repeater1.DataBind();
        }
    }
}