using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Uni.Models
{
    public class UserModel
    {
        [DefaultValue(1)]
        public int UserId { get; set; }
        public string Login { get; set; }
        public int? UserRoleId { get; set; }
        public string UserRole { get; set; }
    }
}