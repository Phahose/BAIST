using Microsoft.Data.SqlClient;
using System.Data;

namespace nekwom1BAIS3150CodeSample.TechnicalServices
{
    public class Students
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
    }
}
