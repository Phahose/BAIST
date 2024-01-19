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
            message = teeservices.BooKTeeTime(teeTime);
            return message;
        }
    }
}
