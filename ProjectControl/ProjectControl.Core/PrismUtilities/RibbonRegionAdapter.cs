using System;
using System.Collections.Specialized;
using System.Windows.Controls.Ribbon;
using Prism.Regions;

namespace ProjectControl.Core.PrismUtilities
{
    public class RibbonRegionAdapter : RegionAdapterBase<Ribbon>
    {
        public RibbonRegionAdapter(IRegionBehaviorFactory behaviorFactory)
            : base(behaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            if (regionTarget == null) throw new ArgumentNullException(nameof(regionTarget));

            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    foreach (var view in e.NewItems)
                        AddViewToRegion(view, regionTarget);
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                    foreach (var view in e.OldItems)
                        RemoveViewFromRegion(view, regionTarget);
            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        static void AddViewToRegion(object view, Ribbon ribbon)
        {
            if (view is RibbonTab ribbonTabItem) ribbon.Items.Add(ribbonTabItem);
        }

        static void RemoveViewFromRegion(object view, Ribbon ribbon)
        {
            if (view is RibbonTab ribbonTabItem) ribbon.Items.Remove(ribbonTabItem);
        }
    }
}