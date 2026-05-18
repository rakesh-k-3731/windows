using RKC.Contacts.Contracts.Contacts;
using RKC.Nestize.Contracts.Society;
using RKC.Nestize.Entity.Society;

namespace RKC.Nestize.ViewModel.Society;

public sealed class SocietyDashboardViewModel(
    ISocietyMembershipService membershipService,
    ISocietyContactService contactService)
{
    public Entity.Society.Society? CurrentSociety { get; private set; }

    public IReadOnlyList<MemberContactInfo> VisibleContacts { get; private set; } = [];

    public void Initialize(Entity.Society.Society society)
    {
        CurrentSociety = society;
        membershipService.AssignInitialAssociationOfficeBearers(society);
    }

    public void LoadVisibleContacts(Guid viewerMemberId)
    {
        if (CurrentSociety is null)
        {
            VisibleContacts = [];
            return;
        }

        VisibleContacts = contactService.GetVisibleContacts(CurrentSociety, viewerMemberId);
    }
}
