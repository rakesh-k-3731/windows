using RKC.Contacts.Entity.Contacts;

namespace RKC.Contacts.Contracts.Contacts;

public interface IContactDirectoryService
{
    IReadOnlyList<MemberContactInfo> GetVisibleContacts(
        Guid viewerMemberId,
        IReadOnlyCollection<MemberContact> societyMembers);
}
