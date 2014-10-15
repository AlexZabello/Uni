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
                List<User> uList = new List<User>();
                foreach (DataRow row in table.Rows)
                {
                    User u = new User();
                    u.UserId = row.Field<int>("UserId");
                    u.Login = row.Field<string>("Login");
                    u.UserRoleId = row.Field<int?>("UserRoleId");
                    if (u.UserRole != null)
                    {
                        u.UserRole.Name = row.Field<string>("UserRoleName");
                    }
                    
                    uList.Add(u);
                }
                App.CloseConnection();
                return uList;
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
                SqlParameter p = new SqlParameter("@UserId", id);
                pp.Add(p);
                SqlDataReader reader = command.ExecuteReader();
                User u = new User();
                while (reader.Read())
                {
                    u.UserId = id;
                    u.Login = reader.GetString(reader.GetOrdinal("Login"));
                    u.UserRoleId = reader.GetInt32(reader.GetOrdinal("UserRoleId"));
                }
                reader.Close();
                App.CloseConnection();
                return u;
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
                SqlParameter p = new SqlParameter("@Login", item.Login);
                pp.Add(p);
                p = new SqlParameter("@Password", item.Password);
                pp.Add(p);

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

                SqlParameter p = new SqlParameter("@UserId", item.UserId);
                p.Direction = ParameterDirection.InputOutput;
                pp.Add(p);
                p = new SqlParameter("@Login", item.Login);
                pp.Add(p);
                if (item.UserRoleId != null && item.UserRoleId > 0)
                {
                    p = new SqlParameter("@UserRoleId", item.UserRoleId);
                    pp.Add(p);
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
                SqlParameter p = new SqlParameter("@Login", item.Login);
                pp.Add(p);
                p = new SqlParameter("@Password", item.Password);
                pp.Add(p);
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
                SqlParameter p = new SqlParameter("@Login", item.Login);
                pp.Add(p);
                SqlDataReader reader = command.ExecuteReader();
                UserRole u = new UserRole();
                u.Name = "";
                while (reader.Read())
                {
                    u.UserRoleId = reader.GetInt32(reader.GetOrdinal("UserRoleId"));
                    u.Name = reader.GetString(reader.GetOrdinal("Name"));
                }
                reader.Close();
                App.CloseConnection();
                return u;
                
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
                List<UserRole> uList = new List<UserRole>();
                foreach (DataRow row in table.Rows)
                {
                    UserRole u = new UserRole();
                    u.UserRoleId = row.Field<int>("UserRoleId");
                    u.Name = row.Field<string>("Name");
                    uList.Add(u);
                }
                App.CloseConnection();
                return uList;
            }
            catch
            {
                return null;
            }
        }

        
    }
}
