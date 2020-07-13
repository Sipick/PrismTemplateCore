using System;
using System.Collections.Generic;
using System.Text;
using Prism.Regions;

namespace ProjectExplorer.ViewModels
{   
    public class ProjectExplorerViewModel: IRegionMemberLifetime
    {
        public bool KeepAlive => false;
    }
}
