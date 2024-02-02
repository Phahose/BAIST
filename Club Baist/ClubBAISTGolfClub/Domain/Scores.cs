namespace ClubBAISTGolfClub.Domain
{
    public class Scores
    {
        public int ScoreID { get; set; }
        public int MemberID { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int Hole1Score { get; set; }
        public int Hole2Score { get; set ; }
        public int Hole3Score { get;set; }
        public int Hole4Score { get; set; }
        public int Hole5Score { get; set; }
        public int Hole6Score { get; set; }
        public int Hole7Score { get; set; }
        public int Hole8Score { get; set; }
        public int Hole9Score { get; set; }
        public int Hole10Score { get; set; }
        public int Hole11Score { get; set; }
        public int Hole12Score { get; set; }
        public int Hole13Score { get; set; }
        public int Hole14Score { get; set; }
        public int Hole15Score { get; set; }
        public int Hole16Score { get; set; }
        public int Hole17Score { get; set; }
        public int Hole18Score { get; set; }
        public int TotalScore { get; set; }
    }
}
