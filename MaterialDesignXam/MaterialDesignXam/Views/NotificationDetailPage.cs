using MaterialDesignXam.ViewModel;
using Naylah.Xamarin.Controls.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class NotificationDetailPage : ContentPageBase
    {
        NotificationDetailViewModel vm => (NotificationDetailViewModel)BindingContext;

        public NotificationDetailPage()
        {
            Title = "Notifications";
            BindingContext = new NotificationDetailViewModel();            
            CreateLayout();

        }

        private void CreateLayout()
        {
        
            var title = new Label
            {
                Text = "Title",
                TextColor = App.StyleKit.PrimaryTextColor,
                FontAttributes = FontAttributes.Bold,
                FontSize = 20
            };
            title.SetBinding(Label.TextProperty, Binding.Create<NotificationDetailViewModel>(o => o.NotificationModels.Title));


            var message = new Label
            {
                Text = "Message",
                TextColor = App.StyleKit.SecondaryTextColor
            };
            message.SetBinding(Label.TextProperty, Binding.Create<NotificationDetailViewModel>(o => o.NotificationModels.Message));
            
            Content = new StackLayout
            {
                Padding = 8,
                Spacing = 10,
                Children =
                {
                    title,
                    message
                }
            };
        }
   
    }
}
