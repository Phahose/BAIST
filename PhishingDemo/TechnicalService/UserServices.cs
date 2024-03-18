using System.Data;
using Microsoft.Data.SqlClient;

namespace PhishingDemo.TechnicalService
{
    public class UserServices
    {
        private string? connectionString;
        public UserServices()
        {
            ConfigurationBuilder DatabaseUserBuilder = new ConfigurationBuilder();
            DatabaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUserConfiguration = DatabaseUserBuilder.Build();
            connectionString = DatabaseUserConfiguration.GetConnectionString("NicholasDb");
        }
        public bool AddUser(string email, string password)
        {
            bool success = false;
            SqlConnection phishingConnection = new SqlConnection();
            phishingConnection.ConnectionString = connectionString;
            phishingConnection.Open();

            SqlCommand AddUserCommand = new()
            {
                Connection = phishingConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddUser",
            };
            SqlParameter EmailParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                SqlValue = email,
                Direction = ParameterDirection.Input,
            };
            SqlParameter PasswordParameter = new()
            {
                ParameterName = "@Password",
                SqlDbType = SqlDbType.VarChar,
                SqlValue = password,
                Direction = ParameterDirection.Input,
            };

            AddUserCommand.Parameters.Add(EmailParameter);
            AddUserCommand.Parameters.Add(PasswordParameter);

            AddUserCommand.ExecuteNonQuery();
            phishingConnection.Close();

            return success;
        }
    }
}
