using DataLayer.Core;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(App app): base(app)
        {

        }

        public override IEnumerable<User> GetAll()
        {//UsersList
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.UsersList");
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<User> userCollection = new List<User>();
                foreach (DataRow row in table.Rows)
                {
                    User user = new User();
                    user.UserId = row.Field<int>("UserId");
                    user.Login = row.Field<string>("Login");
                    user.UserRoleId = row.Field<int?>("UserRoleId");
                    if (user.UserRole != null)
                    {
                        user.UserRole.Name = row.Field<string>("UserRoleName");
                    }
                    
                    userCollection.Add(user);
                }
                App.CloseConnection();
                return userCollection;
            }
            catch
            {
                return null;
            }
        }

        public override User Get(int id)
        {//UserGet
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.UserGet");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter sqlParameter = new SqlParameter("@UserId", id);
                pp.Add(sqlParameter);
                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                while (reader.Read())
                {
                    user.UserId = id;
                    user.Login = reader.GetString(reader.GetOrdinal("Login"));
                    user.UserRoleId = reader.GetInt32(reader.GetOrdinal("UserRoleId"));
                }
                reader.Close();
                App.CloseConnection();
                return user;
            }
            catch
            {
                return null;
            }
        }

        public override bool Insert(User item)
        {//UserUpdate
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.UserUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter pId = new SqlParameter("@UserId", SqlDbType.Int);
                pId.Direction = ParameterDirection.InputOutput;
                pp.Add(pId);
                SqlParameter sqlParameter = new SqlParameter("@Login", item.Login);
                pp.Add(sqlParameter);
                sqlParameter = new SqlParameter("@Password", item.Password);
                pp.Add(sqlParameter);

                command.ExecuteNonQuery();
                item.UserId = Convert.ToInt32(pId.Value);
                App.CloseConnection();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override bool Update(User item)
        {//UserUpdate
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.UserUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter sqlParameter = new SqlParameter("@UserId", item.UserId);
                sqlParameter.Direction = ParameterDirection.InputOutput;
                pp.Add(sqlParameter);
                sqlParameter = new SqlParameter("@Login", item.Login);
                pp.Add(sqlParameter);
                if (item.UserRoleId != null && item.UserRoleId > 0)
                {
                    sqlParameter = new SqlParameter("@UserRoleId", item.UserRoleId);
                    pp.Add(sqlParameter);
                }
                
                command.ExecuteNonQuery();
                App.CloseConnection();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Check(User item)
        {//UserCheck
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.UserCheck");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter sqlParameter = new SqlParameter("@Login", item.Login);
                pp.Add(sqlParameter);
                sqlParameter = new SqlParameter("@Password", item.Password);
                pp.Add(sqlParameter);
                SqlParameter pId = new SqlParameter("@UserId", item.UserId);
                pId.Direction = ParameterDirection.Output;
                pp.Add(pId);
                SqlParameter pIdRole = new SqlParameter("@UserRoleId", SqlDbType.Int);
                pIdRole.Direction = ParameterDirection.Output;
                pp.Add(pIdRole);
                command.ExecuteNonQuery();
                App.CloseConnection();
                if (pId.Value == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    item.UserId = Convert.ToInt32(pId.Value);
                    item.UserRoleId = Convert.ToInt32(pIdRole.Value);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
                
        }

        public UserRole GetUserRole(User item)
        {//[UserRoleGet]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.UserRoleGet");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter sqlParameter = new SqlParameter("@Login", item.Login);
                pp.Add(sqlParameter);
                SqlDataReader reader = command.ExecuteReader();
                UserRole userRole = new UserRole();
                userRole.Name = "";
                while (reader.Read())
                {
                    userRole.UserRoleId = reader.GetInt32(reader.GetOrdinal("UserRoleId"));
                    userRole.Name = reader.GetString(reader.GetOrdinal("Name"));
                }
                reader.Close();
                App.CloseConnection();
                return userRole;
                
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<UserRole> GetAllUserRole()
        {//[UserRoleList]
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.UserRoleList");
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<UserRole> userRoleCollection = new List<UserRole>();
                foreach (DataRow row in table.Rows)
                {
                    UserRole userRole = new UserRole();
                    userRole.UserRoleId = row.Field<int>("UserRoleId");
                    userRole.Name = row.Field<string>("Name");
                    userRoleCollection.Add(userRole);
                }
                App.CloseConnection();
                return userRoleCollection;
            }
            catch
            {
                return null;
            }
        }

        
    }
}
