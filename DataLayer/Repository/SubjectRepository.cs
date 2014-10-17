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
    public class SubjectRepository : Repository<Subject>
    {
        public SubjectRepository(App app): base(app)
        {
        }

        public override IEnumerable<Subject> GetAll()
        {//[SubjectList]
            try
            {
                App.OpenConnection();
                SqlDataAdapter adapter = App.CreateAdapter("dbo.SubjectList");
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Subject> subjectCollection = new List<Subject>();
                foreach (DataRow row in table.Rows)
                {
                    Subject subject = new Subject();
                    subject.SubjectId = row.Field<int>("SubjectId");
                    subject.Name = row.Field<string>("Name");
                    subjectCollection.Add(subject);
                }
                App.CloseConnection();
                return subjectCollection;
            }
            catch
            {
                return null;
            }
        }

        public override Subject Get(int id)
        {//[SubjectGet]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.SubjectGet");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter parameter = new SqlParameter("@SubjectId", id);
                pp.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                Subject subject = new Subject();
                while (reader.Read())
                {
                    subject.SubjectId = id;
                    subject.Name = reader.GetString(reader.GetOrdinal("Name"));
                }
                reader.Close();
                App.CloseConnection();
                return subject;
            }
            catch
            {
                return null;
            }
        }

        public override bool Insert(Subject item)
        {//[SubjectUpdate]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.SubjectUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter pId = new SqlParameter("@SubjectId", SqlDbType.Int);
                pId.Direction = ParameterDirection.InputOutput;
                pp.Add(pId);
                SqlParameter parameter = new SqlParameter("@Name", item.Name);
                pp.Add(parameter);

                command.ExecuteNonQuery();
                item.SubjectId = Convert.ToInt32(pId.Value);
                App.CloseConnection();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override bool Update(Subject item)
        {//[SubjectUpdate]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.SubjectUpdate");
                SqlParameterCollection pp = command.Parameters;

                SqlParameter parameter = new SqlParameter("@SubjectId", item.SubjectId);
                parameter.Direction = ParameterDirection.InputOutput;
                pp.Add(parameter);
                parameter = new SqlParameter("@FirstName", item.Name);
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
        {//[SubjectDelete]
            try
            {
                App.OpenConnection();
                SqlCommand command = App.CreateCommand("dbo.SubjectDelete");
                SqlParameterCollection pp = command.Parameters;
                SqlParameter p = new SqlParameter("@SubjectId", id);
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
    }
}
