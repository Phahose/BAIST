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

        public TeeTime GetTeeTime(DateTime date, string time)
        {
            SqlConnection nekwom1connection = new();
            nekwom1connection.ConnectionString = connectionString;
            nekwom1connection.Open();
            TeeTime teeTime = new TeeTime();
            SqlCommand GetTeeTimesCommand = new()
            {
                CommandText = "GetTeeTime",
                CommandType = CommandType.StoredProcedure,
                Connection = nekwom1connection
            };
            SqlParameter DateParaameter = new()
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.Date,
                SqlValue = date,
                Direction = ParameterDirection.Input,
            };
            SqlParameter TimeParaameter = new()
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.Time,
                SqlValue = time,
                Direction = ParameterDirection.Input,
            };
            GetTeeTimesCommand.Parameters.Add(DateParaameter);
            GetTeeTimesCommand.Parameters.Add(TimeParaameter);
            SqlDataReader teeTimeReader = GetTeeTimesCommand.ExecuteReader();

            if (teeTimeReader.HasRows)
            {
                while (teeTimeReader.Read())
                {
                    teeTime.TeeTimeID = (int)teeTimeReader["TeeTimeID"];
                    teeTime.MemberID = (int)teeTimeReader["MemberID"];
                    //teeTime.Date = (DateOnly)teeTimeReader["Date"];
                    //teeTime.Time = (Time)teeTimeReader["TeeTime"];
                    teeTime.ReservationStatus = (string)teeTimeReader["ReservationStatus"];
                    teeTime.NumberOfPlayers = (int)teeTimeReader["NumberOfPlayers"];
                }
            }
            teeTimeReader.Close();
            nekwom1connection.Close();         
            return teeTime;
        }
        public List<TeeTime> GetMemberTeeTime(int memberID)
        {
            SqlConnection nekwom1connection = new();
            nekwom1connection.ConnectionString = connectionString;
            nekwom1connection.Open();
            TeeTime teeTime = new TeeTime();
            List<TeeTime> teeTimeList = new();
            SqlCommand GetTeeTimesCommand = new()
            {
                CommandText = "GetMemberTeeTime",
                CommandType = CommandType.StoredProcedure,
                Connection = nekwom1connection
            };
            SqlParameter MemberIDParaameter = new()
            {
                ParameterName = "@MemberId",
                SqlDbType = SqlDbType.Int,
                SqlValue = memberID,
                Direction = ParameterDirection.Input,
            };
           
            GetTeeTimesCommand.Parameters.Add(MemberIDParaameter);
            SqlDataReader teeTimeReader = GetTeeTimesCommand.ExecuteReader();

            if (teeTimeReader.HasRows)
            {
                while (teeTimeReader.Read())
                {
                    teeTime = new TeeTime();
                    teeTime.TeeTimeID = (int)teeTimeReader["TeeTimeID"];
                    teeTime.MemberID = (int)teeTimeReader["MemberID"];
                    teeTime.Date = (DateTime)teeTimeReader["Date"];
                    teeTime.Time = (TimeSpan)teeTimeReader["TeeTime"];
                    teeTime.ReservationStatus = (string)teeTimeReader["ReservationStatus"];
                    teeTime.NumberOfPlayers = (int)teeTimeReader["NumberOfPlayers"];
                    teeTimeList.Add(teeTime);
                }
            }
            teeTimeReader.Close();
            nekwom1connection.Close();
            return teeTimeList;
        }
    }
}
