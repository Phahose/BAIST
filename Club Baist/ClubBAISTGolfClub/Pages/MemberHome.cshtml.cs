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
        [BindProperty]
        public string Email { get; set; }  = string.Empty;
        [BindProperty]
        public string FirstName { get; set; } = string.Empty;
        [BindProperty]
        public string LastName { get; set; } = string.Empty;
        [BindProperty]
        public string Address { get; set; } = string.Empty;
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string Submit {  get; set; } = string.Empty; 
        public Member Member { get; set; } = new();
        public bool Delete { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public Member MemberHold { get; set; } = new();
        public List<MemberApplications> Applications { get; set; } = new();
        public MemberApplications MemberApplication { get; set; } = new();

        public MemberHomeModel(ILogger<MemberHomeModel> memberHome)
        {
            _memberHome = memberHome;
        }
        public IActionResult OnGet()
        {
            MemberControlls memberControlls = new MemberControlls();
            Email = HttpContext.Session.GetString("Email");
            Applications = memberControlls.GetAllMemberApplication();
            if (Email != null)
            {
                Member = memberControlls.GetMember(Email);
                MemberHold = memberControlls.GetMember(Email);
                MemberApplication = Applications.Where(a => a.ApplicantID == Member.MemberID).FirstOrDefault();
                return Page();
            }
            else
            {
                return RedirectToPage("/Login");
            }          
        }
        public IActionResult OnPost()
        {
            MemberControlls memberControlls = new MemberControlls();
            Email = HttpContext.Session.GetString("Email");
            Applications = memberControlls.GetAllMemberApplication();
           
            if (Email != null)
            {
                Member = memberControlls.GetMember(Email);
                MemberHold = memberControlls.GetMember(Email);
                MemberApplication = Applications.Where(a => a.ApplicantID == Member.MemberID).FirstOrDefault();
            }
            
            switch (Submit)
            {
                case "UpdateAccount":
                ModelState.Clear();
                if (Email.Length <= 0)
                {
                  ModelState.AddModelError("Email","The Email Cannot Be Empty");
                }
                else if (FirstName.Length <= 0)
                {
                  ModelState.AddModelError("FirstName", "The FirstName Cannot Be Empty");
                }
                else if (LastName.Length <= 0)
                {
                  ModelState.AddModelError("LastName", "The LastName Cannot Be Empty");
                }
                else if (PhoneNumber.Length <= 0 ) 
                {
                  ModelState.AddModelError("PhoneNumber", "The PhoneNumber Cannot Be Empty");
                }
                else if (Address.Length <= 0 )
                {
                  ModelState.AddModelError("Address", "The Address Cannot Be Empty");
                }

                if (ModelState.IsValid)
                {
                    memberControlls = new MemberControlls(); 
                    Member = new() 
                    { 
                        MemberID = MemberHold.MemberID,
                        MemberEmail = Email,
                        MemberFirstName = FirstName,
                        MemberLastName = LastName,
                        MemberPhoneNumber = PhoneNumber,
                        MemberAddress = Address,
                        MemberCity = MemberHold.MemberCity,
                        MemberProvince = MemberHold.MemberProvince,
                        MemberPostalCode = MemberHold.MemberPostalCode,
                        MemberCountry = MemberHold.MemberCountry,
                        MemberApplicationStatus = MemberHold.MemberApplicationStatus,
                        MembershipType = MemberHold.MembershipType,
                    };
                    try
                    {
                      Message = "Member Updated SuccessFully";
                      memberControlls.UpdateMember(Member);
                        if (Email != null)
                        {
                            Member = memberControlls.GetMember(Email);
                            MemberHold = memberControlls.GetMember(Email);
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }
                    
                }
                break;
                case "DeleteAccount":
                    Delete = true;
                break;
                case "Cancel":
                     Delete = false;
                break;
                case "Delete":
                   Message =  memberControlls.DeleteMemberShip(Member.MemberID);
                    Email = HttpContext.Session.GetString("Email");
                    if (Email != null)
                    {
                        Member = memberControlls.GetMember(Email);
                        MemberHold = memberControlls.GetMember(Email);
                    }
                    HttpContext.Session.Clear();
                    break;     
            }
            if (Member.MemberFirstName == "")
            {
                return RedirectToPage("/SignUp");
            }
            return Page();
        }
    }
}
