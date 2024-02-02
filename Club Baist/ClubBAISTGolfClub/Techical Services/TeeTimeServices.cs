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
        public bool CancelTeeTime(int teeTimeID)
        {
            SqlConnection nekwom1connection = new();
            nekwom1connection.ConnectionString = connectionString;
            bool success = true;
            nekwom1connection.Open();
            try
            {
                SqlCommand CancelTeeTimesCommand = new()
                {
                    CommandText = "CancelTeeTimeReservaion",
                    CommandType = CommandType.StoredProcedure,
                    Connection = nekwom1connection
                };
                SqlParameter TeeTimeIDParameter = new()
                {
                    ParameterName = "@TeeTimeID",
                    SqlDbType = SqlDbType.Int,
                    SqlValue = teeTimeID,
                    Direction = ParameterDirection.Input,
                };
                CancelTeeTimesCommand.Parameters.Add(TeeTimeIDParameter);
                CancelTeeTimesCommand.ExecuteNonQuery();
                nekwom1connection.Close();
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public TeeTime GetTeeTimeByID(int teeTimeID)
        {
            SqlConnection nekwom1connection = new();
            nekwom1connection.ConnectionString = connectionString;
            nekwom1connection.Open();
            TeeTime teeTime = new TeeTime();
            SqlCommand GetTeeTimesByIDCommand = new()
            {
                CommandText = "GetTeeTimeByID",
                CommandType = CommandType.StoredProcedure,
                Connection = nekwom1connection
            };
            SqlParameter TeeTimeIDParameter = new()
            {
                ParameterName = "@TeeTimeID",
                SqlDbType = SqlDbType.Int,
                SqlValue = teeTimeID,
                Direction = ParameterDirection.Input,
            };
            GetTeeTimesByIDCommand.Parameters.Add(TeeTimeIDParameter); ;
            SqlDataReader teeTimeReader = GetTeeTimesByIDCommand.ExecuteReader();

            if (teeTimeReader.HasRows)
            {
                while (teeTimeReader.Read())
                {
                    teeTime.TeeTimeID = (int)teeTimeReader["TeeTimeID"];
                    teeTime.MemberID = (int)teeTimeReader["MemberID"];
                    teeTime.Date = (DateTime)teeTimeReader["Date"];
                    teeTime.Time = (TimeSpan)teeTimeReader["TeeTime"];
                    teeTime.ReservationStatus = (string)teeTimeReader["ReservationStatus"];
                    teeTime.NumberOfPlayers = (int)teeTimeReader["NumberOfPlayers"];
                }
            }
            teeTimeReader.Close();
            nekwom1connection.Close();
            return teeTime;
        }

        public string InsertGolfScores(Scores scores)
        {
            SqlConnection nekwom1connection = new();
            nekwom1connection.ConnectionString = connectionString;
            nekwom1connection.Open();

            string success = "Scores Added Successfully";
            try
            {
                SqlCommand InsertScoresCommand = new SqlCommand
                {
                    CommandText = "InsertGolfScores",
                    CommandType = CommandType.StoredProcedure,
                    Connection = nekwom1connection
                };

                SqlParameter playerNameParameter = new SqlParameter
                {
                    ParameterName = "@PlayerName",
                    SqlDbType = SqlDbType.VarChar,
                    Value = scores.PlayerName,
                    Direction = ParameterDirection.Input
                };

                SqlParameter memberIDParameter = new SqlParameter
                {
                    ParameterName = "@MemberID",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.MemberID,
                    Direction = ParameterDirection.Input
                };

                SqlParameter dateParameter = new SqlParameter
                {
                    ParameterName = "@Date",
                    SqlDbType = SqlDbType.Date,
                    Value = scores.Date,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole1ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole1Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole1Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole2ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole2Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole2Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole3ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole3Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole3Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole4ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole4Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole4Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole5ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole5Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole5Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole6ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole6Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole6Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole7ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole7Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole7Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole8ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole8Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole8Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole9ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole9Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole9Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole10ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole10Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole10Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole11ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole11Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole11Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole12ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole12Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole12Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole13ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole13Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole13Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole14ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole14Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole14Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole15ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole15Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole15Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole16ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole16Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole16Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole17ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole17Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole17Score,
                    Direction = ParameterDirection.Input
                };

                SqlParameter hole18ScoreParameter = new SqlParameter
                {
                    ParameterName = "@Hole18Score",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.Hole18Score,
                    Direction = ParameterDirection.Input
                };
                SqlParameter TotalScoreParameter = new SqlParameter
                {
                    ParameterName = "@TotalScore",
                    SqlDbType = SqlDbType.Int,
                    Value = scores.TotalScore,
                    Direction = ParameterDirection.Input
                };

                InsertScoresCommand.Parameters.Add(playerNameParameter);
                InsertScoresCommand.Parameters.Add(memberIDParameter);
                InsertScoresCommand.Parameters.Add(dateParameter);
                InsertScoresCommand.Parameters.Add(hole1ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole2ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole3ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole4ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole5ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole6ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole7ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole8ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole9ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole10ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole11ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole12ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole13ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole14ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole15ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole16ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole17ScoreParameter);
                InsertScoresCommand.Parameters.Add(hole18ScoreParameter);
                InsertScoresCommand.Parameters.Add(TotalScoreParameter);

                InsertScoresCommand.ExecuteNonQuery();
                nekwom1connection.Close();
            }
            catch (Exception ex) 
            { 
                success = ex.Message;
            }
            return success;
        } 
    }
}
