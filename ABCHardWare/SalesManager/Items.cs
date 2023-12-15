using System.Data;
using ABCHardWare.Domian;
using Microsoft.Data.SqlClient;
namespace ABCHardWare.SalesManager
{
    public class Items
    {
        private string? connectionString;
        public Items()
        {
            ConfigurationBuilder DatabaseUserBuilder = new ConfigurationBuilder();
            DatabaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUserConfiguration = DatabaseUserBuilder.Build();
            connectionString = DatabaseUserConfiguration.GetConnectionString("nekwom1");
        }
        public Item AddItem (Item Item)
        {
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = connectionString;
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

            SqlParameter QOHParameter = new()
            {
                ParameterName = "@QOH",
                SqlValue = Item.QOH,
                SqlDbType = SqlDbType.Int,
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
            AddItemCommand.Parameters.Add(QOHParameter);

            AddItemCommand.ExecuteNonQuery();
            nekwom1Connection.Close();

            return Item;
        }

        public Item FindItem(string itemCode)
        {
            Item inventoryItem = new();
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = connectionString;
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
                    QOH = (int)itemReader["QOH"],
                    Deleted = (int)itemReader["Deleted"]
                };

                itemReader.Close();
                nekwom1Connection.Close();
            }
            return inventoryItem;
        }

        public bool UpdateItem (Item existingItem)
        {
            bool confirmation = false;
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = connectionString;
            nekwom1Connection.Open();

            SqlCommand UpdateItemCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "UpdateInventory",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ItemCodeParameter = new()
            {
                ParameterName = "@ItemCode",
                SqlValue = existingItem.ItemCode,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter DescriptonParameter = new()
            {
                ParameterName = "@Description",
                SqlValue = existingItem.Description,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            SqlParameter UnitPriceParameter = new()
            {
                ParameterName = "@UnitPrice",
                SqlValue = existingItem.UnitPrice,
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
            };

            SqlParameter QOHParameter = new()
            {
                ParameterName = "@QOH",
                SqlValue = existingItem.QOH,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
            };

            SqlParameter DeletedParameter = new()
            {
                ParameterName = "@Deleted",
                SqlValue = existingItem.Deleted,
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
            };

            UpdateItemCommand.Parameters.Add(ItemCodeParameter);
            UpdateItemCommand.Parameters.Add(DescriptonParameter);
            UpdateItemCommand.Parameters.Add(UnitPriceParameter);
            UpdateItemCommand.Parameters.Add(DeletedParameter);
            UpdateItemCommand.Parameters.Add(QOHParameter);

            UpdateItemCommand.ExecuteNonQuery();
            confirmation = true;

            return confirmation;
        }

        public bool DeleteItem(string itemCode)
        {
            bool confirmation = false;
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = connectionString; ;
            nekwom1Connection.Open();

            SqlCommand DeleteItemCommand = new()
            {
                Connection = nekwom1Connection,
                CommandText = "DeleteFromInventory",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ItemCodeParameter = new()
            {
                ParameterName = "@ItemCode",
                SqlValue = itemCode,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
            };

            DeleteItemCommand.Parameters.Add(ItemCodeParameter);

            DeleteItemCommand.ExecuteNonQuery();
            nekwom1Connection.Close();
            confirmation = true;
            return confirmation;
        }
    }
}
