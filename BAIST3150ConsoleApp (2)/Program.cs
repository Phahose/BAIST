using Microsoft.Data.SqlClient;
using System.Data;
/*using System.Data;
using Microsoft.Data.SqlClient;*/
using Microsoft.IdentityModel.Tokens;
using BAIST3150ConsoleApp.Domain;
using BAIST3150ConsoleApp.Techenical_Services;

namespace BAIS3150ConsoleApp
{
    internal class Program
    {
        static void AddProgramExecuteNonQueryExample()
        {
            Console.WriteLine("AddProgramExecuteNonQueryExample");
            //sqlconnection
            SqlConnection MyDataSource; // declaration
            MyDataSource = new();       //instantiation
                                        // MyDataSource.ConnectionString = "Persist Security Info=False;Integrated Security=True;Database=NicholasDb;server=LAPTOP-CBDT3BII\\SQLEXPRESS;TrustServerCertificate=true";// @ sign here indicates that the line should be read literlly
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();//sqlcommand
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
                SqlValue = "DEMO"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommandParameter = new()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "DEMO Adminsitration System Design"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommand.ExecuteNonQuery();
            MyDataSource.Close();
        }

        static void GetProgramsExecuteReaderExample()
        {
            Console.WriteLine("GetPrograms");
            SqlConnection MyDataSource;
            MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();
            SqlCommand ExampleCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };

            SqlParameter ProgramID = new()
            {
                // We will say the Name of The Parameter the same way as it will be done in referencing methods in C# we will also have 
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "DEMO"
            };
            SqlDataReader ExampleDataReader;
            ExampleCommand.Parameters.Add(ProgramID);
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
            Console.WriteLine("GetProgram");
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=NicholasDB;server=LAPTOP-CBDT3BII\SQLEXPRESS;TrustServerCertificate=true";
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
                SqlValue = "DEMO"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            Console.WriteLine(ExampleCommand.ExecuteScalar().ToString());
            MyDataSource.Close();
        }
        static void AddStudentExecuteExample()
        {
            Console.WriteLine("Add Student");
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand AddStudentCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddStudent"
            };
            SqlParameter StudentIDParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "9"
            };
            SqlParameter StudentFirstNameParameter = new()
            {
                ParameterName = "@StudentFirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Margaret"
            };
            SqlParameter StudentLastNameParameter = new()
            {
                ParameterName = "@StudentLastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Irine"
            };
            SqlParameter ProgramCodeParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST"
            };
            SqlParameter StudentEmailParameter = new()
            {
                ParameterName = "@StudentEmail",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "mirine1@gmail.com"
            };

            AddStudentCommand.Parameters.Add(StudentIDParameter);
            AddStudentCommand.Parameters.Add(StudentFirstNameParameter);
            AddStudentCommand.Parameters.Add(StudentLastNameParameter);
            AddStudentCommand.Parameters.Add(ProgramCodeParameter);
            AddStudentCommand.Parameters.Add(StudentEmailParameter);
            Console.WriteLine(AddStudentCommand.ExecuteNonQuery());
            MyDataSource.Close();
            Console.WriteLine("Success");
        }
        static void UpdateStudentExecuteExample()
        {
            Console.WriteLine("Update Student");
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand AddStudentCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateStudent"
            };
            SqlParameter StudentIDParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "9"
            };
            SqlParameter StudentFirstNameParameter = new()
            {
                ParameterName = "@StudentFirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Eric"
            };
            SqlParameter StudentLastNameParameter = new()
            {
                ParameterName = "@StudentLastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Ekwom"
            };
            SqlParameter ProgramCodeParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "DEMO"
            };
            SqlParameter StudentEmailParameter = new()
            {
                ParameterName = "@StudentEmail",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "joanekwom@gmail.com"
            };

            AddStudentCommand.Parameters.Add(StudentIDParameter);
            AddStudentCommand.Parameters.Add(StudentFirstNameParameter);
            AddStudentCommand.Parameters.Add(StudentLastNameParameter);
            AddStudentCommand.Parameters.Add(ProgramCodeParameter);
            AddStudentCommand.Parameters.Add(StudentEmailParameter);
            Console.WriteLine(AddStudentCommand.ExecuteNonQuery());
            MyDataSource.Close();
            Console.WriteLine("Success");
        }
        static void DeleteStudentExecuteExample()
        {
            Console.WriteLine("Delete Student");
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand AddStudentCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteStudent"
            };
            SqlParameter StudentIDParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "9"
            };
            AddStudentCommand.Parameters.Add(StudentIDParameter);
            Console.WriteLine(AddStudentCommand.ExecuteNonQuery());
            MyDataSource.Close();
            Console.WriteLine("Success");
        }
        static void GetStudent()
        {
            Console.WriteLine("GetStudents");
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand GetStudent = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudent"
            };

            SqlParameter StudentID = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "9"
            };
            GetStudent.Parameters.Add(@StudentID);
            SqlDataReader StudentReader;
            StudentReader = GetStudent.ExecuteReader();

            if (StudentReader.HasRows)
            {
                Console.WriteLine("Columns");
                Console.WriteLine("-------");

                for (int index = 0; index < StudentReader.FieldCount; index++)
                {
                    Console.WriteLine(StudentReader.GetName(index));
                }
                Console.WriteLine("Values");
                Console.WriteLine("------");


                // The ExampleDataReader.FieldCount checks the number of collumns in the DB and The Read Checks the Number of Rows in the DB
                while (StudentReader.Read())
                {
                    for (int Index = 0; Index < StudentReader.FieldCount; Index++)
                    {
                        Console.WriteLine(StudentReader[Index].ToString());
                    }
                    Console.WriteLine("-");
                }
            }
            StudentReader.Close();
            Console.WriteLine(GetStudent.ExecuteScalar().ToString());
            MyDataSource.Close();
        }
        static void GetStudentByProgram()
        {
            Console.WriteLine("GetStudentByProgram");
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand GetStudent = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudentByProgram"
            };

            SqlParameter ProgramCode = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST"
            };
            GetStudent.Parameters.Add(@ProgramCode);
            SqlDataReader StudentReader;
            StudentReader = GetStudent.ExecuteReader();

            if (StudentReader.HasRows)
            {
                Console.WriteLine("Columns");
                Console.WriteLine("-------");

                for (int index = 0; index < StudentReader.FieldCount; index++)
                {
                    Console.Write($"{StudentReader.GetName(index)}; ");
                }
                Console.WriteLine("Values");
                Console.WriteLine("------");


                // The ExampleDataReader.FieldCount checks the number of collumns in the DB and The Read Checks the Number of Rows in the DB
                while (StudentReader.Read())
                {
                    for (int Index = 0; Index < StudentReader.FieldCount; Index++)
                    {
                        Console.Write($"{StudentReader[Index].ToString()} ");
                    }

                    Console.WriteLine();
                }
            }
            StudentReader.Close();
            MyDataSource.Close();
        }

        static void GetcustomerByCountry()
        {
            Console.WriteLine();
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand GetcustomerByCountry = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "nekwom1.GetCustomersByCountry"
            };

            SqlParameter CountryName = new()
            {
                ParameterName = "@CountryName",
                SqlDbType = SqlDbType.NChar,
                Direction = ParameterDirection.Input,
                SqlValue = "UK"
            };

            SqlDataReader CustomerReader;
            GetcustomerByCountry.Parameters.Add(CountryName);
            CustomerReader = GetcustomerByCountry.ExecuteReader();
            if (CustomerReader.HasRows)
            {
                Console.WriteLine($"Sample Result For {CountryName.Value}");
                Console.WriteLine("Country Columns");
                Console.WriteLine("-------");


                for (int index = 0; index < CustomerReader.FieldCount; index++)
                {
                    Console.Write($"{CustomerReader.GetName(index)}; ");
                }
                Console.WriteLine();
                Console.WriteLine("Country Values");
                Console.WriteLine("------");
                Console.WriteLine();
                // The ExampleDataReader.FieldCount checks the number of collumns in the DB and The Read Checks the Number of Rows in the DB
                while (CustomerReader.Read())
                {
                    for (int Index = 0; Index < CustomerReader.FieldCount; Index++)
                    {
                        if (CustomerReader[Index].ToString() == "")
                        {
                            Console.Write("N/A");
                        }
                        Console.Write($"{CustomerReader[Index].ToString()}; ");

                    }
                    Console.WriteLine();
                }
            }
            CustomerReader.Close();
            MyDataSource.Close();
        }

        static void GetCategory()
        {
            Console.WriteLine();
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand GetStudent = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "nekwom1.GetCategory"
            };

            SqlParameter CategoryID = new()
            {
                ParameterName = "@CategoryID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "4"
            };
            GetStudent.Parameters.Add(CategoryID);
            SqlDataReader Category;
            Category = GetStudent.ExecuteReader();

            if (Category.HasRows)
            {
                Console.WriteLine($"Category Details For Category With ID {CategoryID.Value}");
                Console.WriteLine("Category Columns");
                Console.WriteLine("-------");

                for (int index = 0; index < Category.FieldCount; index++)
                {
                    Console.Write($"{Category.GetName(index)};");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Category Values");
                Console.WriteLine("------");


                // The ExampleDataReader.FieldCount checks the number of collumns in the DB and The Read Checks the Number of Rows in the DB
                while (Category.Read())
                {
                    for (int Index = 0; Index < Category.FieldCount; Index++)
                    {
                        Console.Write($"{Category[Index].ToString()}; ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("-");
                }
            }
            Category.Close();
            MyDataSource.Close();
        }

        static void GetProductsCategory()
        {
            Console.WriteLine();
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand GetStudent = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "nekwom1.GetProductsByCategory"
            };

            SqlParameter CategoryID = new()
            {
                ParameterName = "@CategoryID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "4"
            };
            GetStudent.Parameters.Add(CategoryID);
            SqlDataReader Category;
            Category = GetStudent.ExecuteReader();

            if (Category.HasRows)
            {
                Console.WriteLine($"Product List for Category with ID {CategoryID.Value}");
                Console.WriteLine("Product Columns");
                Console.WriteLine("-------");

                for (int index = 0; index < Category.FieldCount; index++)
                {
                    Console.Write($"{Category.GetName(index)}; ");
                }
                Console.WriteLine();
                Console.WriteLine("Product Values");
                Console.WriteLine("------");


                // The ExampleDataReader.FieldCount checks the number of collumns in the DB and The Read Checks the Number of Rows in the DB
                while (Category.Read())
                {
                    for (int Index = 0; Index < Category.FieldCount; Index++)
                    {
                        Console.Write($"{Category[Index].ToString()}; ");
                    }
                    Console.WriteLine();
                }
            }
            Category.Close();
            MyDataSource.Close();
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
            /* bool Confirmation;
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
 */

            ///. Test AddProgram
            ///
            /*Course course = new Course()
            {
                Id = "BOND",
                Description = "BOND Test Course"
            };

            Courses courses = new Courses();
            courses.AddProgram(course.Id, course.Description);
            Console.WriteLine("done");*/


            // Test GetStudent
            Student student = new()
            {
                StudentId = "1230",
            };

            BCS students = new BCS();
            students.FindStudent(student.StudentId);

            // Test The Modify Student Class

            /*BCS bCS = new BCS();
            Student student = new Student()
            {
                StudentId = "1230",
                FirstName = "Christine",
                LastName = "Ginkia",
                Email = "giinin@gmaull.com"
            };
            Console.WriteLine("Success");
            bCS.ModifyStudent(student);*/


            //Test The Remove Student
            /*  BCS bCS = new BCS();
              Student student = new()
              {
                  StudentId = "Test",
              };
              Console.WriteLine("Remove Completed");
              bCS.RemoveStudent(student.StudentId);*/


            // Test For The Find Program 

            Course course = new Course()
            {
                Id = "BOND"
            };
            BCS bCS = new BCS();
            bCS.FindProgram(course.Id);
        }
    }
}

