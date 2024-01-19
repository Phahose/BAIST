using ClubBAISTGolfClub.Domain;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ClubBAISTGolfClub.Techical_Services
{
    public class TeeTimeServices
    {
        private string? connectionString;

        public TeeTimeServices() 
        {
            ConfigurationBuilder DatabaseUserBuilder = new ConfigurationBuilder();
            DatabaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUserConfiguration = DatabaseUserBuilder.Build();
            connectionString = DatabaseUserConfiguration.GetConnectionString("nekwom1");
        }
        public string BooKTeeTime(TeeTime teeTime)
        {
            SqlConnection nekwom1connection = new();
            nekwom1connection.ConnectionString = connectionString;
            nekwom1connection.Open();
            try
            {
                SqlCommand BookTeeTimesCommand = new()
                {
                    CommandText = "BookTeeTime",
                    CommandType = CommandType.StoredProcedure,
                    Connection = nekwom1connection
                };
                SqlParameter PlayerIdParaameter = new()
                {
                    ParameterName = "@PlayerID",
                    SqlDbType = SqlDbType.Int,
                    SqlValue = teeTime.MemberID,
                    Direction = ParameterDirection.Input,
                };
                SqlParameter DateParaameter = new()
                {
                    ParameterName = "@Date",
                    SqlDbType = SqlDbType.Date,
                    SqlValue = teeTime.Date,
                    Direction = ParameterDirection.Input,
                };
                SqlParameter TimeParaameter = new()
                {
                    ParameterName = "@Time",
                    SqlDbType = SqlDbType.Time,
                    SqlValue = teeTime.Time,
                    Direction = ParameterDirection.Input,
                };
                SqlParameter NumberOfPlayersParaameter = new()
                {
                    ParameterName = "@NumberOFPlayers",
                    SqlDbType = SqlDbType.Int,
                    SqlValue = teeTime.NumberOfPlayers,
                    Direction = ParameterDirection.Input,
                };
                BookTeeTimesCommand.Parameters.Add(PlayerIdParaameter);
                BookTeeTimesCommand.Parameters.Add(DateParaameter);
                BookTeeTimesCommand.Parameters.Add(TimeParaameter);
                BookTeeTimesCommand.Parameters.Add(NumberOfPlayersParaameter);
                BookTeeTimesCommand.ExecuteNonQuery();
                nekwom1connection.Close();             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            return "Successs";
        }
    }
}
