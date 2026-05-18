using RKC.Contacts.Contracts.Contacts;
using RKC.Contacts.Entity.Contacts;

namespace RKC.Contacts.Lib.Contacts;

public sealed class ContactDirectoryService(IContactAccessPolicy accessPolicy) : IContactDirectoryService
{
    public IReadOnlyList<MemberContactInfo> GetVisibleContacts(
        Guid viewerMemberId,
        IReadOnlyCollection<MemberContact> societyMembers)
    {
        var viewer = societyMembers.FirstOrDefault(x => x.MemberId == viewerMemberId);
        if (viewer is null)
        {
            return [];
        }

        return societyMembers
            .Select(member =>
            {
                if (member.MemberId == viewerMemberId)
                {
                    return new MemberContactInfo(member.MemberId, member.FullName, member.PhoneNumber);
                }

                var canView = member.VisibilityScope == ContactVisibilityScope.SocietyMembers
                              && accessPolicy.CanViewPhone(viewer.SharesPhoneNumber, member.SharesPhoneNumber);

                return new MemberContactInfo(member.MemberId, member.FullName, canView ? member.PhoneNumber : null);
            })
            .ToList();
    }
}
