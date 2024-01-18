#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBAISTGolfClub.Domain;
using ClubBAISTGolfClub.Techical_Services;
using ClubBAISTGolfClub.Controller;
using System.Security.Claims;

namespace ClubBAISTGolfClub.Pages
{
    [Authorize]
    public class MemberHomeModel : PageModel
    {
        private readonly ILogger<MemberHomeModel> _memberHome;
        public string Email { get; set; }  = string.Empty;
        public Member Member { get; set; } = new();

        public MemberHomeModel(ILogger<MemberHomeModel> memberHome)
        {
            _memberHome = memberHome;
        }
        public IActionResult OnGet()
        {
            MemberControlls memberControlls = new MemberControlls();
            Email = HttpContext.Session.GetString("Email");
            if (Email != null)
            {
                Member member = new();
                Member = memberControlls.GetMember(Email);
                return Page();
            }
            else
            {
                return RedirectToPage("/Login");
            }
            
        }
    }
}
