using GalaSoft.MvvmLight;
using MaterialDesignXam.Services;
using Naylah.Xamarin.Services.NavigationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.ViewModel
{
    public class AppViewModelBase :   ViewModelBase, INavigable
    {
        public new Naylah.Xamarin.Services.NavigationService.INavigationService NavigationService { get { return App.CurrentApp.NavigationService; } }
        public readonly IMessageService DialogService;

        public AppViewModelBase()
        {
            DialogService = DependencyService.Get<IMessageService>();
        }

        public virtual async Task OnNavigatedFromAsync()
        {
           
        }

        public virtual async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {

        }

        public virtual async Task OnNavigatingToAsync(object parameter, NavigationMode mode)
        {

        }
    }
}
