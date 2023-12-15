using ABCHardWare.Domian;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ABCHardWare.SalesManager
{
    public class Sales
    {
        private string? connectionString;
        public Sales()
        {
            ConfigurationBuilder DatabaseUserBuilder = new ConfigurationBuilder();
            DatabaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUserConfiguration = DatabaseUserBuilder.Build();
            connectionString = DatabaseUserConfiguration.GetConnectionString("nekwom1");
        }
        public int AddSaleItem(List<SalesItem> salesItemList)
        {
            int saleNumber = 1;
            foreach (SalesItem item in salesItemList)
            {
                SqlConnection nekwom1Connection = new();
                nekwom1Connection.ConnectionString = connectionString;
                nekwom1Connection.Open();

                SqlCommand AddSaleItemCommand = new()
                {
                    Connection = nekwom1Connection,
                    CommandText = "AddSaleItem",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter SaleNumberParameter = new()
                {
                    ParameterName = "@SaleNumber",
                    SqlValue = item.SaleNumber,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                };

                SqlParameter QuantityParameter = new()
                {
                    ParameterName = "@Quantity",
                    SqlValue = item.Quantity,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                };

                SqlParameter ItemTotalParameter = new()
                {
                    ParameterName = "@ItemTotal",
                    SqlValue = item.ItemTotal,
                    SqlDbType = SqlDbType.Decimal,
                    Direction = ParameterDirection.Input,
                };

                SqlParameter ItemCodeParameter = new()
                {
                    ParameterName = "@ItemCode",
                    SqlValue = item.ItemCode,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                };
                saleNumber = item.SaleNumber;
                AddSaleItemCommand.Parameters.Add(SaleNumberParameter);
                AddSaleItemCommand.Parameters.Add(QuantityParameter);
                AddSaleItemCommand.Parameters.Add(ItemTotalParameter);
                AddSaleItemCommand.Parameters.Add(ItemCodeParameter);

                AddSaleItemCommand.ExecuteNonQuery();
                nekwom1Connection.Close();
                
            }
            return saleNumber;
        }
        public int AddSale(Sale sale)
        {
            int saleNumber;
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = connectionString;
            nekwom1Connection.Open();

            SqlCommand AddSaleCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "AddSale",
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter SaleNumberParameter = new()
            {
                ParameterName = "@SaleNumber",
                    SqlValue = sale.SaleNumber,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
            };

            SqlParameter SaleDateParameter = new()
            {
                ParameterName = "@SaleDate",
                SqlValue = sale.SaleDate,
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
            };

            SqlParameter SalesPersonParemeter = new()
            {
                ParameterName = "@Salesperson",
                SqlValue = sale.SalesPerson,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter FirstNameParameter = new()
            {
                ParameterName = "@FirstName",
                SqlValue = sale.FirstName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter LastNameParameter = new()
            {
                ParameterName = "@LastName",
                SqlValue = sale.LastName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter SubTotalParameter = new()
            {
                ParameterName = "@SubTotal",
                SqlValue = sale.SubTotal,
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
            };
            SqlParameter GstParameter = new()
            {
                ParameterName = "@GST",
                SqlValue = sale.GST,
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
            };
            SqlParameter SaleTotalParameter = new()
            {
                ParameterName = "@SaleTotal",
                SqlValue = sale.SaleTotal,
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
            };

            AddSaleCommand.Parameters.Add(SaleNumberParameter);
            AddSaleCommand.Parameters.Add(SaleDateParameter);
            AddSaleCommand.Parameters.Add(SalesPersonParemeter);
            AddSaleCommand.Parameters.Add(FirstNameParameter);
            AddSaleCommand.Parameters.Add(LastNameParameter);
            AddSaleCommand.Parameters.Add(SubTotalParameter);
            AddSaleCommand.Parameters.Add(GstParameter);
            AddSaleCommand.Parameters.Add(SaleTotalParameter);

            saleNumber = sale.SaleNumber;
            AddSaleCommand.ExecuteNonQuery();
            nekwom1Connection.Close();


            return saleNumber;
        }
       
    }
}
