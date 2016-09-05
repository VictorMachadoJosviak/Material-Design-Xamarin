using MaterialDesignXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            Title = "Home";
            BindingContext = new HomeViewModel();
            CreateLayout();
        }

        private void CreateLayout()
        {

            ToolbarItem alert = new ToolbarItem
            {
                Text = "Alert Dialog",
          
                Order = ToolbarItemOrder.Secondary

            };
            alert.SetBinding(ToolbarItem.CommandProperty, Binding.Create<HomeViewModel>(o => o.SimpleAlertDialogCommand));

            ToolbarItem confirmAlert = new ToolbarItem
            {
                Text = "Confirm Dialog",
              
                Order = ToolbarItemOrder.Secondary

            };
            confirmAlert.SetBinding(ToolbarItem.CommandProperty, Binding.Create<HomeViewModel>(o => o.ConfirmAlertDialogCommand));
            ToolbarItems.Add(alert);
            ToolbarItems.Add(confirmAlert);

            var bt = new Button
            {
                Text = "Navigation Async"
            };
            bt.SetBinding(Button.CommandProperty, Binding.Create<HomeViewModel>(o => o.NavigateAsyncCommand));

            var btModal = new Button
            {
                Text = "Navigation Modal Async"
            };
            btModal.SetBinding(Button.CommandProperty, Binding.Create<HomeViewModel>(o => o.NavigateModalAsyncCommand));

            var btNotification = new Button
            {
                Text = "Notification"
            };
            btNotification.SetBinding(Button.CommandProperty, Binding.Create<HomeViewModel>(o => o.NotificatioCommand));

            Content = new StackLayout
            {
                Children =
                {
                    bt,
                    btModal,
                    btNotification
                }
            };
        }
    }
}
