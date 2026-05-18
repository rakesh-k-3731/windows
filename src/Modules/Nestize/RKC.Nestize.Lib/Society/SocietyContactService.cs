using RKC.Contacts.Contracts.Contacts;
using RKC.Contacts.Entity.Contacts;
using RKC.Nestize.Contracts.Society;
using RKC.Nestize.Entity.Society;

namespace RKC.Nestize.Lib.Society;

public sealed class SocietyContactService(IContactDirectoryService contactDirectoryService) : ISocietyContactService
{
    public IReadOnlyList<MemberContactInfo> GetVisibleContacts(Entity.Society.Society society, Guid viewerMemberId)
    {
        ArgumentNullException.ThrowIfNull(society);

        var contacts = society.Members
            .Select(member => new MemberContact(
                member.MemberId,
                member.FullName,
                member.PhoneNumber,
                member.SharesPhoneNumber,
                ContactVisibilityScope.SocietyMembers))
            .ToList();

        return contactDirectoryService.GetVisibleContacts(viewerMemberId, contacts);
    }
}
