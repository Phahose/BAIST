using ClubBAISTGolfClub.Domain;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClubBAISTGolfClub.Techical_Services
{
    public class MembershipServices
    {
        private string? connectionString;

        public MembershipServices()
        {
            ConfigurationBuilder DatabaseUserBuilder = new ConfigurationBuilder();
            DatabaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUserConfiguration = DatabaseUserBuilder.Build();
            connectionString = DatabaseUserConfiguration.GetConnectionString("nekwom1");
        }
        public Member CreateApplication(Member Member)
        {
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = connectionString;
            nekwom1Connection.Open();

            SqlCommand CreateApplication = new()
            {
                Connection = nekwom1Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "CreateApplication"
            };

            SqlParameter FirstNameParameter = new()
            {
                ParameterName = "@FirstName",
                SqlValue = Member.MemberFirstName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter LastNameParameter = new()
            {
                ParameterName = "@LastName",
                SqlValue = Member.MemberLastName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter AddressParameter = new()
            {
                ParameterName = "@Address",
                SqlValue = Member.MemberAddress,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter CityParameter = new()
            {
                ParameterName = "@City",
                SqlValue = Member.MemberCity,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter ProvinceParameter = new()
            {
                ParameterName = "@Province",
                SqlValue = Member.MemberProvince,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter CountryParameter = new()
            {
                ParameterName = "@Country",
                SqlValue = Member.MemberCountry,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter PostalCodeParameter = new()
            {
                ParameterName = "@PostalCode",
                SqlValue = Member.MemberPostalCode,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter PhoneParameter = new()
            {
                ParameterName = "@Phone",
                SqlValue = Member.MemberPhoneNumber,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter EmailParameter = new()
            {
                ParameterName = "@Email",
                SqlValue = Member.MemberEmail,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter PasswordParameter = new()
            {
                ParameterName = "@MemberPassword",
                SqlValue = Member.MemberPassword,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter DateOfBirthParameter = new()
            {
                ParameterName = "@DateOfBirth",
                SqlValue = Member.MemberDOB,
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
            };
            SqlParameter MembershipTypeParameter = new()
            {
                ParameterName = "@MembershipType",
                SqlValue = Member.MembershipType,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter Sponsor1IDParameter = new()
            {
                ParameterName = "@Sponsor1ID",
                SqlValue = Member.MemberSponsor1,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
            };
            SqlParameter Sponsor2IDParameter = new()
            {
                ParameterName = "@Sponsor2ID",
                SqlValue = Member.MemberSponsor2,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
            };
            SqlParameter SaltParameter = new()
            {
                ParameterName = "@Salt",
                SqlValue = Member.MemberSalt,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter ApplicationStatusParameter = new()
            {
                ParameterName = "@ApplicationStatus",
                SqlValue = "Pending",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter DateJoinedParameter = new()
            {
                ParameterName = "@DateJoined",
                SqlValue = Member.MemberDateJoined,
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
            };
            SqlParameter ApplicationFileParameter = new()
            {
                ParameterName = "@ApplicationFile",
                SqlValue = Member.ApplicationFile,
                SqlDbType = SqlDbType.VarBinary,
                Direction = ParameterDirection.Input,
            };

            CreateApplication.Parameters.Add(FirstNameParameter);
            CreateApplication.Parameters.Add(LastNameParameter);
            CreateApplication.Parameters.Add(AddressParameter);
            CreateApplication.Parameters.Add(CityParameter);
            CreateApplication.Parameters.Add(CountryParameter);
            CreateApplication.Parameters.Add(ProvinceParameter);
            CreateApplication.Parameters.Add(PostalCodeParameter);
            CreateApplication.Parameters.Add(PhoneParameter);
            CreateApplication.Parameters.Add(EmailParameter);
            CreateApplication.Parameters.Add(PasswordParameter);
            CreateApplication.Parameters.Add(DateOfBirthParameter);
            CreateApplication.Parameters.Add(MembershipTypeParameter);
            CreateApplication.Parameters.Add(Sponsor1IDParameter);
            CreateApplication.Parameters.Add(Sponsor2IDParameter);
            CreateApplication.Parameters.Add(SaltParameter);
            CreateApplication.Parameters.Add(ApplicationStatusParameter);
            CreateApplication.Parameters.Add(DateJoinedParameter);
            CreateApplication.Parameters.Add(ApplicationFileParameter);

            CreateApplication.ExecuteNonQuery();
            nekwom1Connection.Close();
            return Member;
        }
    }
}
