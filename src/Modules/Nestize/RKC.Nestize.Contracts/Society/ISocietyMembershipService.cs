using RKC.Nestize.Entity.Society;

namespace RKC.Nestize.Contracts.Society;

public interface ISocietyMembershipService
{
    SocietyMember AddMember(Society society, MemberOnboardingRequest request);

    IReadOnlyList<AssociationOfficeBearer> AssignInitialAssociationOfficeBearers(Society society);
}
