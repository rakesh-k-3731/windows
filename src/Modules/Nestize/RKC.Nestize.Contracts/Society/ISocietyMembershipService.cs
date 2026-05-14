using RKC.Nestize.Entity.Society;

namespace RKC.Nestize.Contracts.Society;

public interface ISocietyMembershipService
{
    SocietyMember AddMember(Entity.Society.Society society, MemberOnboardingRequest request);

    IReadOnlyList<AssociationOfficeBearer> AssignInitialAssociationOfficeBearers(Entity.Society.Society society);
}
