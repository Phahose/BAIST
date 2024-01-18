using ClubBAISTGolfClub.Domain;
using ClubBAISTGolfClub.Techical_Services;
namespace ClubBAISTGolfClub.Controller
{
    public class TeeTimeController
    {
        public bool BookReservation(TeeTime teeTime)
        {
            bool success = false;
            TeeTimeServices teeservices = new TeeTimeServices();
            success = teeservices.BooKTeeTime(teeTime);
            return success;
        }
    }
}
