namespace ABCHardWare.Domian
{
    public class SalesItem
    {
        public int SaleNumber { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }
    }
}
