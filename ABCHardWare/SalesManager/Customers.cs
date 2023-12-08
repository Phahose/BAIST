using System.Data;
using ABCHardWare.Domian;
using Microsoft.Data.SqlClient;
namespace ABCHardWare.SalesManager
{
    public class Customers
    {
        public bool AddCustomer(Customer newCustomer)
        {
            bool confirmation = false;
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1Connection.Open();

            SqlCommand AddCustomerCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "AddCustomer",
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter FirstNameParameter  = new()
            {
                ParameterName = "@FirstName",
                SqlValue = newCustomer.FirstName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter LastNameParameter = new()
            {
                ParameterName = "@LastName",
                SqlValue = newCustomer.LastName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter AddressParameter = new()
            {
                ParameterName = "@Address",
                SqlValue = newCustomer.Address,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter CityParameter = new()
            {
                ParameterName = "@City",
                SqlValue = newCustomer.City,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter ProvinceParameter = new()
            {
                ParameterName = "@Province",
                SqlValue = newCustomer.Province,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter PostalCodeParameter = new()
            {
                ParameterName = "@PostalCode",
                SqlValue = newCustomer.PostalCode,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            AddCustomerCommand.Parameters.Add(FirstNameParameter);
            AddCustomerCommand.Parameters.Add(LastNameParameter);
            AddCustomerCommand.Parameters.Add(AddressParameter);
            AddCustomerCommand.Parameters.Add(CityParameter);
            AddCustomerCommand.Parameters.Add(ProvinceParameter);
            AddCustomerCommand.Parameters.Add(PostalCodeParameter);

            AddCustomerCommand.ExecuteNonQuery();
            nekwom1Connection.Close();
            return confirmation;
        }
    }
}
