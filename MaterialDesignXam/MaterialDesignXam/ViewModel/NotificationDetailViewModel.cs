using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naylah.Xamarin.Services.NavigationService;
using MaterialDesignXam.Model;
using MaterialDesignXam.MasterDetail;
using GalaSoft.MvvmLight.Command;

namespace MaterialDesignXam.ViewModel
{
    public class NotificationDetailViewModel : AppViewModelBase
    {

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            await LoadData((NotificationModel)parameter);
        }

        private async Task LoadData(NotificationModel notifiactio)
        {
            NotificationModels = notifiactio;

        }

     
        private NotificationModel _notificationModels;
        public NotificationModel NotificationModels
        {
            get { return _notificationModels; }
            set { Set(ref _notificationModels, value); }
        }

    }
}
