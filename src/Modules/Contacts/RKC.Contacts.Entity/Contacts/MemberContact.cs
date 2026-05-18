namespace RKC.Contacts.Entity.Contacts;

public sealed record MemberContact(
    Guid MemberId,
    string FullName,
    string PhoneNumber,
    bool SharesPhoneNumber,
    ContactVisibilityScope VisibilityScope = ContactVisibilityScope.SocietyMembers);
