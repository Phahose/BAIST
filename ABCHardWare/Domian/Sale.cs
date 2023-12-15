namespace ABCHardWare.Domian
{
    public class Sale
    {
        public int SaleNumber { get; set; }
        public DateOnly SaleDate { get; set; }
        public string SalesPerson {  get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal SubTotal { get; set; }
        public decimal GST { get; set; }
        public decimal SaleTotal { get; set; }
        public List<SalesItem> SalesItems { get; set; } = new();

    }
}
