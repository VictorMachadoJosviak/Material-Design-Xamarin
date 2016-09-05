using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.Services
{
    public class DialogService : IMessageService
    {
        public async Task<bool> ConfirmDialog(string title, string message, string accept, string cancel)
        {
            return await App.CurrentApp.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public async Task ShowMessage(string title, string message, string button)
        {
            await App.CurrentApp.MainPage.DisplayAlert(title, message, button);
        }
    }
}
