namespace ABCHardWare.Domian
{
    public class Items
    {
        public string ItemCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Deleted { get; set; }
    }
}
