using BAIST3150EmptyWebApi.Models;
using System.Data;
using Microsoft.Data.SqlClient;
namespace BAIST3150EmptyWebApi.TechnicalServices
{
    public class Items
    {
        public List<Item> GetItems()
        {
            SqlConnection nekwom1 = new();
            nekwom1.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1.Open();
            SqlCommand GetItemsCommand = new SqlCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItems",
                Connection = nekwom1,
            };

            SqlDataReader ItemsDataReader = GetItemsCommand.ExecuteReader();
            List<Item> Items = new List<Item>();
            if (ItemsDataReader.HasRows)
            {
                while (ItemsDataReader.Read())
                {
                    Item item = new Item(){
                        ItemNumber = (int)ItemsDataReader["ItemNumber"],
                        Description = (string)ItemsDataReader["Description"],
                        UnitPrice = (decimal)ItemsDataReader["UnitPrice"]
                    };

                    Items.Add(item);
                }
            }
            ItemsDataReader.Close();
            nekwom1.Close();    
            return Items;
        }

        public Item GetItem(int ItemNumber)
        {
            SqlConnection nekwom1 = new();
            nekwom1.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1.Open();
            SqlCommand GetItemCommand = new SqlCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItem",
                Connection = nekwom1,
            };

            SqlParameter GetItemParameter = new SqlParameter()
            {
                ParameterName ="@ItemNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = ItemNumber
            };
            GetItemCommand.Parameters.Add(GetItemParameter);

            SqlDataReader ItemReader = GetItemCommand.ExecuteReader();
            Item item = new();
            if (ItemReader.HasRows)
            {
               ItemReader.Read();
               item = new Item()
                {
                    ItemNumber = (int)ItemReader["ItemNumber"],
                    Description = (string)ItemReader["Description"],
                    UnitPrice = (decimal)ItemReader["UnitPrice"]
                }; 
            }
            ItemReader.Close();
            nekwom1.Close();
            return item;
        }

        public void AddItem (Item exampleItem)
        {
            SqlConnection nekwom1 = new();
            nekwom1.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1.Open();
            SqlCommand AddItemCommand = new SqlCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddItem",
                Connection = nekwom1,
            };
            SqlParameter DescriptionParameter = new SqlParameter()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.Description
            };
            AddItemCommand.Parameters.Add(DescriptionParameter);

            SqlParameter UnitPriceParameter = new SqlParameter()
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.Money,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.UnitPrice
            };
            AddItemCommand.Parameters.Add(UnitPriceParameter);

            AddItemCommand.ExecuteNonQuery();
            nekwom1.Close() ;
        }

        public void UpdateItem (int ItemNumber, Item exampleItem)
        {
            SqlConnection nekwom1 = new();
            nekwom1.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1.Open();
            SqlCommand UpdateItemCommand = new SqlCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateItem",
                Connection = nekwom1,
            };
            SqlParameter ItemNumberParameter = new SqlParameter()
            {
                ParameterName = "@ItemNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.ItemNumber
            };
            UpdateItemCommand.Parameters.Add(ItemNumberParameter);
            SqlParameter DescriptionParameter = new SqlParameter()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.Description
            };
            UpdateItemCommand.Parameters.Add(DescriptionParameter);

            SqlParameter UnitPriceParameter = new SqlParameter()
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.Money,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.UnitPrice
            };
            UpdateItemCommand.Parameters.Add(UnitPriceParameter);

            UpdateItemCommand.ExecuteNonQuery();
            nekwom1.Close() ;
        }

        public void DeleteItem (int ItemNumber)
        {

            SqlConnection nekwom1 = new();
            nekwom1.ConnectionString = @"Persist Security Info=False;Database=nekwom1;User ID=nekwom1;Password=Nickzone25041#;server=dev1.baist.ca";
            nekwom1.Open();
            SqlCommand DeleteItemCommand = new SqlCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteItem",
                Connection = nekwom1,
            };
            SqlParameter ItemNumberParameter = new SqlParameter()
            {
                ParameterName = "@ItemNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = ItemNumber
            };
            DeleteItemCommand.Parameters.Add(ItemNumberParameter);
            DeleteItemCommand.ExecuteNonQuery();
            nekwom1 .Close();
        }
    }
}
