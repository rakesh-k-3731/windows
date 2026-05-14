using RKC.Common.UI.Composition;
using RKC.Contacts.View.Contacts;
using RKC.Nestize.View.Society;

namespace RKC.Win.HostApp.Composition;

public sealed class HostModuleRegistry
{
    public IReadOnlyList<ModuleRegion> BuildShellRegions()
    {
        return
        [
            new ModuleRegion(
                "Main",
                [
                    new NestizeSocietyDashboardView(),
                    new ContactsDirectoryView()
                ])
        ];
    }
}
