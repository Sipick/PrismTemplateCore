using ContentWorkspace.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectControl.Core;

namespace ContentWorkspace
{
    public class ContentWorkspaceModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ContentWorkspaceModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentWorkspaceView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}