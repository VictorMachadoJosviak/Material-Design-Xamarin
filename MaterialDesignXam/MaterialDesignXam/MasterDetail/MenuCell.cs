using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.MasterDetail
{
    public class MenuCell : ViewCell
    {
        public MenuCell()
        {
            var icon = new CachedImage
            {
                HeightRequest = 40,
                WidthRequest = 40,
                Aspect = Aspect.AspectFill
            };
            icon.SetBinding(CachedImage.SourceProperty, Binding.Create<NavMenuItem>(o => o.Icon));

            var Name = new Label
            {
                Text = "Name",
                TextColor = Color.Red,
                FontAttributes = FontAttributes.Bold
            };
            Name.SetBinding(Label.TextProperty, Binding.Create<NavMenuItem>(o => o.Title));

            var contentLines = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Children =
                 {
                    Name,
                 }
            };

            View = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    icon,contentLines
                }
            };

        }
    }
}
