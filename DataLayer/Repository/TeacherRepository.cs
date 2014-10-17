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
                List<Teacher> teacherCollection = new List<Teacher>();
                foreach (DataRow row in table.Rows)
                {
                    Teacher teacher = new Teacher();
                    teacher.TeacherId = row.Field<int>("TeacherId");
                    teacher.FirstName = row.Field<string>("FirstName");
                    teacher.LastName = row.Field<string>("LastName");
                    teacher.SubjectId = row.Field<int>("SubjectId");
                    teacher.UserId = row.Field<int>("UserId");
                    teacherCollection.Add(teacher);
                }
                App.CloseConnection();
                return teacherCollection;
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
                SqlParameter parameter = new SqlParameter("@TeacherId", id);
                pp.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                Teacher teacher = new Teacher();
                while (reader.Read())
                {
                    teacher.TeacherId = id;
                    teacher.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    teacher.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    teacher.SubjectId = reader.GetInt32(reader.GetOrdinal("SubjectId"));
                    teacher.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
                }
                reader.Close();
                App.CloseConnection();
                return teacher;
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
                SqlParameter parameter = new SqlParameter("@FirstName", item.FirstName);
                pp.Add(parameter);
                parameter = new SqlParameter("@LastName", item.LastName);
                pp.Add(parameter);
                parameter = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(parameter);
                parameter = new SqlParameter("@UserId", item.UserId);
                pp.Add(parameter);

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

                SqlParameter sqlParameter = new SqlParameter("@TeacherId", item.TeacherId);
                sqlParameter.Direction = ParameterDirection.InputOutput;
                pp.Add(sqlParameter);
                sqlParameter = new SqlParameter("@FirstName", item.FirstName);
                pp.Add(sqlParameter);
                sqlParameter = new SqlParameter("@LastName", item.LastName);
                pp.Add(sqlParameter);
                sqlParameter = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(sqlParameter);
                sqlParameter = new SqlParameter("@UserId", item.UserId);
                pp.Add(sqlParameter);

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
                SqlParameter sqlParameter = new SqlParameter("@Login", user.Login);
                pp.Add(sqlParameter);
                SqlDataReader reader = command.ExecuteReader();
                Teacher teacher = new Teacher();
                while (reader.Read())
                {
                    teacher.TeacherId = reader.GetInt32(reader.GetOrdinal("TeacherId"));
                    teacher.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    teacher.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    teacher.SubjectId = reader.GetInt32(reader.GetOrdinal("SubjectId"));
                    teacher.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
                }
                reader.Close();
                App.CloseConnection();
                return teacher;
            }
            catch
            {
                return null;
            }
        }
    }
}
