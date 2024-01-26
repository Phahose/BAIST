using ClubBAISTGolfClub.Controller;
using ClubBAISTGolfClub.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubBAISTGolfClub.Pages
{
    public class TeeTimeReservationsModel : PageModel
    {
        public List<TeeTime> TeeTimeList { get; set; } = new();
        public string Email { get; set; } = string.Empty;
        public Member Member { get; set; } = new();
        [BindProperty]
        public string Submit { get; set; } = string.Empty;
        [BindProperty]
        public int TeeTimeID { get; set; }
        public TeeTime TeeTime { get; set; } = new();
        public string Message { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public void OnGet()
        {
            TeeTime = new();
            Email = HttpContext.Session.GetString("Email")!;
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            TeeTimeController teeTimeController = new();
            TeeTimeList = teeTimeController.GetMemberTeeTime(Member.MemberID);
        }

        public void OnPost()
        {
            TeeTimeController teeTimeController = new();
            MemberControlls memberControlls = new();
            switch (Submit)
            {
                case "Go":
                    Email = HttpContext.Session.GetString("Email")!;
                    Member = memberControlls.GetMember(Email);
                    TeeTime = teeTimeController.GetTeeTimeByID(TeeTimeID);
                    HttpContext.Session.SetInt32("TeeTimeID", TeeTimeID);
                    if (TeeTime.ReservationStatus == "")
                    {
                        ErrorMessage = "This Tee Time does not Exist Try A Diffrent Number";
                    }
                    if (TeeTime.MemberID != Member.MemberID)
                    {
                        TeeTime = new();
                        ErrorMessage = "You dont have this Tee Time Try A diffrent ID";
                    }
                    TeeTimeList = teeTimeController.GetMemberTeeTime(Member.MemberID);
                    break;
                case "Delete":
                    Email = HttpContext.Session.GetString("Email")!;
                    Member = memberControlls.GetMember(Email);
                    TeeTimeID = (int)HttpContext.Session.GetInt32("TeeTimeID")!;
                    Message = teeTimeController.CancelTeeTime(TeeTimeID);
                    TeeTimeList = teeTimeController.GetMemberTeeTime(Member.MemberID);
                break;
                case "Cancel":
                    Email = HttpContext.Session.GetString("Email")!;
                    Member = memberControlls.GetMember(Email);
                    TeeTime = new();
                    TeeTimeList = teeTimeController.GetMemberTeeTime(Member.MemberID);
                break;
            }
        }
        public static string GetFormattedDate(DateTime date)
        {
            string[] suffixes = { "th", "st", "nd", "rd" };

            int day = date.Day;
            string suffix = (day >= 11 && day <= 13) || (day % 10 > 3) ? suffixes[0] : suffixes[day % 10];

            return date.ToString($"MMMM d'{suffix}' yyyy");
        }
    }
}
