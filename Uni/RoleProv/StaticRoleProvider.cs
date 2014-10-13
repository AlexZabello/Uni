using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Uni.RoleProv
{
    public class StaticRoleProvider : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            
        }

        public override string ApplicationName { get; set; }

        public override void CreateRole(string roleName)
        {
            
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return true;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return roleName == "users" && usernameToMatch == "test" ? new string[] { "test" } : new string[0];
        }

        public override string[] GetAllRoles()
        {
            return new string[] { "users", "admins" };
        }

        public override string[] GetRolesForUser(string username)
        {
            return username == "test" ? new string[] { "users" } : new string[0];
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return roleName == "users" ? new string[] { "test" } : new string[0];
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return username == "test" && roleName == "users";
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            
        }

        public override bool RoleExists(string roleName)
        {
            return roleName == "users" || roleName == "admins";
        }
    }
}