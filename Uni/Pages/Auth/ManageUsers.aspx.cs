//-----------------------------------------------------------------------
// <copyright file="ManageUsers.aspx.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Pages.Auth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DataLayer.Core;
    using DataLayer.Repository;
    using Uni.Helpers;
    using Uni.Models;

    /// <summary>
    /// Manage Users View
    /// </summary>
    public partial class ManageUsers : System.Web.UI.Page
    {
        public IEnumerable<UserViewModel> GetUsers()
        {
            App app = DataHelper.GetApp();
            UserRepository rep = new UserRepository(app);

            IEnumerable<DataLayer.Entity.User> l = rep.GetAll();
            List<UserViewModel> list = new List<UserViewModel>();

            foreach (DataLayer.Entity.User item in l)
            {
                UserViewModel m = new UserViewModel();
                m.UserId = item.UserId;
                m.Login = item.Login;
                m.UserRoleId = 0;
                
                if (item.UserRole != null)
                {
                    m.UserRoleId = item.UserRole.UserRoleId;
                    m.UserRole = item.UserRole.Name;
                }

                list.Add(m);
            }
            
            return list;
        }

        public IEnumerable<DataLayer.Entity.UserRole> GetRoles()
        {
            App app = DataHelper.GetApp();
            UserRepository rep = new UserRepository(app);
            List<DataLayer.Entity.UserRole> list = rep.GetAllUserRole().ToList();

            list.Insert(0, new DataLayer.Entity.UserRole { UserRoleId = 0, Name = string.Empty });
            return list;
        }

        public void UpdateUser()
        {
            UserViewModel userM = new UserViewModel();

            if (this.TryUpdateModel(userM))
            {
                DataLayer.Entity.User user = new DataLayer.Entity.User();
                user.UserId = userM.UserId;
                user.Login = userM.Login;
                user.UserRoleId = userM.UserRoleId;
                App app = Uni.Helpers.DataHelper.GetApp();
                UserRepository rep = new UserRepository(app);
                bool res = rep.Update(user);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}