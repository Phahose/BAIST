using Microsoft.Data.SqlClient;
using System.Data;
using ClubBAISTGolfClub.Domain;

namespace ClubBAISTGolfClub.Techical_Services
{
    public class SecurityManager
    {
        private string? connectionString;
        public SecurityManager()
        {
            ConfigurationBuilder DatabaseUserBuilder = new ConfigurationBuilder();
            DatabaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUserConfiguration = DatabaseUserBuilder.Build();
            connectionString = DatabaseUserConfiguration.GetConnectionString("nekwom1");
        }
        public Member GetUser(string email)
        {
            Member member = new Member();
            SqlConnection systemsConnection = new SqlConnection();
            systemsConnection.ConnectionString = connectionString;
            systemsConnection.Open();

            SqlCommand GetUser = new()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = systemsConnection,
                CommandText = "GetMember"
            };

            SqlParameter EmailParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = email
            };

            GetUser.Parameters.Add(EmailParameter);
            SqlDataReader UserReader = GetUser.ExecuteReader();

            if (UserReader.HasRows)
            {
                while (UserReader.Read())
                {
                    member.MemberFirstName = (string)UserReader["FirstName"];
                    member.MemberID = (int)UserReader["MemberID"];
                    member.MemberLastName = (string)UserReader["LastName"];
                    member.MemberPhoneNumber = (string)UserReader["Phone"];
                    member.MemberEmail = (string)UserReader["Email"];
                    member.MemberPassword = (string)UserReader["MemberPassword"];
                    member.MemberDateJoined = (DateTime)UserReader["DateJoined"];
                    member.MemberApplicationStatus = (string)UserReader["ApplicationStatus"];
                    member.MemberSponsor1 = (int)UserReader["Sponsor1ID"];
                    member.MemberSponsor2 = (int)UserReader["Sponsor2ID"];
                    member.MembershipType = (string)UserReader["MembershipType"];
                    member.MemberAddress = (string)UserReader["Address"];
                    member.MemberCountry = (string)UserReader["Country"];
                    member.MemberProvince = (string)UserReader["Province"];
                    member.MemberPostalCode = (string)UserReader["PostalCode"];
                    member.MemberSalt = (string)UserReader["Salt"];
                }
            }
            UserReader.Close();
            systemsConnection.Close();
            return member;
        }
    }
}
