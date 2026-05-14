namespace RKC.Nestize.Entity.Society;

public sealed record SocietyMember(
    Guid MemberId,
    string FullName,
    string UnitNumber,
    MembershipType MembershipType,
    string PhoneNumber,
    bool SharesPhoneNumber);
