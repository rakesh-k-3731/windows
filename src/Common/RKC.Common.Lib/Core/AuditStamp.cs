namespace RKC.Common.Lib.Core;

public sealed record AuditStamp(DateTimeOffset CreatedOnUtc, string CreatedBy);
