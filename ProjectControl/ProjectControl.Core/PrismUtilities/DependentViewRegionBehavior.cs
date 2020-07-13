using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Windows;
using Prism.Ioc;
using Prism.Regions;
using ProjectControl.Core.PrismUtilitiesInterfaces;

namespace ProjectControl.Core.PrismUtilities
{
    public class DependentViewRegionBehavior : RegionBehavior
    {
        public const string BehaviorKey = "DependentViewRegionBehavior";
        private readonly IContainerExtension _container;

        private readonly Dictionary<object, List<DependentViewInfo>> _dependentViewCache =
            new Dictionary<object, List<DependentViewInfo>>();

        public DependentViewRegionBehavior(IContainerExtension container)
        {
            _container = container;
        }

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    foreach (var newView in e.NewItems)
                    {
                        var dependentViews = new List<DependentViewInfo>();

                        if (_dependentViewCache.ContainsKey(newView))
                        {
                            dependentViews = _dependentViewCache[newView];
                        }
                        else
                        {
                            var attributes = GetCustomAttributes<DependentViewAttribute>(newView.GetType());
                            foreach (var att in attributes)
                            {
                                var info = CreateDependentViewInfo(att);

                                if (info.View is ISupportDataContext infoDC && newView is ISupportDataContext viewDC)
                                    infoDC.DataContext = viewDC.DataContext;

                                dependentViews.Add(info);
                            }

                            _dependentViewCache.Add(newView, dependentViews);
                        }


                        dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Add(item.View));
                    }

                    break;
                }
                case NotifyCollectionChangedAction.Remove:
                {
                    foreach (var oldView in e.OldItems)
                        if (_dependentViewCache.ContainsKey(oldView))
                        {
                            var dependentViews = _dependentViewCache[oldView];
                            dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Remove(item.View));

                            if (!ShouldKeepAlive(oldView))
                                _dependentViewCache.Remove(oldView);
                        }

                    break;
                }
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool ShouldKeepAlive(object oldView)
        {
            var regionLifetime = GetViewOrDataContextLifeTime(oldView);

            return regionLifetime == null || regionLifetime.KeepAlive;
        }

        IRegionMemberLifetime GetViewOrDataContextLifeTime(object view)
        {
            return view switch
            {
                IRegionMemberLifetime regionLifetime => regionLifetime,
                FrameworkElement fe => fe.DataContext as IRegionMemberLifetime,
                _ => null
            };
        }

        DependentViewInfo CreateDependentViewInfo(DependentViewAttribute attribute)
        {
            var info = new DependentViewInfo {Region = attribute.Region, View = _container.Resolve(attribute.Type)};

            return info;
        }

        private static IEnumerable<T> GetCustomAttributes<T>(ICustomAttributeProvider type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }
    }
}