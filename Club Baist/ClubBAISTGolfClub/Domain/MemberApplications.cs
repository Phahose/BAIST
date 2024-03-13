namespace ClubBAISTGolfClub.Domain
{
    public class MemberApplications
    {
        public int ApplicationID { get; set; }
        public int ApplicantID { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string Sponsor1Name { get; set; } = string.Empty;
        public string Sponsor1Status { get; set; } = string.Empty;
        public int Sponsor1ID { get; set; } 
        public string Sponsor2Name { get; set; } = string.Empty;
        public string Sponsor2Status { get; set; } = string.Empty;
        public int Sponsor2ID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public byte[]? ApplicationFile { get; set; }
        public string ApplicationStatus { get; set; } = string.Empty;
    }
}
