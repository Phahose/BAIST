using System.Data;
using ABCHardWare.Domian;
using Microsoft.Data.SqlClient;
namespace ABCHardWare.SalesManager
{
    public class Items
    {
        public Item AddItem (Item Item)
        {
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1Connection.Open();

            SqlCommand AddItemCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "AddToInventory",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ItemCodeParameter = new()
            {
                ParameterName = "@ItemCode",
                SqlValue = Item.ItemCode,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter DescriptonParameter = new()
            {
                ParameterName = "@Description",
                SqlValue = Item.Description,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter UnitPriceParameter = new()
            {
                ParameterName = "@UnitPrice",
                SqlValue = Item.UnitPrice,
                SqlDbType = SqlDbType.Decimal,
                Direction= ParameterDirection.Input,
            };

            SqlParameter DeletedParameter = new()
            {
                ParameterName = "@Deleted",
                SqlValue = Item.Deleted,
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
            };

            AddItemCommand.Parameters.Add(ItemCodeParameter);
            AddItemCommand.Parameters.Add (DescriptonParameter);
            AddItemCommand.Parameters.Add(UnitPriceParameter);
            AddItemCommand.Parameters.Add(DeletedParameter);

            AddItemCommand.ExecuteNonQuery();
            nekwom1Connection.Close();

            return Item;
        }
    }
}
