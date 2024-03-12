using ClubBAISTGolfClub.Controller;
using ClubBAISTGolfClub.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubBAISTGolfClub.Pages
{
    public class ShareHolderModel : PageModel
    {
        public List<Member> Members { get; set; } = new();
        public List<MemberApplications> Applications { get; set; } = new();
        public Member Member { get; set; } = new();
        public Member MemberHold { get; set; } = new();
        public string SubMember { get; set; } = string.Empty;
        [BindProperty]
        public string Submit { get; set; } = string.Empty;
        [BindProperty]
        public int MemberID { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        public string FirstName { get; set; } = string.Empty;
        [BindProperty]
        public string LastName { get; set; } = string.Empty;
        [BindProperty]
        public string ApplicationStatus { get; set; } = string.Empty;
        [BindProperty]
        public string MemberShipType { get; set; } = string.Empty;
        public void OnGet()
        {
            MemberControlls memberControlls = new MemberControlls();
            Members = memberControlls.GetAllMembers();
            Applications = memberControlls.GetAllMemberApplication();
        }
    }
}
