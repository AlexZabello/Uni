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
    public class GroupRepository : AppContainer, IRepository<Group>
    {
        public IEnumerable<Group> GetAll()
        {//[GroupList]
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.GroupList");
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Group> gList = new List<Group>();
                foreach (DataRow row in table.Rows)
                {
                    Group g = new Group();
                    g.GroupId = row.Field<int>("GroupId");
                    g.Name = row.Field<string>("Name");
                    g.Subject = new Subject
                    {
                        SubjectId = row.Field<int>("SubjectId"),
                        Name = row.Field<string>("SubjectName")
                    };
                    g.Prof = new Teacher
                    {
                        TeacherId = row.Field<int>("TeacherId"),
                        SubjectId = row.Field<int>("SubjectId"),
                        FirstName = row.Field<string>("PFirstName"),
                        LastName = row.Field<string>("PLastName")
                    };
                    gList.Add(g);
                }
                App.CloseConnection();
                return gList;
            }
            catch
            {
                return null;
            }
        }

        public Group Get(int id)
        {//[GroupGet]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.GroupGet");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@GroupId", id);
                pp.Add(p);
                SqlDataReader reader = command.ExecuteReader();
                Group g = new Group();
                while (reader.Read())
                {
                    g.GroupId = id;
                    g.Name = reader.GetString(reader.GetOrdinal("Name"));
                    g.SubjectId = reader.GetInt32(reader.GetOrdinal("SubjectId"));
                    g.TeacherId = reader.GetInt32(reader.GetOrdinal("TeacherId"));
                }
                reader.Close();
                App.CloseConnection();
                return g;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Group item)
        {//[GroupUpdate]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.GroupUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter pId = new SqlParameter("@GroupId", SqlDbType.Int);
                pId.Direction = ParameterDirection.InputOutput;
                pp.Add(pId);
                SqlParameter p = new SqlParameter("@Name", item.Name);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(p);
                p = new SqlParameter("@TeacherId", item.TeacherId);
                pp.Add(p);

                command.ExecuteNonQuery();
                item.GroupId = Convert.ToInt32(pId.Value);
                App.CloseConnection();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(Group item)
        {//[GroupUpdate]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.GroupUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter p = new SqlParameter("@GroupId", item.GroupId);
                p.Direction = ParameterDirection.InputOutput;
                pp.Add(p);
                p = new SqlParameter("@Name", item.Name);
                pp.Add(p);
                p = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(p);
                p = new SqlParameter("@TeacherId", item.TeacherId);
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
        {//[GroupDelete]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.GroupDelete");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@GroupId", id);
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

        public IEnumerable<Group> GetAllForSubject(Subject subj)
        {
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.GroupsForSubject");
                SqlParameterCollection pp = adapter.SelectCommand.Parameters;
                SqlParameter p = new SqlParameter("@SubjectId", subj.SubjectId);
                pp.Add(p);
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Group> gList = new List<Group>();
                foreach (DataRow row in table.Rows)
                {
                    Group g = new Group();
                    g.GroupId = row.Field<int>("GroupId");
                    g.Name = row.Field<string>("Name");
                    g.Subject = new Subject
                    {
                        SubjectId = row.Field<int>("SubjectId"),
                        Name = row.Field<string>("SubjectName")
                    };
                    g.Prof = new Teacher
                    {
                        TeacherId = row.Field<int>("TeacherId"),
                        SubjectId = row.Field<int>("SubjectId"),
                        FirstName = row.Field<string>("PFirstName"),
                        LastName = row.Field<string>("PLastName")
                    };
                    gList.Add(g);
                }
                App.CloseConnection();
                return gList;
            }
            catch
            {
                return null;
            }
        }

        public bool RegStudInGroup(Group group, Student stud)
        {//[RegStudInGroup]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("RegStudInGroup");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@StudentId", stud.StudentId);
                pp.Add(p);
                p = new SqlParameter("@Group", group.GroupId);
                pp.Add(p);

                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UnRegStudInGroup(Group group, Student stud)
        {//[UnRegStudInGroup]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("UnRegStudInGroup");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@StudentId", stud.StudentId);
                pp.Add(p);
                p = new SqlParameter("@Group", group.GroupId);
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
