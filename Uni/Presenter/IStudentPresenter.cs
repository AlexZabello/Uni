using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni.Presenter
{
    public interface IStudentPresenter
    {
        IStudentRepository StudentRepository { get; set; }
        IEnumerable<Uni.Models.StudentViewModel> GetStudents();
    }
}