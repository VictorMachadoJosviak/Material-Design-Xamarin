using FFImageLoading.Forms;
using MaterialDesignXam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Controls.CustomCells
{
    public class UserListCell : ViewCell
    {
        public UserListCell()
        {
            var userPhoto = new CachedImage
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Aspect = Aspect.AspectFit
            };
            userPhoto.SetBinding(CachedImage.SourceProperty, Binding.Create<User>(o => o.ImageUri));

            var Name = new Label
            {
                Text = "UserName",
                TextColor = App.StyleKit.PrimaryTextColor,
                FontAttributes = FontAttributes.Bold
            };
            Name.SetBinding(Label.TextProperty, Binding.Create<User>(o => o.Name));

            var Phone = new Label
            {
                Text = "telephone",
                TextColor = App.StyleKit.SecondaryTextColor
            };
            Phone.SetBinding(Label.TextProperty, Binding.Create<User>(o => o.Phone));

            var contentLines = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Name,
                    Phone
                }
            };

            View = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = 8,
                Spacing = 10,
                Children =
                {
                    userPhoto,contentLines
                }
            };

        }
    }
}
