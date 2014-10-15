using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni.View
{
    public interface IStudentView : IView
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int? IdSubject { get; set; }
        int? IdGroup { get; set; }
    }
}