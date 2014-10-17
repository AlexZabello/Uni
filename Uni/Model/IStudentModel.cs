//-----------------------------------------------------------------------
// <copyright file="IStudentModel.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DataLayer.Entity;

    /// <summary>
    /// Interface IStudentModel
    /// </summary>
    public interface IStudentModel
    {
        IEnumerable<Subject> GetSubjects();
        
        IEnumerable<Group> GetGroups();

        IEnumerable<Student> GetStudents(string firstName, string lastName, int? idSubject, int? idGroup);
    }
}