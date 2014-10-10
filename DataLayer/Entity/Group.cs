using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Group : IItem
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int SubjectId 
        {
            get
            {
                return Subject.SubjectId;
            }
            set
            {
                Subject.SubjectId = value;
            }
        }
        public Subject Subject { get; set; }

        public int TeacherId
        {
            get
            {
                return Prof.TeacherId;
            }
            set
            {
                Prof.TeacherId = value;
            }
        }
        public Teacher Prof { get; set; }
    }
}
