using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.ViewModel
{
    public class ModalViewModel : AppViewModelBase
    {

        public RelayCommand GobackCommand => new RelayCommand(async () => await Goback());
        private async Task Goback()
        {
            await NavigationService.ModalGoBack();

        }

    }
}
