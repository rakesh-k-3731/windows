namespace RKC.Contacts.Contracts.Contacts;

public interface IContactAccessPolicy
{
    bool CanViewPhone(bool viewerSharesPhone, bool targetSharesPhone);
}
