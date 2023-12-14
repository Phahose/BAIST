using ABCHardWare.Domian;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ABCHardWare.SalesManager
{
    public class Sales
    {
        public Sale AddSale()
        {
            Sale sale = new Sale();

            return sale;
        }
        /*public SalesItem FindItem(string itemCode)
        {
            SalesItem inventoryItem = new();
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1Connection.Open();

            SqlCommand FindItemCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "FindItem",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ItemCodeParameter = new()
            {
                ParameterName = "@ItemCode",
                SqlValue = itemCode,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            FindItemCommand.Parameters.Add(ItemCodeParameter);

            SqlDataReader itemReader = FindItemCommand.ExecuteReader();
            if (itemReader.HasRows)
            {
                itemReader.Read();
                inventoryItem = new()
                {
                    ItemCode = (string)itemReader["ItemCode"],
                    Description = (string)itemReader["Description"],
                    UnitPrice = (decimal)itemReader["UnitPrice"],
                    Deleted = (int)itemReader["Deleted"]
                };

                itemReader.Close();
                nekwom1Connection.Close();
            }
            return inventoryItem;
        }
*/
    }
}
