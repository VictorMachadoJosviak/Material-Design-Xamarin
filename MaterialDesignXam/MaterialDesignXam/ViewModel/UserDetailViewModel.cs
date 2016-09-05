using GalaSoft.MvvmLight.Command;
using MaterialDesignXam.Model;
using MaterialDesignXam.Services;
using Naylah.Xamarin.Services.NavigationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.ViewModel
{
    public class UserDetailViewModel : AppViewModelBase
    {
      
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            await LoadData((User)parameter);
        }

        private async Task LoadData(User user)
        {
            SelectedUser = user;
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set { Set(ref _selectedUser, value); }
        }

        public RelayCommand SendEmailCommand => new RelayCommand(async () => await SendEmail());
        private async Task SendEmail()
        {
            try
            {
                Device.OpenUri(new Uri(string.Format("mailto:{0}", SelectedUser.Email)));
            }
            catch (Exception)
            {
                await DialogService.ShowMessage("Sem Dados", "Usuário não possui email", "ok");
            }
        }

        public RelayCommand FindLocationCommand => new RelayCommand(async () => await FindLocation());
        private async Task FindLocation()
        {
            try
            {
                switch (Device.OS)
                {
                    case TargetPlatform.iOS:
                        Device.OpenUri(
                          new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(SelectedUser.Address))));
                        break;
                    case TargetPlatform.Android:
                        Device.OpenUri(
                          new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(SelectedUser.Address))));
                        break;
                }
            }
            catch (Exception)
            {
                await DialogService.ShowMessage("Sem Dados", "Usuário não possui endereço", "ok");
            }
        }

        public RelayCommand CallCommand => new RelayCommand(async () => await Call());
        private async Task Call()
        {
            try
            {
                Device.OpenUri(new Uri(string.Format("tel:{0}", SelectedUser.Phone)));
            }
            catch (Exception ex)
            {
                await DialogService.ShowMessage("Sem Dados", "Usuário não possui telefone", "ok");
            }
        }


    }
}
