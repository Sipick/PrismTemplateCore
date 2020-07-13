using Prism.Mvvm;
using Prism.Navigation;

namespace ProjectControl.Core.PrismUtilities
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
