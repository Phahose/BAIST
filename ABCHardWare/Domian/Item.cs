namespace ABCHardWare.Domian
{
    public class Item
    {
        public string ItemCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int QOH { get; set; }    
        public int Quantity { get; set; }
        public int Deleted { get; set; }
        public decimal Price { get; set; }
        public decimal ItemTotal { get; set; }
    }
}
