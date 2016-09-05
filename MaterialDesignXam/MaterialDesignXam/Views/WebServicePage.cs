using MaterialDesignXam.Controls.CustomCells;
using MaterialDesignXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class WebServicePage : ContentPage
    {
        private WebServiceViewModel vm => (WebServiceViewModel)BindingContext;

        public WebServicePage()
        {
            Title = "WebService";
            BindingContext = new WebServiceViewModel();
            CreateLayout();
        }

        private void CreateLayout()
        {

            var listBooks = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(BookListCell)),
                RowHeight = 90
            };
            listBooks.SetBinding(ListView.ItemsSourceProperty, Binding.Create<WebServiceViewModel>(o => o.ListBooks));

            var loading = new ActivityIndicator()
            {
                VerticalOptions = LayoutOptions.Center
            };
            
            loading.SetBinding(ActivityIndicator.IsRunningProperty, Binding.Create<WebServiceViewModel>(o => o.IsRunning));
            loading.SetBinding(ActivityIndicator.IsEnabledProperty, Binding.Create<WebServiceViewModel>(o => o.IsRunning));
            loading.SetBinding(ActivityIndicator.IsVisibleProperty, Binding.Create<WebServiceViewModel>(o => o.IsRunning));
            AbsoluteLayout.SetLayoutFlags(loading, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(loading, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            
            Content = new StackLayout
            {
                Children =
                {
                   loading,
                   listBooks
                }
            };
             

        }

    }
}
