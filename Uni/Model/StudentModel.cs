//-----------------------------------------------------------------------
// <copyright file="StudentModel.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DataLayer.Core;
    using DataLayer.Repository;
    using Uni.Helpers;

    /// <summary>
    /// Student model
    /// </summary>
    public class StudentModel : IStudentModel
    {
        private App app = DataHelper.GetApp();

        /// <summary>
        /// Subject repository
        /// </summary>
        private SubjectRepository subjectRepository;

        /// <summary>
        /// Group repository
        /// </summary>
        private GroupRepository groupRepository;

        /// <summary>
        /// Student repository
        /// </summary>
        private StudentRepository studentRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public StudentModel()
        {
            this.subjectRepository = new SubjectRepository(this.app);
            this.groupRepository = new GroupRepository(this.app);
            this.studentRepository = new StudentRepository(this.app);
        }

        public IEnumerable<DataLayer.Entity.Subject> GetSubjects()
        {
            return this.subjectRepository.GetAll();
        }

        public IEnumerable<DataLayer.Entity.Group> GetGroups()
        {
            return this.groupRepository.GetAll();
        }

        public IEnumerable<DataLayer.Entity.Student> GetStudents(string firstName, string lastName, int? idSubject, int? idGroup)
        {
            ////IEnumerable<DataLayer.Entity.Student> studs =
            return this.studentRepository.SearchStudent(firstName, lastName, idSubject, idGroup);

            /*
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
             */
        }
    }
}