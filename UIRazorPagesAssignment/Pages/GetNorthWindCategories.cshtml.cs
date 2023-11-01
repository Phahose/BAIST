using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using UIRazorPagesAssignment.Domain;
namespace UIRazorPagesAssignment.Pages
{
    public class GetNorthWindCategoriesModel : PageModel
    {
        public List<Products> FoundProducts = new List<Products>();
        public void OnGet()
        {
            SqlConnection nekwom1Connection = new();
            nekwom1Connection.ConnectionString = "Persist Security Info=False;Integrated Security=True;Database=Northwind;server=LAPTOP-CBDT3BII\\SQLEXPRESS;TrustServerCertificate=true";
            nekwom1Connection.Open();

            SqlCommand GetCategories = new()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "GetProducts",
                Connection = nekwom1Connection
            };

     
            SqlDataReader productReader = GetCategories.ExecuteReader();

            if (productReader.HasRows)
            {
               
                productReader.Read();

                while (productReader.Read())
                {
                    Products products = new();
                    products.CategoryId = (int)productReader["CategoryID"];
                    products.CategoryName = (string)productReader["CategoryName"];
                    products.Description = (string)productReader["Description"];
                    products.Picture = (byte[])productReader["Picture"];
                    FoundProducts.Add(products);
                }
            }
        }
    }
}
