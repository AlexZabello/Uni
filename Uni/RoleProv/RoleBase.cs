using DataLayer.Core;
using DataLayer.Entity;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using Uni.Helpers;

namespace Uni.RoleProv
{
    public class RoleBase : RoleProvider
    {
        private string connectionString;

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            App app = DataHelper.GetApp();
            UserRepository rep = new UserRepository();
            rep.App = app;
            List<UserRole> list = rep.GetAllUserRole().ToList();
            app.CloseConnection();
            string[] roles = new string[list.Count()];
            int count = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                roles[i] = list[i].Name;
            }
            return roles;
        }

        public override string[] GetRolesForUser(string username)
        {
            App app = DataHelper.GetApp();
            UserRepository rep = new UserRepository();
            rep.App = app;
            UserRole role = rep.GetUserRole(new User { Login = username });
            app.CloseConnection();
            return new string[] { role.Name };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (roleName != string.Empty)
            {
                return GetRolesForUser(username).Contains(roleName);    
            }
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            connectionString = WebConfigurationManager.ConnectionStrings["Uni"].ConnectionString;

            
            base.Initialize(name, config);
        }
    }
}