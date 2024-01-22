﻿using ClubBAISTGolfClub.Domain;
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
        public Member GetUserByID(int memberID)
        {
            Member member = new Member();
            SqlConnection systemsConnection = new SqlConnection();
            systemsConnection.ConnectionString = connectionString;
            systemsConnection.Open();

            SqlCommand GetUserByID = new()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = systemsConnection,
                CommandText = "GetMemberByID"
            };

            SqlParameter MemberIdParameter = new()
            {
                ParameterName = "@MemberID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = memberID
            };

            GetUserByID.Parameters.Add(MemberIdParameter);
            SqlDataReader UserReader = GetUserByID.ExecuteReader();

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
                    member.MemberDateJoined = (DateTime)UserReader["DateOfBirth"];
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
        public List<Member> GetAllMembers()
        {
            List<Member> Members = new List<Member>();
            SqlConnection systemsConnection = new SqlConnection();
            systemsConnection.ConnectionString = connectionString;
            systemsConnection.Open();

            SqlCommand GetUserByID = new()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = systemsConnection,
                CommandText = "GetAllMembers"
            };
            SqlDataReader UserReader = GetUserByID.ExecuteReader();
            
            if (UserReader.HasRows)
            {            
                while (UserReader.Read())
                {
                    Member member = new Member();
                    member.MemberFirstName = (string)UserReader["FirstName"];
                    member.MemberID = (int)UserReader["MemberID"];
                    member.MemberLastName = (string)UserReader["LastName"];
                    member.MemberPhoneNumber = (string)UserReader["Phone"];
                    member.MemberEmail = (string)UserReader["Email"];
                    member.MemberPassword = (string)UserReader["MemberPassword"];
                    member.MemberDateJoined = (DateTime)UserReader["DateOfBirth"];
                    member.MemberApplicationStatus = (string)UserReader["ApplicationStatus"];
                    member.MemberSponsor1 = (int)UserReader["Sponsor1ID"];
                    member.MemberSponsor2 = (int)UserReader["Sponsor2ID"];
                    member.MembershipType = (string)UserReader["MembershipType"];
                    member.MemberAddress = (string)UserReader["Address"];
                    member.MemberCountry = (string)UserReader["Country"];
                    member.MemberProvince = (string)UserReader["Province"];
                    member.MemberPostalCode = (string)UserReader["PostalCode"];
                    member.MemberSalt = (string)UserReader["Salt"];
                   // member.ApplicationFile = (byte[]?)UserReader[]
                    Members.Add(member);
                }
            }
            UserReader.Close();
            systemsConnection.Close();
            return Members;
        }
        public List<MemberApplications> GetAllMemberApplications()
        {
            List<MemberApplications> MemberApplications = new List<MemberApplications>();
            SqlConnection systemsConnection = new SqlConnection();
            systemsConnection.ConnectionString = connectionString;
            systemsConnection.Open();

            SqlCommand GetAllMemberApplications = new()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = systemsConnection,
                CommandText = "GetAllMemberApplications"
            };
            SqlDataReader UserReader = GetAllMemberApplications.ExecuteReader();

            if (UserReader.HasRows)
            {
                while (UserReader.Read())
                {
                    MemberApplications memberApplication = new MemberApplications();
                    memberApplication.ApplicantID = (int)UserReader["ApplicantID"];
                    memberApplication.ApplicationID = (int)UserReader["ApplicationID"];
                    memberApplication.ApplicantName = (string)UserReader["ApplicantName"];
                    memberApplication.Sponsor1Name = (string)UserReader["Sponsor1Name"];
                    memberApplication.Sponsor2Name = (string)UserReader["Sponsor2Name"];
                    memberApplication.ApplicationDate = (DateTime)UserReader["ApplicationDate"];
                    memberApplication.ApplicationFile = (byte[]?)UserReader["ApplicationFormFile"];
                    memberApplication.ApplicationStatus = (string)UserReader["ApplicationStatus"];

                    MemberApplications.Add(memberApplication);
                }
            }
            UserReader.Close();
            systemsConnection.Close();
            return MemberApplications;
        }

        public Member UpdateMember(Member Member)
        {
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = connectionString;
            nekwom1Connection.Open();

            SqlCommand UpateMember = new()
            {
                Connection = nekwom1Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateMember"
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
           
            UpateMember.Parameters.Add(FirstNameParameter);
            UpateMember.Parameters.Add(LastNameParameter);
            UpateMember.Parameters.Add(AddressParameter);
            UpateMember.Parameters.Add(CityParameter);
            UpateMember.Parameters.Add(CountryParameter);
            UpateMember.Parameters.Add(ProvinceParameter);
            UpateMember.Parameters.Add(PostalCodeParameter);
            UpateMember.Parameters.Add(PhoneParameter);
            UpateMember.Parameters.Add(EmailParameter);
            UpateMember.Parameters.Add(DateOfBirthParameter);
            UpateMember.Parameters.Add(MembershipTypeParameter);
            UpateMember.Parameters.Add(ApplicationStatusParameter);
            UpateMember.Parameters.Add(DateJoinedParameter);

            UpateMember.ExecuteNonQuery();
            nekwom1Connection.Close();
            return Member;
        }
    }
}
