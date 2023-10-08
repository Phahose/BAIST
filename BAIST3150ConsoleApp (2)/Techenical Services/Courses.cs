using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BAIST3150ConsoleApp.Techenical_Services
{
    internal class Courses
    {
        public bool AddProgram(string programCode, string programName)
        {
            bool result = false;    
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Persist Security Info=False; Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            connection.Open();
            SqlCommand AddProgramCommand = new()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "AddProgram"
            };

            SqlParameter ProgramCode = new();
            ProgramCode = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = System.Data.SqlDbType.VarChar,
                SqlValue = programCode,
                Direction = System.Data.ParameterDirection.Input,
            };
            SqlParameter Description;
            Description = new()
            {
                ParameterName = "@Description",
                SqlDbType = System.Data.SqlDbType.VarChar,
                SqlValue = programName,
                Direction = System.Data.ParameterDirection.Input,
            };

            AddProgramCommand.Parameters.Add(ProgramCode);
            AddProgramCommand.Parameters.Add(Description);
            AddProgramCommand.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
