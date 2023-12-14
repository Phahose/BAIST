namespace ABCHardWare.Domian
{
    public class SalesItem
    {
        public int SaleNumber { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int ItemTotal { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
