using DataLayer.Core;
using DataLayer.Entity;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uni.Helpers;
using Uni.View;

namespace Uni.Presenter
{
    public class StudentPresenter : Presenter<IStudentView>
    {
        public StudentPresenter(IStudentView view): base(view)
        {
        }

        public IEnumerable<Subject> GetSubjects()
        {
            SubjectRepository rep = new SubjectRepository(DataHelper.GetApp());
            return rep.GetAll();
        }

        public IEnumerable<Group> GetGroup()
        {
            GroupRepository rep = new GroupRepository(DataHelper.GetApp());

            return rep.GetAll();
        }

        public IEnumerable<Uni.Models.Student> GetStudents()
        {
            StudentRepository rep = new StudentRepository(DataHelper.GetApp());

            IEnumerable<DataLayer.Entity.Student> studs = 
                rep.SearchStudent(view.FirstName, view.LastName, view.IdSubject, view.IdGroup);

            List<Uni.Models.Student> list = new List<Uni.Models.Student>();
            foreach (DataLayer.Entity.Student stud in studs)
            {
                Uni.Models.Student model = new Uni.Models.Student();
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