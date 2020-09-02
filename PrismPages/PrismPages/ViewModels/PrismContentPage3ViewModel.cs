using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace PrismPages.ViewModels
{
    public class PrismContentPage3ViewModel : ViewModelBase
    {
        private bool _isFlyoutOpen;
        private DelegateCommand<object> _openFlyoutCommand;

        public DelegateCommand<object> OpenFlyoutCommand => _openFlyoutCommand
            ?? (_openFlyoutCommand = new DelegateCommand<object>(OpenFlyout));

        public bool IsFlyoutOpen
        {
            get { return _isFlyoutOpen; }
            set { SetProperty(ref _isFlyoutOpen, value); }
        }

        private void OpenFlyout(object obj)
        {
            IsFlyoutOpen = !IsFlyoutOpen;
        }

        public ObservableCollection<string> Items => new ObservableCollection<string>
        {
            "Item1","Item2","Item3","Item4","Item5", "Item6","Item7","Item8","Item9","Item10","Item11","Item12","Item13","Item14","Item15", "Item16","Item17","Item18","Item19","Item20"
        };

        public PrismContentPage3ViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
