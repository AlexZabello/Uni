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
    public class GroupRepository : Repository<Group>
    {
        public GroupRepository(App app) : base(app)
        {
        }

        public override IEnumerable<Group> GetAll()
        {//[GroupList]
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.GroupList");
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Group> groupCollection = new List<Group>();
                foreach (DataRow row in table.Rows)
                {
                    Group group = new Group();
                    group.GroupId = row.Field<int>("GroupId");
                    group.Name = row.Field<string>("Name");
                    group.Subject = new Subject
                    {
                        SubjectId = row.Field<int>("SubjectId"),
                        Name = row.Field<string>("SubjectName")
                    };
                    group.Prof = new Teacher
                    {
                        TeacherId = row.Field<int>("TeacherId"),
                        SubjectId = row.Field<int>("SubjectId"),
                        FirstName = row.Field<string>("PFirstName"),
                        LastName = row.Field<string>("PLastName")
                    };
                    groupCollection.Add(group);
                }
                App.CloseConnection();
                return groupCollection;
            }
            catch
            {
                return null;
            }
        }

        public override Group Get(int id)
        {//[GroupGet]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.GroupGet");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter parameter = new SqlParameter("@GroupId", id);
                pp.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                Group group = new Group();
                while (reader.Read())
                {
                    group.GroupId = id;
                    group.Name = reader.GetString(reader.GetOrdinal("Name"));
                    group.SubjectId = reader.GetInt32(reader.GetOrdinal("SubjectId"));
                    group.TeacherId = reader.GetInt32(reader.GetOrdinal("TeacherId"));
                }
                reader.Close();
                App.CloseConnection();
                return group;
            }
            catch
            {
                return null;
            }
        }

        public override bool Insert(Group item)
        {//[GroupUpdate]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.GroupUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter pId = new SqlParameter("@GroupId", SqlDbType.Int);
                pId.Direction = ParameterDirection.InputOutput;
                pp.Add(pId);
                SqlParameter parameter = new SqlParameter("@Name", item.Name);
                pp.Add(parameter);
                parameter = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(parameter);
                parameter = new SqlParameter("@TeacherId", item.TeacherId);
                pp.Add(parameter);

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

        public override bool Update(Group item)
        {//[GroupUpdate]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.GroupUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter parameter = new SqlParameter("@GroupId", item.GroupId);
                parameter.Direction = ParameterDirection.InputOutput;
                pp.Add(parameter);
                parameter = new SqlParameter("@Name", item.Name);
                pp.Add(parameter);
                parameter = new SqlParameter("@SubjectId", item.SubjectId);
                pp.Add(parameter);
                parameter = new SqlParameter("@TeacherId", item.TeacherId);
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
                SqlParameter parameter = new SqlParameter("@SubjectId", subj.SubjectId);
                pp.Add(parameter);
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Group> groupCollection = new List<Group>();
                foreach (DataRow row in table.Rows)
                {
                    Group group = new Group();
                    group.GroupId = row.Field<int>("GroupId");
                    group.Name = row.Field<string>("Name");
                    group.Subject = new Subject
                    {
                        SubjectId = row.Field<int>("SubjectId"),
                        Name = row.Field<string>("SubjectName")
                    };
                    group.Prof = new Teacher
                    {
                        TeacherId = row.Field<int>("TeacherId"),
                        SubjectId = row.Field<int>("SubjectId"),
                        FirstName = row.Field<string>("PFirstName"),
                        LastName = row.Field<string>("PLastName")
                    };
                    groupCollection.Add(group);
                }
                App.CloseConnection();
                return groupCollection;
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
                SqlParameter parameter = new SqlParameter("@StudentId", stud.StudentId);
                pp.Add(parameter);
                parameter = new SqlParameter("@Group", group.GroupId);
                pp.Add(parameter);

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
                SqlParameter parameter = new SqlParameter("@StudentId", stud.StudentId);
                pp.Add(parameter);
                parameter = new SqlParameter("@Group", group.GroupId);
                pp.Add(parameter);

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
