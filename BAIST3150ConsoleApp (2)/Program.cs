using Microsoft.Data.SqlClient;
using System.Data;
/*using System.Data;
using Microsoft.Data.SqlClient;*/
using Microsoft.IdentityModel.Tokens;
using BAIST3150ConsoleApp.Domain;
using BAIST3150ConsoleApp.Techenical_Services;

namespace BAIST3150ConsoleApp
{
    internal class Program
    {
        static void AddProgramExecuteNonQueryExample()
        {
            Console.WriteLine("AddProgramExecuteNonQueryExample");
            //sqlconnection
            SqlConnection MyDataSource; // declaration
            MyDataSource = new();       //instantiation
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=NicholasDB;server=(localDB)\MSSQLLocalDB;";// @ sign here indicates that the line should be read literlly
            MyDataSource.Open();
            //sqlcommand
            SqlCommand ExampleCommand = new(); //declaration and instantiation
            ExampleCommand.Connection = MyDataSource;
            ExampleCommand.CommandType = CommandType.StoredProcedure;
            ExampleCommand.CommandText = "AddProgram";   // AddProgram = existing procedure in the sql server
                                                         //sqpParameter



            // The tored procedure is called AddProgram which is like a method in C#
            SqlParameter ExampleCommandParameter;



            // In here we are calling the parameters that were declred in the stored procedure method in this case its "@ProgramCode"
            ExampleCommandParameter = new()
            {
                // We will say the Name of The Parameter the same way as it will be done in referencing methods in C# we will also have 
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "EXAMPLE"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommandParameter = new()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Example Description"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommand.ExecuteNonQuery();
            MyDataSource.Close();
        }



        static void GetProgramsExecuteReaderExample()
        {
            Console.WriteLine("GetProgramsExecuteReaderExample");
            SqlConnection MyDataSource;
            MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=NicholasDB;server=(localDB)\MSSQLLocalDB;";
            MyDataSource.Open();
            SqlCommand ExampleCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetPrograms"
            };



            SqlDataReader ExampleDataReader;
            ExampleDataReader = ExampleCommand.ExecuteReader();



            if (ExampleDataReader.HasRows)
            {
                Console.WriteLine("Columns");
                Console.WriteLine("-------");



                for (int index = 0; index < ExampleDataReader.FieldCount; index++)
                {
                    Console.WriteLine(ExampleDataReader.GetName(index));
                }
                Console.WriteLine("Values");
                Console.WriteLine("------");





                // The ExampleDataReader.FieldCount checks the number of collumns in the DB and The Read Checks the Number of Rows in the DB
                while (ExampleDataReader.Read())
                {
                    for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                    {
                        Console.WriteLine(ExampleDataReader[Index].ToString());
                    }
                    Console.WriteLine("-");
                }
            }
            ExampleDataReader.Close();
            MyDataSource.Close();
        }
        static void GetProgramExecuteScalarExample()
        {
            Console.WriteLine("GetProgramExecuteScalarExample");
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=NicholasDB;server=(localDB)\MSSQLLocalDB";
            MyDataSource.Open();



            SqlCommand ExampleCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };



            SqlParameter ExampleCommandParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Example"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            Console.WriteLine(ExampleCommand.ExecuteScalar().ToString());
        }
        static void Main(string[] args)
        {
            //AddProgramExecuteNonQueryExample();
            //GetProgramsExecuteReaderExample();
            // GetProgramExecuteScalarExample();

            /*
             * Test Domail Student
             * -------------------
             */

            /*
            Student AcceptedStudent = new Student();
            AcceptedStudent.StudentId = "Test";
            AcceptedStudent.FirstName = "TestFirstName";
            AcceptedStudent.LastName = "TestLastName";
            AcceptedStudent.Email = "Test@nait.ca";
            Console.WriteLine(AcceptedStudent.StudentId);
            Console.WriteLine(AcceptedStudent.FirstName);
            Console.WriteLine(AcceptedStudent.LastName); 
            Console.WriteLine(AcceptedStudent.Email);
            */

            // Technical Services Test 
            // Add Student
            /* bool Succcess;
             Student AcceptedStudent = new()
             {
                 StudentId = "Test",
                 FirstName = "TestFirstName",
                 LastName = "TestLastName",
                 Email = "Test@nait.ca",
             };
             Students StudentManager = new();
             Succcess = StudentManager.AddStudent(AcceptedStudent, "DEMO");
             Console.WriteLine(Succcess);*/

            // Test Domain.BCS
            //---------------
            bool Confirmation;
            Student AcceptedStudent = new()
            {
                StudentId = "Test",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "Test@nait.ca",
            };

            BCS RequestDirector = new();

            Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, "DEMO");
            Console.WriteLine(Confirmation);

        }
    }
}