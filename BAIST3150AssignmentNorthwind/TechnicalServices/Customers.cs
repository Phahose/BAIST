using Microsoft.Data.SqlClient;
using System.Data;
using BAIST3150AssignmentNorthwind.Domain;
using System.Runtime.CompilerServices;

namespace BAIST3150AssignmentNorthwind.TechnicalServices
{
    public class Customers
    {
        public List <Customer> GetCustomers()
        {
            List<Customer> customersList = new List <Customer>();
            SqlConnection nekwom1NorthwindConnection = new();
            nekwom1NorthwindConnection.ConnectionString = @"Persist Security Info=False;Database=NorthWind;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1NorthwindConnection.Open();

            SqlCommand GetCustomersCommand = new()
            {
                Connection = nekwom1NorthwindConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "nekwom1.GetCustomers"
            };

            SqlDataReader GetCustomersDateReader = GetCustomersCommand.ExecuteReader();

            if (GetCustomersDateReader.HasRows)
            {
                GetCustomersDateReader.Read();
                while (GetCustomersDateReader.Read())
                {

                    Customer customer = new Customer()
                    {
                        CustomerId = (string)GetCustomersDateReader["CustomerID"],
                        CompanyName = (string)GetCustomersDateReader["CompanyName"],
                        ContactName = (string)GetCustomersDateReader["ContactName"],
                        ContactTitle = (string)GetCustomersDateReader["ContactTitle"],
                        Address = (string)GetCustomersDateReader["Address"],
                        City = (string)GetCustomersDateReader["City"],
                        Region = GetCustomersDateReader["Region"]as string ?? "NULL",
                        PostalCode =GetCustomersDateReader["PostalCode"] as string ?? "NULL",
                        Country = (string)GetCustomersDateReader["Country"],
                        Phone = (string)GetCustomersDateReader["Phone"],
                        Fax = GetCustomersDateReader["Fax"] as string ?? "NULL"
                    };
                    customersList.Add(customer);
                }
            }
            return customersList;
        }

        public Customer GetCustomer(string customerID)
        {
            Customer customer = new();
            SqlConnection nekwom1NorthwindConnection = new();
            nekwom1NorthwindConnection.ConnectionString = @"Persist Security Info=False;Database=NorthWind;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1NorthwindConnection.Open();

            SqlCommand GetCustomersCommand = new()
            {
                Connection = nekwom1NorthwindConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "nekwom1.GetCustomer"
            };

            SqlParameter CustomerIDParameter = new()
            {
                ParameterName ="@CustomerID",
                SqlDbType = SqlDbType.NChar,
                SqlValue = customerID,
                Direction = ParameterDirection.Input,
            };

            GetCustomersCommand.Parameters.Add(CustomerIDParameter);    
            SqlDataReader GetCustomersDateReader = GetCustomersCommand.ExecuteReader();
            if (GetCustomersDateReader.HasRows)
            {
                GetCustomersDateReader.Read();
                customer = new Customer()
                {
                    CustomerId = (string)GetCustomersDateReader["CustomerID"],
                    CompanyName = (string)GetCustomersDateReader["CompanyName"],
                    ContactName = (string)GetCustomersDateReader["ContactName"],
                    ContactTitle = (string)GetCustomersDateReader["ContactTitle"],
                    Address = (string)GetCustomersDateReader["Address"],
                    City = (string)GetCustomersDateReader["City"],
                    Region = GetCustomersDateReader["Region"] as string ?? "NULL",
                    PostalCode = GetCustomersDateReader["PostalCode"] as string ?? "NULL",
                    Country = (string)GetCustomersDateReader["Country"],
                    Phone = (string)GetCustomersDateReader["Phone"],
                    Fax = GetCustomersDateReader["Fax"] as string ?? "NULL"
                };
            }
            return customer;
        }
    }
}
