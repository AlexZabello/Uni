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
    public class StudentRepository : AppContainer, IRepository<Student> 
    {
        public IEnumerable<Student> GetAll()
        {
            //dbo.StudentList
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.StudentList");
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Student> studList = new List<Student>();
                foreach (DataRow row in table.Rows)
                {
                    Student stud = new Student();
                    stud.StudentId = row.Field<int>("StudentId");
                    stud.FirstName = row.Field<string>("FirstName");
                    stud.LastName = row.Field<string>("LastName");

                    stud.Subject = new Subject
                    {
                        SubjectId = row.Field<int>("SubjectId"),
                        Name = row.Field<string>("SubjectName")

                    };
                    int? id = row.Field<int?>("GroupId");
                    if (id.HasValue)
                    {
                        stud.Group = new Group
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
                    studList.Add(stud);
                }
                App.CloseConnection();
                return studList;
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
                SqlParameter p = new SqlParameter("@FirstName", firstName);
                pp.Add(p);
                p = new SqlParameter("@LastName", lastName);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", subjectId);
                pp.Add(p);
                p = new SqlParameter("@GroupId", groupId);
                pp.Add(p);
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Student> studList = new List<Student>();
                foreach (DataRow row in table.Rows)
                {
                    Student stud = new Student();
                    stud.StudentId = row.Field<int>("StudentId");
                    stud.FirstName = row.Field<string>("FirstName");
                    stud.LastName = row.Field<string>("LastName");

                    stud.Subject = new Subject
                    {
                        SubjectId = row.Field<int>("SubjectId"),
                        Name = row.Field<string>("SubjectName")

                    };
                    int? id = row.Field<int?>("GroupId");
                    if (id.HasValue)
                    {
                        stud.Group = new Group
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
                    studList.Add(stud);
                }
                App.CloseConnection();
                return studList;
            }
            catch
            {
                return null;
            }
        }

        public Student Get(int id)
        {
            //dbo.StudentGet
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.StudentGet");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@StudentId", id);
                pp.Add(p);
                SqlDataReader reader = command.ExecuteReader();
                Student stud = new Student();
                while (reader.Read())
                {
                    stud.StudentId = id;
                    stud.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    stud.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                }
                reader.Close();
                App.CloseConnection();
                return stud;
            }
            catch
            {
                return null;
            }
            
        }

        public bool Insert(Student item)
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
                SqlParameter p = new SqlParameter("@FirstName", item.FirstName);
                pp.Add(p);
                p = new SqlParameter("@LastName", item.LastName);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(p);
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

        public bool Update(Student item)
        {
            //dbo.StudentUpdate
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.StudentUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter p = new SqlParameter("@StudentId", item.StudentId);
                p.Direction = ParameterDirection.InputOutput;
                pp.Add(p);
                p = new SqlParameter("@FirstName", item.FirstName);
                pp.Add(p);
                p = new SqlParameter("@LastName", item.LastName);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", item.SubjectId);
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

        public bool Delete(int id)
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

        public bool CreateStudSubject(Student stud, Subject sub)
        {
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("SetSubjectToStudent");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@StudentId", stud.StudentId);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", sub.SubjectId);
                pp.Add(p);

                command.ExecuteNonQuery();
            }
            catch 
            {
                return false;
            }
            return true;
        }

        public bool DeleteStudSubject(Student stud, Subject sub)
        {//[RemoveSubjectToStudent]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("RemoveSubjectToStudent");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@StudentId", stud.StudentId);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", sub.SubjectId);
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
