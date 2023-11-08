using Microsoft.Data.SqlClient;
using nekwomBAIST310CodeSampleEmpty.Domain;
using System.Data;

namespace nekwomBAIST310CodeSampleEmpty.TechnicalServices
{
    public class Students
    {
        public bool AddStudent(nekwomBAIST310CodeSampleEmpty.Domain.Student acceptetStudent, string progarmCode) // parameters, Camel Case
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
                EnrolledStudent.StudentId = (string)StudentReader["StudentID"];
                EnrolledStudent.FirstName = (string)StudentReader["FirstName"];
                EnrolledStudent.LastName = (string)StudentReader["LastName"];
                EnrolledStudent.Email = (string)StudentReader["Email"];
            }
            StudentReader.Close();
            nekwom1Connnnection.Close();
            return EnrolledStudent;
        }

        public bool UpdateStudent(nekwomBAIST310CodeSampleEmpty.Domain.Student EnrolledStudent)
        {
            bool Success = false;
            SqlConnection nekwom1Connection = new();

            nekwom1Connection.ConnectionString = "Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1Connection.Open();

            SqlCommand ModifyStudent = new()
            {
                Connection = nekwom1Connection,
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

            ModifyStudent.Parameters.Add(StudentID);

            SqlParameter FirstName = new()
            {
                ParameterName = "@StudentFirstName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                SqlValue = EnrolledStudent.FirstName,
                Direction = System.Data.ParameterDirection.Input,
            };
            ModifyStudent.Parameters.Add(FirstName);

            SqlParameter LastName = new()
            {
                ParameterName = "@StudentLastName",
                SqlValue = EnrolledStudent.LastName,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
            };
            ModifyStudent.Parameters.Add(LastName);

            SqlParameter Email = new()
            {
                ParameterName = "@StudentEmail",
                SqlValue = EnrolledStudent.Email,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
            };
            ModifyStudent.Parameters.Add(Email);
            try
            {

                ModifyStudent.ExecuteNonQuery();
                Success = true;
                nekwom1Connection.Close();
            }

            catch (SqlException)
            {
                Success = false;
            }

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
    }
}
