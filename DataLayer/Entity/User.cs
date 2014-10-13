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
        public int? UserRoleId
        {
            get
            {
                if (UserRole != null)
                {
                    return UserRole.UserRoleId;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    if (UserRole == null)
                    {
                        UserRole = new UserRole();
                    }
                    UserRole.UserRoleId = value.Value;
                }
                
            }
        }
        public string Password { get; set; }

        public UserRole UserRole { get; set; }
    }
}
