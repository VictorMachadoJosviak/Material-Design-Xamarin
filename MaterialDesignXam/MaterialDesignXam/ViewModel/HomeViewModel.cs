using GalaSoft.MvvmLight.Command;
using MaterialDesignXam.Services;
using MaterialDesignXam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.ViewModel
{
    public class HomeViewModel : AppViewModelBase
    {

        

        #region events with commands MVVM
        public RelayCommand NavigateAsyncCommand => new RelayCommand(async () => await NextPage());
        private async Task NextPage()
        {
            await NavigationService.NavigateAsync(new UserListPage(), null, true);
        }
        
        public RelayCommand NavigateModalAsyncCommand => new RelayCommand(async () => await NextModalPage());
        private async Task NextModalPage()
        {
            await NavigationService.NavigateModalAsync(new ModalPage(), null, true);

        }

        public RelayCommand SimpleAlertDialogCommand => new RelayCommand(async () => await SimpleAlertDialog());
        private async Task SimpleAlertDialog()
        {
            await DialogService.ShowMessage("Simple Alert", "Hello i'am a simple alert!", "ok");
        }
        public RelayCommand ConfirmAlertDialogCommand => new RelayCommand(async () => await ConfirmAlertDialog());
        private async Task ConfirmAlertDialog()
        {
            var a = await DialogService.ConfirmDialog("Confirm Dialog", "do you like this message?", "yes", "no");
            if (a)
            {
                await DialogService.ShowMessage("Yes", "i like it!", "ok");
            }
        }


        public RelayCommand NotificatioCommand => new RelayCommand(async () => await GenerateNotification());
        private async Task GenerateNotification()
        {
            if (Device.OS.Equals(TargetPlatform.Android))
            {
                INotificationService notifier = DependencyService.Get<INotificationService>();
                notifier.Notify("Hello", "I'm a notification cool!");
                //register dependence notifications android do the same for iOS and WP
            }
        }
        #endregion
    }
}
