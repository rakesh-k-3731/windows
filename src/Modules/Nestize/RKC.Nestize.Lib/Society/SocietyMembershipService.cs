using RKC.Common.Lib.Core;
using RKC.Nestize.Contracts.Society;
using RKC.Nestize.Entity.Society;

namespace RKC.Nestize.Lib.Society;

public sealed class SocietyMembershipService(IClock clock) : ISocietyMembershipService
{
    public SocietyMember AddMember(Entity.Society.Society society, MemberOnboardingRequest request)
    {
        ArgumentNullException.ThrowIfNull(society);
        ArgumentNullException.ThrowIfNull(request);

        var member = new SocietyMember(
            Guid.NewGuid(),
            request.FullName.Trim(),
            request.UnitNumber.Trim(),
            request.MembershipType,
            request.PhoneNumber.Trim(),
            request.SharesPhoneNumber);

        society.AddMember(member);

        return member;
    }

    public IReadOnlyList<AssociationOfficeBearer> AssignInitialAssociationOfficeBearers(Entity.Society.Society society)
    {
        ArgumentNullException.ThrowIfNull(society);

        var prioritized = society.Members
            .OrderBy(m => m.UnitNumber, StringComparer.OrdinalIgnoreCase)
            .Take(3)
            .ToList();

        if (prioritized.Count < 3)
        {
            return [];
        }

        var roles = new[]
        {
            AssociationRole.President,
            AssociationRole.Secretary,
            AssociationRole.Treasurer
        };

        for (var i = 0; i < roles.Length; i++)
        {
            society.AssignOfficeBearer(new AssociationOfficeBearer(prioritized[i].MemberId, roles[i], DateOnly.FromDateTime(clock.UtcNow.UtcDateTime)));
        }

        return society.OfficeBearers;
    }
}
