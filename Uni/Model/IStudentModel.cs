using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni.Model
{
    public interface IStudentModel
    {
        IEnumerable<Subject> GetSubjects();
        IEnumerable<Group> GetGroups();
        IEnumerable<Student> GetStudents(string firstName, string lastName, int? idSubject, int? idGroup);
    }
}