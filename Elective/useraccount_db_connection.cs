using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Elective
{
    public class useraccount_db_connection
    {
        // Declaration of variables for database connections and queries
        public String useraccount_connectionString = null;
        public SqlConnection useraccount_sql_connection;
        public SqlCommand useraccount_sql_command;
        public DataSet useraccount_sql_dataset;
        public SqlDataAdapter useraccount_sql_dataadapter;
        public string useraccount_sql = null;

        public void useraccount_connString()
        {
            // Codes to establish connection from C# forms to the SQL Server database
            // FIX: Simplified the instantiation to avoid creating the object twice
            useraccount_connectionString = "Data Source=192.168.1.100,41414;Initial Catalog=POSDB;User ID=Andyval0612;Password=Andyval0612;";
            useraccount_sql_connection = new SqlConnection(useraccount_connectionString);

            // Good practice: Check if open before opening to avoid errors
            if (useraccount_sql_connection.State == ConnectionState.Closed)
            {
                useraccount_sql_connection.Open();
            }
        }

        public void useraccount_cmd() // Public function codes that support the mssql query
        {
            useraccount_sql_command = new SqlCommand(useraccount_sql, useraccount_sql_connection);
            useraccount_sql_command.CommandType = CommandType.Text;
        }

        public void useraccount_sqladapterSelect() // Mediating between C# language and the MSSQL SELECT command
        {
            useraccount_sql_dataadapter = new SqlDataAdapter();
            useraccount_sql_dataadapter.SelectCommand = useraccount_sql_command;
            useraccount_sql_command.ExecuteNonQuery();
        }

        public void useraccount_sqladapterInsert() // Mediating between C# language and the MSSQL INSERT command
        {
            useraccount_sql_dataadapter = new SqlDataAdapter();
            useraccount_sql_dataadapter.InsertCommand = useraccount_sql_command;
            useraccount_sql_command.ExecuteNonQuery();
        }

        public void useraccount_sqladapterDelete() // Mediating between C# language and the MSSQL DELETE command
        {
            useraccount_sql_dataadapter = new SqlDataAdapter();
            useraccount_sql_dataadapter.DeleteCommand = useraccount_sql_command;
            useraccount_sql_command.ExecuteNonQuery();
        }

        public void useraccount_sqladapterUpdate() // Mediating between C# language and the MSSQL UPDATE command
        {
            useraccount_sql_dataadapter = new SqlDataAdapter();
            useraccount_sql_dataadapter.UpdateCommand = useraccount_sql_command;
            useraccount_sql_command.ExecuteNonQuery();
        }

        public void useraccount_sqldatasetSELECT() // Codes for mirroring the contents of the database inside MSSQL to C#
        {
            useraccount_sql_dataset = new DataSet();
            useraccount_sql_dataadapter.Fill(useraccount_sql_dataset, "pos_empRegTbl");
        }

        public void useraccount_sqldatasetSELECT_Account() // Codes for mirroring the contents of the database inside the MSSQL to C#
        {
            useraccount_sql_dataset = new DataSet();
            useraccount_sql_dataadapter.Fill(useraccount_sql_dataset, "useraccountTbl");
        }
    }
}