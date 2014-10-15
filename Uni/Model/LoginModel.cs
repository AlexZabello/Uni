using DataLayer.Core;
using DataLayer.Entity;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uni.Helpers;

namespace Uni.Model
{
    public class LoginModel : ILoginModel
    {
        public bool Login(string login, string pass)
        {
            App app = DataHelper.GetApp();
            UserRepository rep = new UserRepository(app);
            User user = new User() { Login = login, Password = pass };
            if (rep.Check(user))
            {
                return true;
            }
            return false;
        }
    }
}