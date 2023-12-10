namespace ABCHardWare.Domian
{
    public class Item
    {
        public int ItemCode { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Deleted { get; set; }
    }
}
