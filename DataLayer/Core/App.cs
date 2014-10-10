using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer.Core
{
    public class App
    {
        private SqlConnection connection;

        public App(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch 
            {
            }

            return connection;
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch
            {
                return false;
            }
            
            return true;
        }

        public SqlCommand CreateCommand(string commandName)
        {
            SqlCommand command = new SqlCommand(commandName);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            return command;
        }

        public SqlDataAdapter CreateAdapter(string adapterName)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(adapterName, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            return adapter;
        }
    }
}
