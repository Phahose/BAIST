using BAIST3150ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BAIST3150ConsoleApp.Techenical_Services
{
    internal class Students
    {
        public bool AddStudent(Domain.Student acceptetStudent, string progarmCode) // parameters, Camel Case
        {
            bool Success = false;
           
            SqlConnection Nekwom1 = new();
            Nekwom1.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            Nekwom1.Open();

            SqlCommand AddStudentCommand = new()
            {
                Connection = Nekwom1,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddStudent"
            };

            SqlParameter AddStudentCommandParameter;

            AddStudentCommandParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptetStudent.StudentId
            };
            AddStudentCommand.Parameters.Add(AddStudentCommandParameter);

            SqlParameter AddStudentFirstName;
            AddStudentFirstName = new()
            {
                ParameterName = "@StudentFirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptetStudent.FirstName
            };
            AddStudentCommand.Parameters.Add(AddStudentFirstName);

            SqlParameter AddStudentLastName = new()
            {
                ParameterName = "@StudentLastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptetStudent.LastName
            };
            AddStudentCommand.Parameters.Add(AddStudentLastName);

            SqlParameter AddStudentEmail = new()
            {
                ParameterName = "@StudentEmail",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptetStudent.Email
            };
            AddStudentCommand.Parameters.Add(AddStudentEmail);

            SqlParameter AddStudentProgaramCode = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = progarmCode
            };

            AddStudentCommand.Parameters.Add(AddStudentProgaramCode);

            AddStudentCommand.ExecuteNonQuery();
            Nekwom1.Close();
            
            Success = true;

            return Success;
        }


        public bool FindStudent(string studentID)
        {
            bool Success = false;

            SqlConnection conn = new();
            conn.ConnectionString = "Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            conn.Open();
            SqlCommand FindStudent = new()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = conn,
                CommandText= "GetStudent"
            };

            SqlParameter StudendID = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                SqlValue = studentID,
                Direction = ParameterDirection.Input,
            };

            FindStudent.Parameters.Add(StudendID);

            SqlDataReader studentReader = FindStudent.ExecuteReader();
             if(studentReader.HasRows)
            {
                Console.WriteLine("The data for the Sudent");
                Console.WriteLine("Collumns");
                Console.WriteLine("----------");
                for (int i = 0; i < studentReader.FieldCount; i++)
                {
                    Console.Write($"{studentReader.GetName(i)}, ");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("The Student data");
                Console.WriteLine("-----------------");
                while (studentReader.Read()) {
                    for (int Index = 0; Index < studentReader.FieldCount; Index++)
                    {
                        
                        Console.Write($"{studentReader[Index].ToString()}; ");
                    }
                }
                Console.WriteLine();
            }
            studentReader.Close();
            conn.Close();
            Success = true;
            return Success;
        }

    }
}
