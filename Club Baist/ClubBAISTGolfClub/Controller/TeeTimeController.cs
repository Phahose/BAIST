using ClubBAISTGolfClub.Domain;
using ClubBAISTGolfClub.Techical_Services;
namespace ClubBAISTGolfClub.Controller
{
    public class TeeTimeController
    {
        public string BookReservation(TeeTime teeTime)
        {
            string message = "";
            TeeTimeServices teeservices = new TeeTimeServices();
            try
            {
                message = teeservices.BooKTeeTime(teeTime);
                message = "Tee Time Booked Successfully";
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            
            return message;
        }
        public TeeTime GetTeeTime(DateTime date, string time)
        {
            TeeTime teeTime = new TeeTime();
            TeeTimeServices teeservices = new TeeTimeServices();
            teeTime = teeservices.GetTeeTime(date, time);
            return teeTime;
        }
        public List<TeeTime> GetMemberTeeTime(int memberID)
        {
            List<TeeTime> teeTime = new();
            TeeTimeServices teeservices = new TeeTimeServices();
            teeTime = teeservices.GetMemberTeeTime(memberID);
            return teeTime;
        }
        public string CancelTeeTime(int teeTimeID)
        {
            string message = "Tee Time Cancelled Sucssess Fully";
            TeeTimeServices teeTimeServices = new();
            try
            {
                teeTimeServices.CancelTeeTime(teeTimeID);
            }
            catch (Exception ex)
            {
               message= ex.Message;
            }

            return message;
        }
        public TeeTime GetTeeTimeByID(int teeTimeID)
        {
            TeeTimeServices teeservices = new TeeTimeServices();
            TeeTime teeTime = new TeeTime();
            teeTime = teeservices.GetTeeTimeByID(teeTimeID);
            return teeTime;
        }
        public string InsertGolfScores(Scores scores)
        {
            TeeTimeServices teeservices = new TeeTimeServices();
            string success;
            success = teeservices.InsertGolfScores(scores);
            return success;
        }

        public List<Scores> GetGolfScores(DateTime date, int memberID)
        {
            TeeTimeServices teeTimeServices = new();
            List<Scores> scores = new List<Scores>();
            scores = teeTimeServices.GolfScores(date, memberID);
            return scores;
        }
    }
}
