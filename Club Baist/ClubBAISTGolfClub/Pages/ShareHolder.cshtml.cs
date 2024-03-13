using ClubBAISTGolfClub.Controller;
using ClubBAISTGolfClub.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ClubBAISTGolfClub.Pages
{
    public class ShareHolderModel : PageModel
    {
        public List<Member> Members { get; set; } = new();
        public List<MemberApplications> Applications { get; set; } = new();
        public Member Member { get; set; } = new();
        public MemberApplications ApplicationHold { get; set; } = new();
        public string SubApplication { get; set; } = string.Empty;
        [BindProperty]
        public string Submit { get; set; } = string.Empty;
        [BindProperty]
        public int MemberID { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        public string ApplicationStatus { get; set; } = string.Empty;
        [BindProperty]
        public string MemberShipType { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public MemberApplications Application { get; set; } = new();
        public bool ApplicationFound {  get; set; } = false;

        [BindProperty]
        public int ApplicationID { get; set; }
        [BindProperty]
        public string Sponsor1Status { get; set; } = string.Empty;
        [BindProperty]
        public string Sponsor2Status {  get; set; } = string.Empty; 
        public void OnGet()
        {
            MemberControlls memberControlls = new MemberControlls();
            Email = HttpContext.Session.GetString("Email")!;
            Member = memberControlls.GetMember(Email);
            Members = memberControlls.GetAllMembers();
            Applications = memberControlls.GetAllMemberApplication();
            Applications =  Applications.Where( m => m.Sponsor1ID == Member.MemberID).ToList();
            if (Applications.Count < 1)
            {
                Applications = memberControlls.GetAllMemberApplication();
                Applications = Applications.Where(m => m.Sponsor2ID == Member.MemberID).ToList();
            }
        }
        public void OnPost()
        {
            MemberControlls memberControlls = new MemberControlls();
            Members = memberControlls.GetAllMembers();
            Applications = memberControlls.GetAllMemberApplication();

            switch (Submit)
            {
                case "Go":
                    Application = Applications.Where((m) => m.ApplicantID == ApplicationID).FirstOrDefault()!;
                    SubApplication = JsonSerializer.Serialize(Application);
                    HttpContext.Session.SetString("UpdatingApplicationInfo", SubApplication);
                    if (Application == null)
                    {
                        ErrorMessage = "This Application Dosent Exist Check the Application ID";
                    }
                    else
                    {
                        ApplicationFound = true;
                    }
                break;
                case "UpdateMember":
                    Email = HttpContext.Session.GetString("Email")!;
                    Member = memberControlls.GetMember(Email);
                    SubApplication = HttpContext.Session.GetString("UpdatingApplicationInfo")!;
                    ApplicationHold = JsonSerializer.Deserialize<MemberApplications>(SubApplication)!;
                    if (ApplicationHold.Sponsor1ID == Member.MemberID)
                    {
                        Application = new MemberApplications()
                        {
                            ApplicationID = ApplicationHold.ApplicationID,
                            Sponsor1Status = Sponsor1Status,
                            Sponsor2Status = ApplicationHold.Sponsor2Status
                        };
                    }
                    if (ApplicationHold.Sponsor2ID == Member.MemberID)
                    {
                        Application = new MemberApplications()
                        {
                            ApplicationID = ApplicationHold.ApplicationID,
                            Sponsor1Status = ApplicationHold.Sponsor1Status,
                            Sponsor2Status = Sponsor2Status
                        };
                    }
                    
                    memberControlls.UpdateMemberApplications(Application);
                break;
            }

            Email = HttpContext.Session.GetString("Email")!;
            Member = memberControlls.GetMember(Email);
            Applications = memberControlls.GetAllMemberApplication();
            Applications = Applications.Where(m => m.Sponsor1ID == Member.MemberID).ToList();
            if (Applications.Count < 1)
            {
                Applications = memberControlls.GetAllMemberApplication();
                Applications = Applications.Where(m => m.Sponsor2ID == Member.MemberID).ToList();
            }
        }

    }
}
