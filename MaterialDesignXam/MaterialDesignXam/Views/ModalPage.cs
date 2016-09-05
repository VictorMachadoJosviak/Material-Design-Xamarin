using MaterialDesignXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class ModalPage : ContentPage
    {
        public ModalPage()
        {
            BindingContext = new ModalViewModel();
            CreateLayout();

        }

        private void CreateLayout()
        {
            var label = new Label
            {
                Text = "Hello Modal Page!",
                FontSize = 20,
                TextColor = App.StyleKit.PrimaryTextColor,
                FontAttributes = FontAttributes.Bold
            };

            var goback = new Button
            {
                Text = "Go back",
                BackgroundColor = App.StyleKit.PrimaryDarkColor,
                TextColor = App.StyleKit.TextColorPrimaryLight,
            };
            goback.SetBinding(Button.CommandProperty, Binding.Create<ModalViewModel>(o => o.GobackCommand));


            Content = new StackLayout
            {
                Padding  = 8,
                Spacing = 10,
                Children =
                {
                    label,
                    goback
                }
            };
        }
    }
}
