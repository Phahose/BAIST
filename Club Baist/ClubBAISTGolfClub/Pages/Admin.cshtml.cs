using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBAISTGolfClub.Domain;
using ClubBAISTGolfClub.Controller;
using System.Text.Json;

namespace ClubBAISTGolfClub.Pages
{
    [Authorize(Roles ="Admin")]
    public class AdminModel : PageModel
    {
        public List<Member> Members { get; set; } = new();
        public List<MemberApplications> Applications { get; set; } = new();
        public Member Member { get; set; } = new();
        public Member MemberHold { get; set; } = new();
        public string SubMember { get; set; } = string.Empty;
        [BindProperty]
        public string Submit {  get; set; } = string.Empty;
        [BindProperty]
        public int MemberID { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        public string FirstName {  get; set; } = string.Empty;
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

        public void OnPost()
        {
            MemberControlls memberControlls = new MemberControlls();
            Members = memberControlls.GetAllMembers();
            Applications = memberControlls.GetAllMemberApplication();
            switch (Submit)
            {
                case "Go":
                    Member = memberControlls.GetMemberByID(MemberID);
                    SubMember = JsonSerializer.Serialize(Member);
                    HttpContext.Session.SetString("UpdatingMemberInfo", SubMember);
                    if (Member.MemberFirstName == "")
                    {
                        ErrorMessage = "This Member Dosent Exist Check the Member ID";
                    }
                break;
                case "UpdateMember":
                    SubMember = HttpContext.Session.GetString("UpdatingMemberInfo")!;
                    MemberHold = JsonSerializer.Deserialize<Member>(SubMember)!;
                    Member = new Member()
                    {
                        MemberID = MemberHold.MemberID,
                        MemberFirstName = FirstName,
                        MemberLastName = LastName,
                        MemberAddress = MemberHold.MemberAddress,
                        MemberCity = MemberHold.MemberCity,
                        MemberProvince = MemberHold.MemberProvince,
                        MemberCountry = MemberHold.MemberCountry,
                        MemberPostalCode = MemberHold.MemberPostalCode,
                        MemberEmail = MemberHold.MemberEmail,
                        MemberPhoneNumber = MemberHold.MemberPhoneNumber,
                        MemberApplicationStatus = ApplicationStatus,
                        MembershipType = MemberShipType
                    };
                    try
                    {
                        Message = "Member Updated SuccessFully";
                        memberControlls.UpdateMember(Member);
                        Members = memberControlls.GetAllMembers();
                        Applications = memberControlls.GetAllMemberApplication();
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }
                    
                break;
            }
        }
    }
}
