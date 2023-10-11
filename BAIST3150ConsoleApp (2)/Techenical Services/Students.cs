using BAIST3150ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using BAIS3150ConsoleApp;

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

        public Student GetStudent(string studentID)
        {
            Student EnrolledStudent = new();
            SqlConnection nekwom1Connnnection = new();
            nekwom1Connnnection.ConnectionString = "Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1Connnnection.Open();

            SqlCommand FindStudent = new()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = nekwom1Connnnection,
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

            SqlDataReader StudentReader = FindStudent.ExecuteReader();
            if (StudentReader.HasRows)
            {              
                StudentReader.Read();
                EnrolledStudent.StudentId = (string) StudentReader["StudentID"];
                EnrolledStudent.FirstName = (string) StudentReader["FirstName"];
                EnrolledStudent.LastName =  (string) StudentReader["LastName"];
                EnrolledStudent.Email = (string)StudentReader["Email"];
            }
            StudentReader.Close();
            nekwom1Connnnection.Close();
            return EnrolledStudent;
        }

        public bool UpdateStudent(Student EnrolledStudent)
        {
            bool Success =false;
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
                SqlValue = EnrolledStudent.StudentId,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
            };

            ModifyStdent.Parameters.Add(StudentID);

            SqlParameter FirstName = new()
            {
                ParameterName = "@StudentFirstName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                SqlValue = EnrolledStudent.FirstName,
                Direction = System.Data.ParameterDirection.Input,
            };
            ModifyStdent.Parameters.Add(FirstName);

            SqlParameter LastName = new()
            {
                ParameterName = "@StudentLastName",
                SqlValue = EnrolledStudent.LastName,
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
            ModifyStdent.Parameters.Add(ProgramCode);

            SqlParameter Email = new()
            {
                ParameterName = "@StudentEmail",
                SqlValue = EnrolledStudent.Email,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
            };
            ModifyStdent.Parameters.Add(Email);

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
                    for (int i = 0; i < studentReader.FieldCount; i++)
                    {
                        Console.Write($"{studentReader[i].ToString}, ");
                    }
                    Console.WriteLine();
                }
            }
            studentReader.Close();
            conn.Close();
            return Success;
        }

        public bool DeleteStudent(string StudentID)
        {
            bool Success = false;   
            SqlConnection conn = new();

            conn.ConnectionString = "Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            conn.Open();

            SqlCommand RemoveStudent = new()
            {
                Connection = conn,
                CommandText = "DeleteStudent",
                CommandType = System.Data.CommandType.StoredProcedure,
            };

            SqlParameter StudentIDParameter = new()
            {
                ParameterName = "@StudentID",
                SqlValue = StudentID,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
            };

            RemoveStudent.Parameters.Add(StudentIDParameter);
            RemoveStudent.ExecuteNonQuery();
            conn.Close();
            return Success;
        }

        public List<Student> GetStudents(string ProgramCode)
        {
            List<Student> students = new();
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
                SqlValue = ProgramCode,
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
            return students;
        }
    }
}
