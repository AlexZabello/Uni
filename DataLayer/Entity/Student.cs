using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Student : IItem
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int SubjectId
        {
            get
            {
                if (Subject != null)
                {
                    return Subject.SubjectId;    
                }
                return 0;
            }
            set
            {
                if (Subject == null)
                {
                    Subject = new Subject();
                }
                Subject.SubjectId = value;
            }
        }
        public Subject Subject { get; set; }

        public Group Group { get; set; }

    }
}
