//-----------------------------------------------------------------------
// <copyright file="StudentPresenter.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Presenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DataLayer.Core;
    using DataLayer.Entity;
    using DataLayer.Repository;
    using Uni.Helpers;
    using Uni.Model;
    using Uni.View;

    /// <summary>
    /// Student Presenter
    /// </summary>
    public class StudentPresenter : Presenter<IStudentView>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">IStudentView instance</param>
        /// <param name="model">IStudentModel instance</param>
        public StudentPresenter(IStudentView view, IStudentModel model) : base(view)
        {
            this.StudentModel = model;
        }

        /// <summary>
        /// Gets or sets StudentModel
        /// </summary>
        public IStudentModel StudentModel { get; set; }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.StudentModel.GetSubjects();
        }

        public IEnumerable<Group> GetGroup()
        {
            return this.StudentModel.GetGroups();
        }

        public IEnumerable<Uni.Models.StudentViewModel> GetStudents()
        {
            IEnumerable<DataLayer.Entity.Student> studentCollection =
                this.StudentModel.GetStudents(View.FirstName, View.LastName, View.IdSubject, View.IdGroup);

            List<Uni.Models.StudentViewModel> studentViewModelCollection = new List<Uni.Models.StudentViewModel>();
            foreach (DataLayer.Entity.Student student in studentCollection)
            {
                Uni.Models.StudentViewModel model = new Uni.Models.StudentViewModel();
                model.StudentId = student.StudentId;
                model.FirstName = student.FirstName;
                model.LastName = student.LastName;
                model.SubjectId = student.SubjectId;
                model.SubjectName = student.Subject.Name;
                if (student.Group != null)
                {
                    model.GroupId = student.Group.GroupId;
                    model.GroupName = student.Group.Name;
                    model.ProfName = string.Format("{0} {1}", student.Group.Prof.FirstName, student.Group.Prof.LastName);
                }

                studentViewModelCollection.Add(model);
            }
            
            return studentViewModelCollection;
        }
    }
}