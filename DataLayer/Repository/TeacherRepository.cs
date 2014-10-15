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
    public class TeacherRepository : Repository<Teacher>
    {
        public TeacherRepository(App app): base(app)
        {

        }

        public override IEnumerable<Teacher> GetAll()
        {
            //[TeacherList]
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.TeacherList");
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Teacher> tList = new List<Teacher>();
                foreach (DataRow row in table.Rows)
                {
                    Teacher t = new Teacher();
                    t.TeacherId = row.Field<int>("TeacherId");
                    t.FirstName = row.Field<string>("FirstName");
                    t.LastName = row.Field<string>("LastName");
                    t.SubjectId = row.Field<int>("SubjectId");
                    t.UserId = row.Field<int>("UserId");
                    tList.Add(t);
                }
                App.CloseConnection();
                return tList;
            }
            catch 
            {
                return null;   
            }
            
        }

        public override Teacher Get(int id)
        {
            //[TeacherGet]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.TeacherGet");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@TeacherId", id);
                pp.Add(p);
                SqlDataReader reader = command.ExecuteReader();
                Teacher t = new Teacher();
                while (reader.Read())
                {
                    t.TeacherId = id;
                    t.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    t.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    t.SubjectId = reader.GetInt32(reader.GetOrdinal("SubjectId"));
                    t.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
                }
                reader.Close();
                App.CloseConnection();
                return t;
            }
            catch
            {
                return null;
            }
        }

        public override bool Insert(Teacher item)
        {
            //[TeacherUpdate]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.TeacherUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter pId = new SqlParameter("@TeacherId", SqlDbType.Int);
                pId.Direction = ParameterDirection.InputOutput;
                pp.Add(pId);
                SqlParameter p = new SqlParameter("@FirstName", item.FirstName);
                pp.Add(p);
                p = new SqlParameter("@LastName", item.LastName);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(p);
                p = new SqlParameter("@UserId", item.UserId);
                pp.Add(p);

                command.ExecuteNonQuery();
                item.TeacherId = Convert.ToInt32(pId.Value);
                App.CloseConnection();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override bool Update(Teacher item)
        {
            //[TeacherUpdate]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.TeacherUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter p = new SqlParameter("@TeacherId", item.TeacherId);
                p.Direction = ParameterDirection.InputOutput;
                pp.Add(p);
                p = new SqlParameter("@FirstName", item.FirstName);
                pp.Add(p);
                p = new SqlParameter("@LastName", item.LastName);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(p);
                p = new SqlParameter("@UserId", item.UserId);
                pp.Add(p);

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
            //[TeacherDelete]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.TeacherDelete");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@TeacherId", id);
                pp.Add(p);
                command.ExecuteNonQuery();
                App.CloseConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Teacher GetByUser(User user)
        {
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.TeacherGetByUser");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@Login", user.Login);
                pp.Add(p);
                SqlDataReader reader = command.ExecuteReader();
                Teacher t = new Teacher();
                while (reader.Read())
                {
                    t.TeacherId = reader.GetInt32(reader.GetOrdinal("TeacherId"));
                    t.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    t.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    t.SubjectId = reader.GetInt32(reader.GetOrdinal("SubjectId"));
                    t.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
                }
                reader.Close();
                App.CloseConnection();
                return t;
            }
            catch
            {
                return null;
            }
        }
    }
}
