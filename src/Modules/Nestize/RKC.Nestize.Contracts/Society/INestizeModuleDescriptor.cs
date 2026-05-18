namespace RKC.Nestize.Contracts.Society;

public interface INestizeModuleDescriptor
{
    string ModuleName { get; }

    string DefaultRoute { get; }
}
