using ClubBAISTGolfClub.Techical_Services;
using ClubBAISTGolfClub.Domain;
using System.Security.Cryptography;

namespace ClubBAISTGolfClub.Controller
{
    public class MemberControlls
    {
        public Member CreateMembership(Member member)
        { 
            MembershipServices membershipServices = new MembershipServices();
            member = membershipServices.CreateApplication(member);
            return member;
        }
        public Member UpdateMember(Member member)
        {
            MembershipServices membershipServices = new MembershipServices();
            member = membershipServices.UpdateMember(member);
            return member;
        }
        public MemberApplications UpdateMemberApplications(MemberApplications memberApplications)
        {
            MembershipServices membershipServices = new MembershipServices();
            memberApplications = membershipServices.UpdateMemberApplication(memberApplications);
            return memberApplications;
        }

        public void AddUser(Member addeduser)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            byte[] hashedPassword = HashPasswordWithSalt(addeduser.MemberPassword, salt);

            // Convert the salt and hashed password to Base64 for storage
            string saltBase64 = Convert.ToBase64String(salt);
            string hashedPasswordBase64 = Convert.ToBase64String(hashedPassword);

            SecurityManager controll = new SecurityManager();
            addeduser.MemberPassword = hashedPasswordBase64;
            addeduser.MemberSalt = saltBase64;
            Console.WriteLine(addeduser.MemberPassword);
            CreateMembership(addeduser);
        }
        public Member GetMember(string existingUseremail)
        {
            Member member = new Member();
            SecurityManager controll = new SecurityManager();
            member = controll.GetUser(existingUseremail);

            return member;
        }
        public Member GetMemberByID(int memberID)
        {
            Member member = new Member();
            MembershipServices membercontroll = new MembershipServices();
            member = membercontroll.GetUserByID(memberID);
            return member;
        }
        public List<Member> GetAllMembers()
        {
            List<Member> Members = new();
            MembershipServices membercontroll = new MembershipServices();
            Members = membercontroll.GetAllMembers();
            return Members;
        }
        public List<MemberApplications> GetAllMemberApplication()
        {
            List<MemberApplications> MemberApplications = new();
            MembershipServices membercontroll = new MembershipServices();
            MemberApplications = membercontroll.GetAllMemberApplications();
            return MemberApplications;
        }

        public string DeleteMemberShip(int memberID)
        {
            string message = "Account Deleted Sucssess Fully";
            MembershipServices membercontroll = new();
            try
            {
                membercontroll.DeleteAccount(memberID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

        private static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            // Hash the password with PBKDF2 using HMACSHA256
            return new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256).GetBytes(32);
        }
    }
}
