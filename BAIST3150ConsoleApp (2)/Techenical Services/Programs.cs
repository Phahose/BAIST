using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BAIST3150ConsoleApp.Domain;
using Microsoft.Data.SqlClient;

namespace BAIST3150ConsoleApp.Techenical_Services
{
    internal class Programs
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

        public Program GetProgram(string programCode)
        {
            Program ActiveProgram = new();
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
           
            Students StudentManager = new Students();

            List<Student> EnrolledStudents;
            EnrolledStudents = StudentManager.GetStudents(programCode);
            SqlDataReader programReader = GetProgramCommand.ExecuteReader();
            
            if (programReader.HasRows)
            {
                programReader.Read();
  
                foreach (Student EnrolledStudent in EnrolledStudents)
                {
                    Student ActiveProgramStduent = new()
                    {
                        StudentId = EnrolledStudent.StudentId,
                        FirstName = EnrolledStudent.FirstName,
                        LastName = EnrolledStudent.LastName,
                        Email = EnrolledStudent.Email,
                    };        
                    ActiveProgram.EnrolledStudents.Add(ActiveProgramStduent);
                   
                }

                for (int i = 0; i < ActiveProgram.EnrolledStudents.Count; i++)
                {
                    ActiveProgram.EnrolledStudents[i].StudentId = EnrolledStudents[i].StudentId;
                    ActiveProgram.EnrolledStudents[i].FirstName = EnrolledStudents[i].FirstName;
                    ActiveProgram.EnrolledStudents[i].LastName = EnrolledStudents[i].LastName;
                    ActiveProgram.EnrolledStudents[i].Email = EnrolledStudents[i].Email;
                    ActiveProgram.ProgramCode = (string)programReader["ProgramCode"];
                    ActiveProgram.Description = (string)programReader["Description"];
                }

   
            }
            programReader.Close();
            nekwom1connection.Close();
            return ActiveProgram;
        }
    }
}
