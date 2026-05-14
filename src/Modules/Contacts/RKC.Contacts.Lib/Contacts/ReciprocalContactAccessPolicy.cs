using RKC.Contacts.Contracts.Contacts;

namespace RKC.Contacts.Lib.Contacts;

public sealed class ReciprocalContactAccessPolicy : IContactAccessPolicy
{
    public bool CanViewPhone(bool viewerSharesPhone, bool targetSharesPhone)
        => viewerSharesPhone && targetSharesPhone;
}
