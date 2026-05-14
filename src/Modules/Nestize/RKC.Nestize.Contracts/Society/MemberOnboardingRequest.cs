using RKC.Nestize.Entity.Society;

namespace RKC.Nestize.Contracts.Society;

public sealed record MemberOnboardingRequest(
    string FullName,
    string UnitNumber,
    MembershipType MembershipType,
    string PhoneNumber,
    bool SharesPhoneNumber);
