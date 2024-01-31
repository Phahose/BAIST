#nullable disable
using ClubBAISTGolfClub.Controller;
using ClubBAISTGolfClub.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ClubBAISTGolfClub.Pages
{
    public class ScoresModel : PageModel
    {
        public Member Member { get; set; } = new();
        public string Email { get; set; } = string.Empty;
        public string MemberInfoString { get; set; } = string.Empty;
        [BindProperty]
        public int PlayerNumber { get; set; }
        [BindProperty]
        public string Submit { get; set; } = string.Empty;
        [BindProperty]
        public string Player1Name { get; set; }
        [BindProperty]
        public int Player1Handicap { get; set; }
         [BindProperty]
        public string Player2Name { get; set; }
        [BindProperty]
        public int Player2Handicap { get; set; }
         [BindProperty]
        public string Player3Name { get; set; }
        [BindProperty]
        public int Player3Handicap { get; set; }
         [BindProperty]
        public string Player4Name { get; set; }
        [BindProperty]
        public int Player4Handicap { get; set; }

        public void OnGet()
        {
            Email = HttpContext.Session.GetString("Email");
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            MemberInfoString = JsonSerializer.Serialize(Member);
            HttpContext.Session.SetString("MemberInfo", MemberInfoString);
        }
        public void OnPost()
        {
            Email = HttpContext.Session.GetString("Email");
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            MemberInfoString = JsonSerializer.Serialize(Member);
            HttpContext.Session.SetString("MemberInfo", MemberInfoString);
            switch (Submit)
            {
                case "Go":

                break;
            }
        }
    }
}
