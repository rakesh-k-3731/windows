namespace RKC.Contacts.Contracts.Contacts;

public sealed record MemberContactInfo(Guid MemberId, string FullName, string? PhoneNumber);
