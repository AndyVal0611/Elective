using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Elective
{
    internal class db_connection
    {
        // declaration of database connection related objects as public
        public string connectionString = null;
        public SqlConnection sql_connection;
        public SqlCommand sql_command;
        public DataSet sql_dataset;
        public SqlDataAdapter sql_dataadapter;
        public string sql = null;

        public void connString() //codes to establish connection from C# forms to the SQL Server database
        {
            sql_connection = new SqlConnection();
            connectionString = "Data Source = 192.168.1.11,41414; Initial Catalog = POSDB; Integrated Security = True";
            sql_connection = new SqlConnection(connectionString);
            sql_connection.ConnectionString = connectionString;
            sql_connection.Open();
        }
        public void cmd() //public function codes that support the mssql query
        {
            sql_command = new SqlCommand(sql, sql_connection);
            sql_command.CommandType = CommandType.Text;
        }
        public void sqladapterSelect() //public function codes for mediating between the language C# and MSSQL SELECT command
        {
            sql_dataadapter = new SqlDataAdapter();
            sql_dataadapter.SelectCommand = sql_command;
            sql_command.ExecuteNonQuery();
        }
        public void sqladapterInsert() //public function codes in mediating in the language or world of C# and MSSQL INSERT command
        {
            sql_dataadapter = new SqlDataAdapter();
            sql_dataadapter.InsertCommand = sql_command;
            sql_command.ExecuteNonQuery();
        }
        public void sqladapterDelete() //public function codes for mediating between the C# language and the MSSQL DELETE command
        {
            sql_dataadapter = new SqlDataAdapter();
            sql_dataadapter.DeleteCommand = sql_command;
            sql_command.ExecuteNonQuery();
        }
        public void sqladapterUpdate() //public function codes for mediating between the C# language and the MSSQL UPDATE command
        {
            sql_dataadapter = new SqlDataAdapter();
            sql_dataadapter.UpdateCommand = sql_command;
            sql_command.ExecuteNonQuery();
        }
        public void sqldatasetSelect() //codes for mirroring the contents of the database in MSSQL to C# or Visual Studio
        {
            sql_dataset = new DataSet();
            sql_dataadapter.Fill(sql_dataset, "studentTbl");
        }
    }
}
