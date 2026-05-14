namespace RKC.Nestize.Entity.Society;

public sealed record AssociationOfficeBearer(Guid MemberId, AssociationRole Role, DateOnly EffectiveFrom);
