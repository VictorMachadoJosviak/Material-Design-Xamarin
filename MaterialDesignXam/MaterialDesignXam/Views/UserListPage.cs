using MaterialDesignXam.Controls;
using MaterialDesignXam.Controls.CustomCells;
using MaterialDesignXam.MasterDetail;
using MaterialDesignXam.Model;
using MaterialDesignXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class UserListPage : ContentPage
    {

        public UserListViewModel vm => (UserListViewModel)BindingContext;

        public UserListPage()
        {
            CreateLayout();
            BindingContext = new UserListViewModel();
        }

        private void CreateLayout()
        {
            Title = "Second Page";
          

            var userList = new ListView(ListViewCachingStrategy.RecycleElement)
            {
                ItemTemplate = new DataTemplate(typeof(UserListCell)),
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowHeight = 80,
                SelectedItem = false

            };
            userList.SetBinding(ListView.ItemsSourceProperty, Binding.Create<UserListViewModel>(o => o.ListUsers));
            userList.ItemTapped += UserList_ItemTapped;


            var fab = new FloatingActionButtonView
            {
                Icon = "ic_add_white_24dp",

            };
            AbsoluteLayout.SetLayoutFlags(fab, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(fab, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            fab.Clicked += (o, e) =>
            {
                vm.GoToTabbedPageCommand.Execute(null);
            };

            var search = new StyledSearchBar
            {
                BackgroundColor = App.StyleKit.PrimaryColor,
                TextColor = App.StyleKit.TextColorPrimaryLight,
                CancelButtonColor = App.StyleKit.TextColorPrimaryLight,
                Placeholder = "Search...",
                PlaceholderColor = App.StyleKit.TextColorPrimaryLight,
            };
            search.SetBinding(SearchBar.TextProperty, Binding.Create<UserListViewModel>(o => o.SearchInput, BindingMode.TwoWay));
            search.SearchButtonPressed += Search_SearchButtonPressed;
            search.TextChanged += Search_TextChanged;

            var pageLayout = new StackLayout
            {
                Children =
                {
                    search,
                    userList
                }
            };

            var absolute = new AbsoluteLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            AbsoluteLayout.SetLayoutFlags(pageLayout, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(pageLayout, new Rectangle(0f, 0f, 1f, 1f));
            absolute.Children.Add(pageLayout);
            absolute.Children.Add(fab);

            Content = absolute;
        }

        private async void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = (SearchBar)sender;

            if (string.IsNullOrEmpty(input.Text))
            {
                await vm.Search();
            }


        }

        private async void Search_SearchButtonPressed(object sender, EventArgs e)
        {
            await vm.Search();
        }

        private async void UserList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return;

            NavMenuItem item = e.Item as NavMenuItem;
            vm.NavigateToUserDetailCommand.Execute((User)e.Item);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
