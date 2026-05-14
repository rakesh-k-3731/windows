namespace RKC.Win.HostApp.Composition;

public sealed class HostAppDescriptor
{
    public string Name => "RKC Windows Host App";

    public string Namespace => "RKC.Win.HostApp";

    public bool SupportsIndependentModules => true;
}
