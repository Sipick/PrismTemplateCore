using System.Windows.Controls;
using ProjectControl.Core.PrismUtilities;
using ProjectControl.Core.PrismUtilitiesInterfaces;
using ProjectExplorer.Views.RibbonTab;
using ProjectExplorer.Views.StatusBar;

namespace ProjectExplorer.Views
{
    /// <summary>
    /// Interaction logic for ProjectExplorerView.xaml
    /// </summary>
    [DependentView("RibbonTabRegion", typeof(ProjectExplorerRibbonTab))]
    [DependentView("StatusBarRegion", typeof(ProjectExplorerStatusBar))]
    public partial class ProjectExplorerView : ISupportDataContext
    {
        public ProjectExplorerView()
        {
            InitializeComponent();
        }
    }
}
