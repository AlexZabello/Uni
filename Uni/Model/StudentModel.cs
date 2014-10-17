using DataLayer.Core;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uni.Helpers;

namespace Uni.Model
{
    public class StudentModel : IStudentModel
    {
        private App app = DataHelper.GetApp();
        private SubjectRepository subjectRepository;
        private GroupRepository groupRepository;
        private StudentRepository studentRepository;

        public StudentModel()
        {
            subjectRepository = new SubjectRepository(app);
            groupRepository = new GroupRepository(app);
            studentRepository = new StudentRepository(app);
        }

        public IEnumerable<DataLayer.Entity.Subject> GetSubjects()
        {
            return subjectRepository.GetAll();
        }

        public IEnumerable<DataLayer.Entity.Group> GetGroups()
        {
            return groupRepository.GetAll();
        }

        public IEnumerable<DataLayer.Entity.Student> GetStudents(string firstName, string lastName, int? idSubject, int? idGroup)
        {
            //IEnumerable<DataLayer.Entity.Student> studs =
            return studentRepository.SearchStudent(firstName, lastName, idSubject, idGroup);

            //List<Uni.Models.Student> list = new List<Uni.Models.Student>();
            //foreach (DataLayer.Entity.Student stud in studs)
            //{
            //    Uni.Models.Student model = new Uni.Models.Student();
            //    model.StudentId = stud.StudentId;
            //    model.FirstName = stud.FirstName;
            //    model.LastName = stud.LastName;
            //    model.SubjectId = stud.SubjectId;
            //    model.SubjectName = stud.Subject.Name;
            //    if (stud.Group != null)
            //    {
            //        model.GroupId = stud.Group.GroupId;
            //        model.GroupName = stud.Group.Name;
            //        model.ProfName = string.Format("{0} {1}", stud.Group.Prof.FirstName, stud.Group.Prof.LastName);
            //    }
            //    list.Add(model);
            //}
            //return list;
        }
    }
}