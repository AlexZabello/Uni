using DataLayer.Core;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uni.Models;
using System.Web.ModelBinding;
using DataLayer.Entity;
using Uni.Helpers;

namespace Uni.Pages.Admin
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<DataLayer.Entity.Student> GetStudents()
        {
            App app = Uni.Helpers.DataHelper.GetApp();
            StudentRepository rep = new StudentRepository();
            rep.App = app;

            return rep.GetAll();
        }

        public void InsertStudent()
        {
            DataLayer.Entity.Student stud = new DataLayer.Entity.Student();
            if (TryUpdateModel(stud))
            {
                App app = Uni.Helpers.DataHelper.GetApp();
                StudentRepository rep = new StudentRepository();
                rep.App = app;
                bool res = rep.Insert(stud);
            }
        }

        public void UpdateStudent()
        {
            DataLayer.Entity.Student stud = new DataLayer.Entity.Student();
            if (TryUpdateModel(stud))
            {
                App app = Uni.Helpers.DataHelper.GetApp();
                StudentRepository rep = new StudentRepository();
                rep.App = app;
                bool res = rep.Update(stud);
            }
        }

        public void DeleteStudent()
        {
            DataLayer.Entity.Student stud = new DataLayer.Entity.Student();
            if (TryUpdateModel(stud))
            {
                App app = Uni.Helpers.DataHelper.GetApp();
                StudentRepository rep = new StudentRepository();
                rep.App = app;
                bool res = rep.Delete(stud.StudentId);
            }
        }

        public IEnumerable<Subject> GetSubjects()
        {
            App app = DataHelper.GetApp();
            SubjectRepository rep = new SubjectRepository();
            rep.App = app;

            return rep.GetAll();
        }
    }
}