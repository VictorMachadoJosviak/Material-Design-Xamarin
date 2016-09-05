using GalaSoft.MvvmLight.Command;
using MaterialDesignXam.Model;
using MaterialDesignXam.Services;
using MaterialDesignXam.Views;
using Naylah.Xamarin.Services.NavigationService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.ViewModel
{
    public class UserListViewModel : AppViewModelBase
    {
        private IMessageService MessageService { get; set; }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await InitializeList();
            MessageService = DependencyService.Get<IMessageService>();
        }



        private async Task InitializeList()
        {
            ListUsers = new ObservableCollection<User>();

            DefaultList = ListUsers;

            for (int i = 0; i < 5; i++)
            {
                ListUsers.Add(new User
                {
                    Name = "Juriscleide",
                    Phone = "12345678",
                    ImageUri = "http://www.animatedimages.org/data/media/457/animated-simpsons-avatar-image-0027.gif",
                    Email = "rocambole@tester.com",
                    Description = "Single-line fields automatically scroll their content to the left as the text input cursor reaches the right edge of the input field.",
                    Address = "New York"
                });

                ListUsers.Add(new User
                {
                    Name = "Adatolilde",
                    Phone = "85269446",
                    ImageUri = "http://www.animatedimages.org/data/media/457/animated-simpsons-avatar-image-0026.gif",
                    Email = "adat@hamburger.com",
                    Description = "How to add, style android material edittext button tutorial, sample, color, hint, error",
                    Address = "London"
                });

                ListUsers.Add(new User
                {
                    Name = "Churinfulinfu",
                    Phone = "9532118",
                    ImageUri = "http://www.rimfirecentral.com/forums/images/avatars/simpsons_homer.gif",
                    Description = "Mussum Ipsum, cacilds vidis litro abertis. Si num tem leite então bota uma pinga aí cumpadi! Suco de cevadiss, é um leite divinis, qui tem lupuliz, matis, aguis e fermentis. Suco de cevadiss deixa as pessoas mais interessantiss. Quem num gosta di mé, boa gente num é.",
                    Address = "Tokyo",
                    Email = "bingo@bacon.com"
                });
            }
        }

        private ObservableCollection<User> _listUsers;
        public ObservableCollection<User> ListUsers
        {
            get { return _listUsers; }
            set { Set(ref _listUsers, value); }
        }

        private ObservableCollection<User> _defaultList;
        public ObservableCollection<User> DefaultList
        {
            get { return _defaultList; }
            set { Set(ref _defaultList, value); }
        }


        private string _searchInput;
        public string SearchInput
        {
            get { return _searchInput; }
            set { Set(ref _searchInput, value); }
        }

        public async Task Search()
        {
            try
            {

                if (!string.IsNullOrEmpty(SearchInput))
                {
                    var search = DefaultList.Where(x => x.Name.ToLower().Contains(SearchInput.ToLower()));
                    ListUsers = new ObservableCollection<User>(search);
                }
                else
                {
                    ListUsers = DefaultList;
                }


            }
            catch (Exception err)
            {
            }

        }

        public RelayCommand GoToTabbedPageCommand => new RelayCommand(async () => await GoToTabbedPage());
        private async Task GoToTabbedPage()
        {
            await App.CurrentApp.NavigationService.NavigateAsync(new PagesTab(), null, true);
        }

        public RelayCommand<User> NavigateToUserDetailCommand => new RelayCommand<User>(async (u) => await NavigateToUserDetail(u));
        public async Task NavigateToUserDetail(User u)
        {
            await App.CurrentApp.NavigationService.NavigateAsync(new UserDetailPage(), u, true);

        }

    }
}
