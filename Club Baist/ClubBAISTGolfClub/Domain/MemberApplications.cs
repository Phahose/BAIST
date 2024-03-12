namespace ClubBAISTGolfClub.Domain
{
    public class MemberApplications
    {
        public int ApplicationID { get; set; }
        public int ApplicantID { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string Sponsor1Name { get; set; } = string.Empty;
        public string Sponsor1ID { get; set; } = string.Empty;
        public string Sponsor2Name { get; set; } = string.Empty;
        public string Sponsor2ID { get; set; } = string.Empty;
        public DateTime ApplicationDate { get; set; }
        public byte[]? ApplicationFile { get; set; }
        public string ApplicationStatus { get; set; } = string.Empty;
    }
}
