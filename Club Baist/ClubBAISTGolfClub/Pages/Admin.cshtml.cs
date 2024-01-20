using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBAISTGolfClub.Domain;
using ClubBAISTGolfClub.Controller;

namespace ClubBAISTGolfClub.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {
        public List<Member> Members { get; set; } = new();
        public List<MemberApplications> Applications { get; set; } = new();
        public void OnGet()
        {
            MemberControlls memberControlls = new MemberControlls();
            Members = memberControlls.GetAllMembers();
            Applications = memberControlls.GetAllMemberApplication();
        }
    }
}
