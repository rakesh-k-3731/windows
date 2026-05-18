namespace RKC.Nestize.Entity.Society;

public sealed class Society
{
    private readonly List<SocietyMember> _members = [];
    private readonly List<AssociationOfficeBearer> _officeBearers = [];

    public Society(Guid societyId, string name)
    {
        SocietyId = societyId;
        Name = name;
    }

    public Guid SocietyId { get; }

    public string Name { get; }

    public IReadOnlyList<SocietyMember> Members => _members;

    public IReadOnlyList<AssociationOfficeBearer> OfficeBearers => _officeBearers;

    public void AddMember(SocietyMember member)
    {
        if (_members.Any(x => x.MemberId == member.MemberId))
        {
            return;
        }

        _members.Add(member);
    }

    public void AssignOfficeBearer(AssociationOfficeBearer officeBearer)
    {
        var duplicateRole = _officeBearers.Any(x => x.Role == officeBearer.Role);
        if (duplicateRole)
        {
            throw new InvalidOperationException($"Role {officeBearer.Role} is already assigned.");
        }

        _officeBearers.Add(officeBearer);
    }
}
