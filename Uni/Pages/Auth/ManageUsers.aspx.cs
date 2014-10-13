﻿using DataLayer.Core;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uni.Helpers;
using Uni.Models;

namespace Uni.Pages.Auth
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        public IEnumerable<UserModel> GetUsers()
        {
            App app = DataHelper.GetApp();
            UserRepository rep = new UserRepository();
            rep.App = app;

            IEnumerable<DataLayer.Entity.User> l = rep.GetAll();
            List<UserModel> list = new List<UserModel>();

            foreach (DataLayer.Entity.User item in l)
            {
                UserModel m = new UserModel();
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
            UserRepository rep = new UserRepository();
            rep.App = app;
            List<DataLayer.Entity.UserRole> list = rep.GetAllUserRole().ToList();

            list.Insert(0, new DataLayer.Entity.UserRole { UserRoleId = 0, Name = "" });
            return list;
        }

        public void UpdateUser()
        {
            UserModel userM = new UserModel();

            if (TryUpdateModel(userM))
            {
                DataLayer.Entity.User user = new DataLayer.Entity.User();
                user.UserId = userM.UserId;
                user.Login = userM.Login;
                user.UserRoleId = userM.UserRoleId;
                App app = Uni.Helpers.DataHelper.GetApp();
                UserRepository rep = new UserRepository();
                rep.App = app;
                bool res = rep.Update(user);
            }
        }
    }
}