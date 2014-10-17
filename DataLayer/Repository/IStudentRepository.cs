using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> SearchStudent(string firstName = null,
            string lastName = null, int? subjectId = null, int? groupId = null);
    }
}
