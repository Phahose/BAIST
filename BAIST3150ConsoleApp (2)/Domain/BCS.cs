using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAIS3150ConsoleApp;
using BAIST3150ConsoleApp.Techenical_Services;
using Microsoft.Data.SqlClient;

namespace BAIST3150ConsoleApp.Domain
{
    internal class BCS
    {
        public bool EnrollStudent(Student acceptedStudents, string programcode)
        {
            bool Confirmation;
            Students StudentManager = new();

            Confirmation = StudentManager.AddStudent(acceptedStudents, programcode);
            return Confirmation;
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
                CommandText = "GetStudent"
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
            if (studentReader.HasRows)
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
                while (studentReader.Read())
                {
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


        public bool ModifyStudent(Student enrolledStudents)
       {
            bool confirmation = false;

           
            SqlConnection conn = new();

            conn.ConnectionString = "Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            conn.Open();

            SqlCommand ModifyStdent = new()
            {
                Connection = conn,
                CommandText = "UpdateStudent",
                CommandType = System.Data.CommandType.StoredProcedure,
            };

            SqlParameter StudentID = new()
            {
                ParameterName = "@StudentId",
                SqlValue = enrolledStudents.StudentId,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
            };

            ModifyStdent.Parameters.Add(StudentID);

            SqlParameter FirstName = new()
            {
                ParameterName = "@StudentFirstName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                SqlValue = enrolledStudents.FirstName,
                Direction = System.Data.ParameterDirection.Input,
            };
            ModifyStdent.Parameters.Add(FirstName);

            SqlParameter LastName = new()
            {
                ParameterName = "@StudentLastName",
                SqlValue = enrolledStudents.LastName,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
            };
            ModifyStdent.Parameters.Add(LastName);

            SqlParameter ProgramCode = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = System.Data.SqlDbType.VarChar,
                SqlValue = "NICK",
                Direction = System.Data.ParameterDirection.Input,
            };
            ModifyStdent.Parameters.Add (ProgramCode);

            SqlParameter Email = new() 
            {
                ParameterName = "@StudentEmail",
                SqlValue= enrolledStudents.Email,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction= System.Data.ParameterDirection.Input,
            };
            ModifyStdent.Parameters.Add (Email);

            ModifyStdent.ExecuteNonQuery();

            SqlDataReader studentReader;

            studentReader = ModifyStdent.ExecuteReader();

            if (studentReader.HasRows)
            {
                Console.WriteLine("Columns For the Student");
                Console.WriteLine("-------------------------");
                for (int i = 0; i < studentReader.FieldCount; i++)
                {
                    Console.Write($"{studentReader.GetName(i)}, ");
                }
                Console.WriteLine();
                while (studentReader.Read())
                {
                    Console.WriteLine("This is the Data ");
                    Console.WriteLine("-------------------");
                    for (int i = 0;i < studentReader.FieldCount; i++)
                    {
                        Console.Write($"{studentReader[i].ToString}, ");
                    }
                    Console.WriteLine();
                }
            }
            studentReader.Close();
            conn.Close();

            confirmation = true;
            return confirmation;
       }

       public bool RemoveStudent(string studentId)
       {
            bool confirmation = false;
            SqlConnection conn = new();

            conn.ConnectionString = "Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            conn.Open();

            SqlCommand RemoveStudent = new()
            {
                Connection = conn,
                CommandText ="DeleteStudent",
                CommandType=System.Data.CommandType.StoredProcedure,
            };

            SqlParameter StudentID = new()
            {
                ParameterName = "@StudentID",
                SqlValue = studentId,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
            };

            RemoveStudent.Parameters.Add(StudentID);
            RemoveStudent.ExecuteNonQuery();
            conn.Close();
            return confirmation;
        }

        public Program FindProgram (string programId) 
        {

            Program program = new();
            SqlConnection conn = new();

            conn.ConnectionString = "Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            conn.Open();

            SqlCommand FindProgram = new()
            {
                Connection = conn,
                CommandText = "GetProgram",
                CommandType = System.Data.CommandType.StoredProcedure,
            };
            SqlParameter ProgramID = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = System.Data.SqlDbType.VarChar,
                SqlValue = programId,
                Direction = System.Data.ParameterDirection.Input,
            };
            FindProgram.Parameters.Add(ProgramID);
            SqlDataReader programReader;
            programReader = FindProgram.ExecuteReader();
            if (programReader.HasRows)
            {
                Console.WriteLine("These Are the Collumns For the Programs");
                Console.WriteLine("-----------------------------------------");
                for (int i = 0; i < programReader.FieldCount; i++)
                {
                    Console.Write($"{programReader.GetName(i)}, ");
                }
                Console.WriteLine();

                while (programReader.Read())
                {
                    Console.WriteLine("These Are the Data For the Programs");
                    Console.WriteLine("-----------------------------------------");
                    for (int i = 0; i < programReader.FieldCount; i++)
                    {
                        Console.Write($"{programReader[i].ToString()}, ");
                    }
                }
            }
            programReader.Close();
            conn.Close();
            return program;
        }
    }
}
