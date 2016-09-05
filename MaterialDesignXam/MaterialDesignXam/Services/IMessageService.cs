using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.Services
{
    public interface IMessageService
    {
        Task ShowMessage(string title, string message, string button);
        Task<bool> ConfirmDialog(string title, string message, string accept, string cancel);
    }
}
