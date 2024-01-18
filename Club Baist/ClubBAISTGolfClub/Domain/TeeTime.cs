namespace ClubBAISTGolfClub.Domain
{
    public class TeeTime
    {
        public int TeeTimeID { get; set; }
        public int MemberID { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public int NumberOfPlayers { get; set; }
        public string ReservationStatus { get; set; } = string.Empty;
    }
}
