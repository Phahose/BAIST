namespace BAIST3150EmptyWebApi.Models
{
    public class Item
    {
     
        public int ItemNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
    }
}
