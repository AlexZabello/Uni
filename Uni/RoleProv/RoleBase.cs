//-----------------------------------------------------------------------
// <copyright file="RoleBase.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.RoleProv
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Security;
    using DataLayer.Core;
    using DataLayer.Entity;
    using DataLayer.Repository;
    using Uni.Helpers;

    /// <summary>
    /// Base role provider
    /// </summary>
    public class RoleBase : RoleProvider
    {
        /// <summary>
        /// connection string for database
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Gets or sets application name
        /// </summary>
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

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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
            UserRepository userRepository = new UserRepository(app);
            List<UserRole> userRoleCollection = userRepository.GetAllUserRole().ToList();
            app.CloseConnection();
            string[] roles = new string[userRoleCollection.Count()];
            int count = userRoleCollection.Count;
            for (int i = 0; i < userRoleCollection.Count; i++)
            {
                roles[i] = userRoleCollection[i].Name;
            }

            return roles;
        }

        public override string[] GetRolesForUser(string username)
        {
            App app = DataHelper.GetApp();
            UserRepository userRepository = new UserRepository(app);
            UserRole role = userRepository.GetUserRole(new User { Login = username });
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
                return this.GetRolesForUser(username).Contains(roleName);    
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
            this.connectionString = WebConfigurationManager.ConnectionStrings["Uni"].ConnectionString;
            
            base.Initialize(name, config);
        }
    }
}