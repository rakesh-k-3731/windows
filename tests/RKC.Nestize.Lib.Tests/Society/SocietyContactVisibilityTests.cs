using RKC.Common.Lib.Core;
using RKC.Contacts.Lib.Contacts;
using RKC.Nestize.Contracts.Society;
using RKC.Nestize.Entity.Society;
using RKC.Nestize.Lib.Society;

namespace RKC.Nestize.Lib.Tests;

public sealed class SocietyContactVisibilityTests
{
    private sealed class FixedClock : IClock
    {
        public DateTimeOffset UtcNow { get; } = new(2026, 01, 01, 0, 0, 0, TimeSpan.Zero);
    }

    [Fact]
    public void MemberWhoHidesPhone_CannotSeeOthersPhones()
    {
        var society = CreateSociety();
        var memberA = AddMember(society, "Asha", "A-101", true);
        var memberB = AddMember(society, "Bimal", "B-202", false);
        _ = AddMember(society, "Charu", "C-303", true);

        var service = new SocietyContactService(new ContactDirectoryService(new ReciprocalContactAccessPolicy()));

        var contactsVisibleToB = service.GetVisibleContacts(society, memberB.MemberId);

        Assert.Equal(memberB.PhoneNumber, contactsVisibleToB.Single(x => x.MemberId == memberB.MemberId).PhoneNumber);
        Assert.Null(contactsVisibleToB.Single(x => x.MemberId == memberA.MemberId).PhoneNumber);
    }

    [Fact]
    public void MemberWhoSharesPhone_CanSeeSharedPhonesOnly()
    {
        var society = CreateSociety();
        var memberA = AddMember(society, "Asha", "A-101", true);
        _ = AddMember(society, "Bimal", "B-202", false);
        var memberC = AddMember(society, "Charu", "C-303", true);

        var service = new SocietyContactService(new ContactDirectoryService(new ReciprocalContactAccessPolicy()));

        var contactsVisibleToA = service.GetVisibleContacts(society, memberA.MemberId);

        Assert.Equal(memberA.PhoneNumber, contactsVisibleToA.Single(x => x.MemberId == memberA.MemberId).PhoneNumber);
        Assert.Equal(memberC.PhoneNumber, contactsVisibleToA.Single(x => x.MemberId == memberC.MemberId).PhoneNumber);
        Assert.Null(contactsVisibleToA.Single(x => x.FullName == "Bimal").PhoneNumber);
    }

    private static Entity.Society.Society CreateSociety() => new(Guid.NewGuid(), "Green Residency");

    private static SocietyMember AddMember(Entity.Society.Society society, string name, string unit, bool sharesPhone)
    {
        var service = new SocietyMembershipService(new FixedClock());
        return service.AddMember(
            society,
            new MemberOnboardingRequest(
                name,
                unit,
                MembershipType.Owner,
                $"99999{Random.Shared.Next(10000, 99999)}",
                sharesPhone));
    }
}
