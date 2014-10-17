using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Core;
using DataLayer.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace DataLayer.Repository
{
    public class StudentRepository : Repository<Student> , IStudentRepository
    {
        public StudentRepository(App app): base(app)
        {
        }

        public override IEnumerable<Student> GetAll()
        {
            //dbo.StudentList
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.StudentList");
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Student> studentCollection = new List<Student>();
                foreach (DataRow row in table.Rows)
                {
                    Student student = new Student();
                    student.StudentId = row.Field<int>("StudentId");
                    student.FirstName = row.Field<string>("FirstName");
                    student.LastName = row.Field<string>("LastName");

                    student.Subject = new Subject
                    {
                        SubjectId = row.Field<int>("SubjectId"),
                        Name = row.Field<string>("SubjectName")

                    };
                    int? id = row.Field<int?>("GroupId");
                    if (id.HasValue)
                    {
                        student.Group = new Group
                        {
                            GroupId = id.Value,
                            Name = row.Field<string>("GroupName"),
                            Prof = new Teacher
                            {
                                FirstName = row.Field<string>("pFirstName"),
                                LastName = row.Field<string>("pLastName")
                            }
                        };
                    }
                    studentCollection.Add(student);
                }
                App.CloseConnection();
                return studentCollection;
            }
            catch 
            {
                return null;
            }
            
        }

        public IEnumerable<Student> SearchStudent(string firstName = null, 
            string lastName = null, int? subjectId = null, int? groupId = null)
        {
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.StudentSearch");
                SqlParameterCollection pp = adapter.SelectCommand.Parameters;
                SqlParameter parameter = new SqlParameter("@FirstName", firstName);
                pp.Add(parameter);
                parameter = new SqlParameter("@LastName", lastName);
                pp.Add(parameter);
                parameter = new SqlParameter("@SubjectId", subjectId);
                pp.Add(parameter);
                parameter = new SqlParameter("@GroupId", groupId);
                pp.Add(parameter);
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Student> studentCollection = new List<Student>();
                foreach (DataRow row in table.Rows)
                {
                    Student student = new Student();
                    student.StudentId = row.Field<int>("StudentId");
                    student.FirstName = row.Field<string>("FirstName");
                    student.LastName = row.Field<string>("LastName");

                    student.Subject = new Subject
                    {
                        SubjectId = row.Field<int>("SubjectId"),
                        Name = row.Field<string>("SubjectName")

                    };
                    int? id = row.Field<int?>("GroupId");
                    if (id.HasValue)
                    {
                        student.Group = new Group
                        {
                            GroupId = id.Value,
                            Name = row.Field<string>("GroupName"),
                            Prof = new Teacher
                            {
                                FirstName = row.Field<string>("pFirstName"),
                                LastName = row.Field<string>("pLastName")
                            }
                        };
                    }
                    studentCollection.Add(student);
                }
                App.CloseConnection();
                return studentCollection;
            }
            catch
            {
                return null;
            }
        }

        public override Student Get(int id)
        {
            //dbo.StudentGet
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.StudentGet");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter parameter = new SqlParameter("@StudentId", id);
                pp.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                Student student = new Student();
                while (reader.Read())
                {
                    student.StudentId = id;
                    student.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    student.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                }
                reader.Close();
                App.CloseConnection();
                return student;
            }
            catch
            {
                return null;
            }
            
        }

        public override bool Insert(Student item)
        {
            //dbo.StudentUpdate
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.StudentUpdate");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter pId = new SqlParameter("@StudentId", SqlDbType.Int);
                pId.Direction = ParameterDirection.InputOutput;
                pp.Add(pId);
                SqlParameter parameter = new SqlParameter("@FirstName", item.FirstName);
                pp.Add(parameter);
                parameter = new SqlParameter("@LastName", item.LastName);
                pp.Add(parameter);
                parameter = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(parameter);
                //p = new SqlParameter("@UserId", item.UserId);
                //pp.Add(p);

                command.ExecuteNonQuery();
                item.StudentId = Convert.ToInt32(pId.Value);
                App.CloseConnection();
            }
            catch 
            {
                return false;
            }
            return true;
        }

        public override bool Update(Student item)
        {
            //dbo.StudentUpdate
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.StudentUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter parameter = new SqlParameter("@StudentId", item.StudentId);
                parameter.Direction = ParameterDirection.InputOutput;
                pp.Add(parameter);
                parameter = new SqlParameter("@FirstName", item.FirstName);
                pp.Add(parameter);
                parameter = new SqlParameter("@LastName", item.LastName);
                pp.Add(parameter);
                parameter = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(parameter);

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
            //dbo.StudentDelete
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.StudentDelete");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@StudentId", id);
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

        public bool RegStudentToGroup(Student stud, Group group)
        {
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("RegStudInGroup");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@StudentId", stud.StudentId);
                pp.Add(p);
                p = new SqlParameter("@GroupId", group.GroupId);
                pp.Add(p);

                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UnRegStudentToGroup(Student stud, Group group)
        {
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("UnRegStudInGroup");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@StudentId", stud.StudentId);
                pp.Add(p);
                p = new SqlParameter("@GroupId", group.GroupId);
                pp.Add(p);

                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
