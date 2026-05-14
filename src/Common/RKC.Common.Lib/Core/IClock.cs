namespace RKC.Common.Lib.Core;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
