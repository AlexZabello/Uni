using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class User : IItem
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public int UserRoleId { get; set; }
        public string Password { get; set; }
    }
}
