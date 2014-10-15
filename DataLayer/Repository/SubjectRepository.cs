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
                List<Subject> subList = new List<Subject>();
                foreach (DataRow row in table.Rows)
                {
                    Subject sub = new Subject();
                    sub.SubjectId = row.Field<int>("SubjectId");
                    sub.Name = row.Field<string>("Name");
                    subList.Add(sub);
                }
                App.CloseConnection();
                return subList;
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
                SqlParameter p = new SqlParameter("@SubjectId", id);
                pp.Add(p);
                SqlDataReader reader = command.ExecuteReader();
                Subject sub = new Subject();
                while (reader.Read())
                {
                    sub.SubjectId = id;
                    sub.Name = reader.GetString(reader.GetOrdinal("Name"));
                }
                reader.Close();
                App.CloseConnection();
                return sub;
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
                SqlParameter p = new SqlParameter("@Name", item.Name);
                pp.Add(p);

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

                SqlParameter p = new SqlParameter("@SubjectId", item.SubjectId);
                p.Direction = ParameterDirection.InputOutput;
                pp.Add(p);
                p = new SqlParameter("@FirstName", item.Name);
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
