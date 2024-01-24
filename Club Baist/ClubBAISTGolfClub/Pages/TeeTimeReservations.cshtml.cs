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

        public void OnGet()
        {
            Email = HttpContext.Session.GetString("Email")!;
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            TeeTimeController teeTimeController = new();
            TeeTimeList = teeTimeController.GetMemberTeeTime(Member.MemberID);
        }
    }
}
