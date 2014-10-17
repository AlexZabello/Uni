//-----------------------------------------------------------------------
// <copyright file="Student.aspx.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Pages.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DataLayer.Core;
    using DataLayer.Entity;
    using DataLayer.Repository;
    using Uni.Helpers;
    using Uni.Models;

    /// <summary>
    /// Student Page
    /// </summary>
    public partial class Student : System.Web.UI.Page
    {
        public IEnumerable<DataLayer.Entity.Student> GetStudents()
        {
            App app = Uni.Helpers.DataHelper.GetApp();
            StudentRepository rep = new StudentRepository(app);

            return rep.GetAll();
        }

        public void InsertStudent()
        {
            DataLayer.Entity.Student stud = new DataLayer.Entity.Student();
            if (Page.TryUpdateModel(stud))
            {
                App app = Uni.Helpers.DataHelper.GetApp();
                StudentRepository rep = new StudentRepository(app);
                bool res = rep.Insert(stud);
            }
        }

        public void UpdateStudent()
        {
            DataLayer.Entity.Student stud = new DataLayer.Entity.Student();
            if (Page.TryUpdateModel(stud))
            {
                App app = Uni.Helpers.DataHelper.GetApp();
                StudentRepository rep = new StudentRepository(app);
                
                bool res = rep.Update(stud);
            }
        }

        public void DeleteStudent()
        {
            DataLayer.Entity.Student stud = new DataLayer.Entity.Student();
            if (Page.TryUpdateModel(stud))
            {
                App app = Uni.Helpers.DataHelper.GetApp();
                StudentRepository rep = new StudentRepository(app);
                
                bool res = rep.Delete(stud.StudentId);
            }
        }

        public IEnumerable<Subject> GetSubjects()
        {
            App app = DataHelper.GetApp();
            SubjectRepository rep = new SubjectRepository(app);

            return rep.GetAll();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}