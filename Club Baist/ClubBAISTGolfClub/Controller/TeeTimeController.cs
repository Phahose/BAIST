﻿using ClubBAISTGolfClub.Domain;
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
        public TeeTime GetTeeTime(DateOnly date, string time)
        {
            TeeTime teeTime = new TeeTime();
            TeeTimeServices teeservices = new TeeTimeServices();
            teeTime = teeservices.GetTeeTime(date, time);
            return teeTime;
        }
    }
}
