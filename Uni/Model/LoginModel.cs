//-----------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DataLayer.Core;
    using DataLayer.Entity;
    using DataLayer.Repository;
    using Uni.Helpers;

    /// <summary>
    /// Login model
    /// </summary>
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