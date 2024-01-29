using ClubBAISTGolfClub.Controller;
using ClubBAISTGolfClub.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

#nullable disable
namespace ClubBAISTGolfClub.Pages
{
    public class ScoresModel : PageModel
    {
        public Member Member { get; set; } = new();
        public string Email { get; set; } = string.Empty;
        public string MemberInfoString { get; set; } = string.Empty;
        public void OnGet()
        {
            Email = HttpContext.Session.GetString("Email");
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            MemberInfoString = JsonSerializer.Serialize(Member);
            HttpContext.Session.SetString("MemberInfo", MemberInfoString);
        }
    }
}
