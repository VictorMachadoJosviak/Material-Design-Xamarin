using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using MaterialDesignXam.Controls;
using MaterialDesignXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class UserDetailPage : ContentPage
    {
        private UserDetailViewModel vm => (UserDetailViewModel)BindingContext;

        public UserDetailPage()
        {
            Title = "User Detail";           
            BindingContext = new UserDetailViewModel();
            CreateLayout();
        }

        private void CreateLayout()
        {
            var imgUser = new CachedImage
            {
                HeightRequest = 85,
                WidthRequest = 85,
                Aspect = Aspect.AspectFit,
                LoadingPlaceholder = "http://www.appleyardpress.com/assets/img/ui/image-placeholder.png",
                Source = "http://www.appleyardpress.com/assets/img/ui/image-placeholder.png",
                Transformations = new List<FFImageLoading.Work.ITransformation> {
                    new CircleTransformation(0, App.StyleKit.PrimaryColor.ToString())
                }
            };
            imgUser.SetBinding(CachedImage.SourceProperty, Binding.Create<UserDetailViewModel>(o => o.SelectedUser.ImageUri));

            var username = new Label
            {
                Text = "User Name",
                TextColor = App.StyleKit.TextColorPrimaryLight,
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,

            };
            username.SetBinding(Label.TextProperty, Binding.Create<UserDetailViewModel>(o => o.SelectedUser.Name));

            var email = new Label
            {
                Text = "email",
                TextColor = App.StyleKit.TextColorPrimaryLight,
                FontAttributes = FontAttributes.Bold,
            };
            email.SetBinding(Label.TextProperty, Binding.Create<UserDetailViewModel>(o => o.SelectedUser.Email));


            var data = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    username,
                    email
                }
            };

            var headerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = App.StyleKit.PrimaryColor,
                Padding = 8,
                Spacing = 10,
                Children =
                {
                    imgUser,data
                }

            };

            var header = new ContentView
            {
                Content = headerLayout,
               
            };

            var label = new Label
            {
                Text = "Description",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                TextColor = App.StyleKit.PrimaryTextColor
            };

            var description = new Label
            {
                TextColor = App.StyleKit.SecondaryTextColor
            };
            description.SetBinding(Label.TextProperty, Binding.Create<UserDetailViewModel>(o => o.SelectedUser.Description));

            var layoutDescUser = new StackLayout
            {
                Padding = 8,
                Spacing = 10,
                Children =
                {
                    label,
                    description
                }
            };


            ToolbarItem sendEmail = new ToolbarItem
            {
                Text = "Send email",
                Icon = "ic_email_white_24dp"
            };
            sendEmail.SetBinding(ToolbarItem.CommandProperty, Binding.Create<UserDetailViewModel>(o => o.SendEmailCommand));

            ToolbarItem address = new ToolbarItem
            {
                Text = "Address",
                Icon = "ic_location_on_white_24dp"


            };
            address.SetBinding(ToolbarItem.CommandProperty, Binding.Create<UserDetailViewModel>(o => o.FindLocationCommand));
            ToolbarItems.Add(address);
            ToolbarItems.Add(sendEmail);

            var fab = new FloatingActionButtonView
            {
                Icon = "ic_phone_white_24dp",

            };
            fab.Clicked += (s, e) =>
            {
                vm.CallCommand.Execute(null);
            };
            AbsoluteLayout.SetLayoutFlags(fab, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(fab, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            var stackFab = new StackLayout
            {
                Padding = new Thickness(250, 55, 0, 0),
                Children =
                {
                    fab
                }
            };

            var content = new StackLayout
            {
                Children =
                {
                    header,
                    layoutDescUser
                }
            };
            AbsoluteLayout.SetLayoutFlags(content, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(content, new Rectangle(0f, 0f, 1f, 1f));

            Content = new AbsoluteLayout
            {
                Children =
                {
                    content,
                    stackFab,
                }
            };
        }
    }
}
