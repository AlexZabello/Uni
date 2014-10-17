using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Entity;

namespace Uni.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string ProfName { get; set; }
    }
}