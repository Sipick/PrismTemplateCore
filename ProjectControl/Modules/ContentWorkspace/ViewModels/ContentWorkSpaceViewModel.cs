using Prism.Mvvm;
using Prism.Regions;

namespace ContentWorkspace.ViewModels
{
    public class ContentWorkSpaceViewModel : BindableBase, IRegionMemberLifetime
    {
        private string _message;

        public ContentWorkSpaceViewModel()
        {
            Message = "Content workspace";
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public bool KeepAlive => false;
    }
}