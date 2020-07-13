using System.Windows;
using System.Windows.Controls.Ribbon;
using ContentWorkspace;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectControl.Core.PrismUtilities;
using ProjectControl.Views;
using ProjectExplorer;

namespace ProjectControl
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            var window = Container.Resolve<ShellWindow>();

            return window;
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ProjectExplorerModule>();
            moduleCatalog.AddModule<ContentWorkspaceModule>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(Ribbon), Container.Resolve<RibbonRegionAdapter>());
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);

            regionBehaviors.AddIfMissing(DependentViewRegionBehavior.BehaviorKey, typeof(DependentViewRegionBehavior));
        }
    }
}