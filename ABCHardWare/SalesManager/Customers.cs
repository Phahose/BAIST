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

        public bool UpdateCustomer(Customer existingcustomer)
        {
            bool confirmation = false;
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1Connection.Open();

            SqlCommand UpdateCustomerCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "UpdateCustomer",
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter CustomerIdParameter = new()
            {
                ParameterName = "@CustomerID",
                SqlValue = existingcustomer.CustomerID,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter FirstNameParameter = new()
            {
                ParameterName = "@FirstName",
                SqlValue = existingcustomer.FirstName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter LastNameParameter = new()
            {
                ParameterName = "@LastName",
                SqlValue = existingcustomer.LastName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter AddressParameter = new()
            {
                ParameterName = "@Address",
                SqlValue = existingcustomer.Address,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter CityParameter = new()
            {
                ParameterName = "@City",
                SqlValue = existingcustomer.City,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter ProvinceParameter = new()
            {
                ParameterName = "@Province",
                SqlValue = existingcustomer.Province,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter PostalCodeParameter = new()
            {
                ParameterName = "@PostalCode",
                SqlValue = existingcustomer.PostalCode,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            SqlParameter DeletedParameter = new()
            {
                ParameterName = "@Deleted",
                SqlValue = 1,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
            };

            UpdateCustomerCommand.Parameters.Add(CustomerIdParameter);
            UpdateCustomerCommand.Parameters.Add(FirstNameParameter);
            UpdateCustomerCommand.Parameters.Add(LastNameParameter);
            UpdateCustomerCommand.Parameters.Add(AddressParameter);
            UpdateCustomerCommand.Parameters.Add(CityParameter);
            UpdateCustomerCommand.Parameters.Add(ProvinceParameter);
            UpdateCustomerCommand.Parameters.Add(PostalCodeParameter);
            UpdateCustomerCommand.Parameters.Add(DeletedParameter);

            UpdateCustomerCommand.ExecuteNonQuery();
            nekwom1Connection.Close();
            confirmation = true;

            return confirmation;
        }

        public List<Customer> FindCustomer(string FirstName , string LastName)
        {
            List<Customer> customers = new();
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1Connection.Open();

            SqlCommand FindCustomerCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "FindCustomer",
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter FirstNameParameter = new()
            {
                ParameterName = "@FirstName",
                SqlValue = FirstName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter LastNameParameter = new()
            {
                ParameterName = "@LastName",
                SqlValue = LastName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };
            FindCustomerCommand.Parameters.Add(FirstNameParameter);
            FindCustomerCommand.Parameters.Add(LastNameParameter);
            FindCustomerCommand.ExecuteNonQuery();
            SqlDataReader FindCustomerDataReader = FindCustomerCommand.ExecuteReader();

            if (FindCustomerDataReader.HasRows)
            {
                while (FindCustomerDataReader.Read())
                {
                    Customer customer = new()
                    {
                        FirstName = (string)FindCustomerDataReader["FirstName"],
                        LastName = (string)FindCustomerDataReader["LastName"],
                        Address = (string)FindCustomerDataReader["Address"],
                        City = (string)FindCustomerDataReader["City"],
                        Province = (string)FindCustomerDataReader["Province"],
                        PostalCode = (string)FindCustomerDataReader["PostalCode"],
                        CustomerID = (int)FindCustomerDataReader["CustomerID"]
                    };
                    customers.Add(customer);
                }
               
            }
            return customers;
        }
        public bool DeleteCustomer(int customerID)
        {
            bool confirmation = false;
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1Connection.Open();

            SqlCommand DeleteCustomerCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "DeleteCustomer",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter CustomerIDParameter = new()
            {
                ParameterName = "@CustomerID",
                SqlValue = customerID,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            DeleteCustomerCommand.Parameters.Add(CustomerIDParameter);

            DeleteCustomerCommand.ExecuteNonQuery();
            nekwom1Connection.Close();
            confirmation = true;
            return confirmation;
        }
    }
}
