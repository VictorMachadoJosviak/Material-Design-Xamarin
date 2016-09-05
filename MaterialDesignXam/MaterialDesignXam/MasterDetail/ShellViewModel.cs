using MaterialDesignXam.Model;
using MaterialDesignXam.ViewModel;
using MaterialDesignXam.Views;
using Naylah.Xamarin.Services.NavigationService;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.MasterDetail
{
    public class ShellViewModel : AppViewModelBase
    {
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            await LoadData();
        }

        public override async Task OnNavigatingToAsync(object parameter, NavigationMode mode)
        {
            resetProps();
        }

        private void resetProps()
        {
            Notification.Title = null;
            Notification.Message = null;
        }

        public async Task LoadData()
        {
            Notification = App.ItemsNotification;

            if (Notification.Title != null && Notification.Message != null)
            {

                
                await NavigateToSelectedMenuItem(MenuListData.Dashboard);
                await NavigationService.NavigateAsync(new NotificationDetailPage(), Notification, true);
            }
            else
            {
                await NavigateToSelectedMenuItem(MenuListData.Dashboard);
            }
        }

      

        private NotificationModel _notification;
        public NotificationModel Notification
        {
            get { return _notification; }
            set { Set(ref _notification, value); }
        }

        public async Task NavigateToSelectedMenuItem(NavMenuItem navMenuItem)
        {

            if (navMenuItem == null)
                return;

            try
            {
                Page displayPage = (Page)Activator.CreateInstance(navMenuItem.TargetType);

                if (navMenuItem == MenuListData.Dashboard)
                {
                    await NavigationService.NavigateSetRootAsync(displayPage, null, true);
                }
                else
                {
                    await NavigationService.ClearHistory();
                    await NavigationService.NavigateAsync(displayPage, null, true);
                }

                displayPage.Title = navMenuItem.Title;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERRO", "Erro " + ex.Message, "OK");
            }
            finally
            {
            }
        }
    }
}