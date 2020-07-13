using ProjectExplorer.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectControl.Core;

namespace ProjectExplorer
{
    public class ProjectExplorerModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ProjectExplorerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ProjectExplorerRegion, typeof(ProjectExplorerView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}