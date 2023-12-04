﻿using BAIS3110___Authentication__1.Domain;
using Microsoft.Data.SqlClient;
using System.Data;
namespace BAIS3110___Authentication__1.Technical_Services
{
    public class Controls
    {
        public bool AddUser(User user)
        {
            bool confirmation = true;
            SqlConnection systemsConnection = new SqlConnection();
            systemsConnection.ConnectionString = "Persist Security Info=False;Integrated Security=True;Database=Systems;server=(localDB)\\MSSQLLocalDB";
            systemsConnection.Open();

            SqlCommand AddUser = new()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = systemsConnection,
                CommandText = "AddUser"
            };
            SqlParameter UserNameParameter = new()
            {
                ParameterName = "@Username",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = user.Username
            };
            SqlParameter EmailParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = user.Email
            };
            SqlParameter PasswordParameter = new()
            {
                ParameterName = "@UserPassword",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = user.Password
            };
            SqlParameter UserRoleParemeter = new()
            {
                ParameterName = "@UserRole",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = user.Role
            };
            AddUser.Parameters.Add(UserNameParameter);
            AddUser.Parameters.Add(EmailParameter);
            AddUser.Parameters.Add(PasswordParameter);
            AddUser.Parameters.Add(UserRoleParemeter);

            AddUser.ExecuteNonQuery();

            systemsConnection.Close();
            return confirmation;
        }
    }
}
