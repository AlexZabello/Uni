using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Subject : IItem
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
    }
}
