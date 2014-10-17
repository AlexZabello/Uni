using DataLayer.Core;
using DataLayer.Entity;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uni.Helpers;
using Uni.Model;
using Uni.View;

namespace Uni.Presenter
{
    public class StudentPresenter : Presenter<IStudentView>
    {
        public IStudentModel StudentModel { get; set; }

        public StudentPresenter(IStudentView view, IStudentModel model): base(view)
        {
            StudentModel = model;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return StudentModel.GetSubjects();
        }

        public IEnumerable<Group> GetGroup()
        {
            return StudentModel.GetGroups();
        }

        public IEnumerable<Uni.Models.StudentViewModel> GetStudents()
        {
            IEnumerable<DataLayer.Entity.Student> studs =
                StudentModel.GetStudents(view.FirstName, view.LastName, view.IdSubject, view.IdGroup);

            List<Uni.Models.StudentViewModel> list = new List<Uni.Models.StudentViewModel>();
            foreach (DataLayer.Entity.Student stud in studs)
            {
                Uni.Models.StudentViewModel model = new Uni.Models.StudentViewModel();
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
    }
}