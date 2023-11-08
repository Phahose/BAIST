using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using nekwomBAIS3150CodeSampleEmpty.Domain;
using Microsoft.Data.SqlClient;
namespace nekwomBAIS3150CodeSampleEmpty.TechnicalServices
{
    public class Programs
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
         public Domain.Program GetProgram(string programCode)
          {
            Domain.Program ActiveProgram = new();
            SqlConnection nekwom1connection = new SqlConnection();
            nekwom1connection.ConnectionString = "Persist Security Info=False; Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1connection.Open();

            SqlCommand GetProgramCommand = new()
            {
                Connection = nekwom1connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };

            SqlParameter ProgramCode = new();
            ProgramCode = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = System.Data.SqlDbType.VarChar,
                SqlValue = programCode,
                Direction = System.Data.ParameterDirection.Input,
            };

            GetProgramCommand.Parameters.Add(ProgramCode);

            SqlDataReader programReader = GetProgramCommand.ExecuteReader();
            
            if (programReader.HasRows)
            {
                programReader.Read();
                ActiveProgram.ProgramCode = (string)programReader["ProgramCode"];
                ActiveProgram.Description = (string)programReader["Description"];
            }
            programReader.Close();
            nekwom1connection.Close();
            return ActiveProgram;
        }
    }
}
