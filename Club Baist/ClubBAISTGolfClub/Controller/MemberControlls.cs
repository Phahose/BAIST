using ClubBAISTGolfClub.Techical_Services;
using ClubBAISTGolfClub.Domain;
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
    }
}
