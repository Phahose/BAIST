using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using nekwomBAIST310CodeSampleEmpty.Domain;
namespace nekwomBAIST310CodeSampleEmpty.TechnicalServices
{
    public class DatabaseUsers
    {
        private string? _connectionString;
        public DatabaseUsers() 
        {
            ConfigurationBuilder DatabaseUserBuilder = new ConfigurationBuilder();
            DatabaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUserConfiguration = DatabaseUserBuilder.Build();
            _connectionString = DatabaseUserConfiguration.GetConnectionString("nekwom1");
        }
        public DatabserUser GetDatabaseUser()
        {
            SqlConnection nekwom1connection = new();
            nekwom1connection.ConnectionString = _connectionString;
            nekwom1connection.Open();

            SqlCommand GetDatabaseUser = new()
            {
                Connection = nekwom1connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetDatabaseUser"
            };

            SqlDataReader DatabaseUserDataReader = GetDatabaseUser.ExecuteReader();
            DatabserUser CurrentDatabaseUser = new DatabserUser();
            if (DatabaseUserDataReader.HasRows)
            {
                DatabaseUserDataReader.Read();

                CurrentDatabaseUser.CurrentUser = (string)DatabaseUserDataReader["CurrentUser"];
                CurrentDatabaseUser.SystemUser = (string)DatabaseUserDataReader["SystemUser"];
                CurrentDatabaseUser.SessionUser = (string)DatabaseUserDataReader["SessionUser"];
            }

            DatabaseUserDataReader.Close();
            nekwom1connection.Close();

            return CurrentDatabaseUser; 
        }
        
        
    }
}
