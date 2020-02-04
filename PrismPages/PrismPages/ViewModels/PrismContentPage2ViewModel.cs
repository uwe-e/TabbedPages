using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismPages.ViewModels
{
    public class PrismContentPage2ViewModel : ViewModelBase

    {
        private ICommand _submitCommand;

        public ICommand SubmitCommand  => _submitCommand ?? (_submitCommand = new DelegateCommand(Submit, CanSubmit));
        private async void Submit()
        {
            //throw new NotImplementedException();
            await NavigationService.NavigateAsync("NavigationPage/PrismContentPage3");
        }
        bool CanSubmit()
        {
            return true;
        }

        public PrismContentPage2ViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
