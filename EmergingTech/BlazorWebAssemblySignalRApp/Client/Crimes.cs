namespace BlazorWebAssemblySignalRApp.Client
{
    public class Crime
    {
        public int CrimeId { get; set; }
        public string CrimeType { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
