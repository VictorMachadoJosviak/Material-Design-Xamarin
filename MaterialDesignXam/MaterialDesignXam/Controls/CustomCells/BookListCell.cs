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
    public class BookListCell : ViewCell
    {
        public BookListCell()
        {

            var bookPhoto = new CachedImage
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Aspect = Aspect.AspectFit,
                Source = "https://cdn2.iconfinder.com/data/icons/windows-8-metro-style/128/book_stack.png"
            };

            var Title = new Label
            {
                Text = "bookname",
                TextColor = App.StyleKit.PrimaryTextColor,
                FontAttributes = FontAttributes.Bold
            };
            Title.SetBinding(Label.TextProperty, Binding.Create<Book>(o => o.Title));


            var author = new Label
            {
                Text = "author",
                TextColor = App.StyleKit.SecondaryTextColor
            };
            author.SetBinding(Label.TextProperty, Binding.Create<Book>(o => o.AuthorLib.Name));

            var contentLines = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Title,
                    author
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
                    bookPhoto,contentLines
                }
            };
        }
    }
}
