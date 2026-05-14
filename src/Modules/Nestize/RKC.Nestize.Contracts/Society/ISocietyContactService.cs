using RKC.Contacts.Contracts.Contacts;
using RKC.Nestize.Entity.Society;

namespace RKC.Nestize.Contracts.Society;

public interface ISocietyContactService
{
    IReadOnlyList<MemberContactInfo> GetVisibleContacts(Society society, Guid viewerMemberId);
}
