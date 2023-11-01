namespace UIRazorPagesAssignment.Domain
{
    public class Products
    {
        private int _categoryId { get; set; } = 0;
        private string _categoryName { get; set; } = string.Empty;
        private string _description { get; set; } = string.Empty;
        private byte[] picture { get; set; }

        public int CategoryId 
        {
            get { return _categoryId; } 
            set { _categoryId = value; }
        }
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }
    }
}
