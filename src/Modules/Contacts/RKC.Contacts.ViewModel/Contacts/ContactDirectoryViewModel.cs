using RKC.Contacts.Contracts.Contacts;
using RKC.Contacts.Entity.Contacts;

namespace RKC.Contacts.ViewModel.Contacts;

public sealed class ContactDirectoryViewModel(IContactDirectoryService contactDirectoryService)
{
    public IReadOnlyList<MemberContactInfo> Contacts { get; private set; } = [];

    public void Load(Guid viewerMemberId, IReadOnlyCollection<MemberContact> members)
    {
        Contacts = contactDirectoryService.GetVisibleContacts(viewerMemberId, members);
    }
}
