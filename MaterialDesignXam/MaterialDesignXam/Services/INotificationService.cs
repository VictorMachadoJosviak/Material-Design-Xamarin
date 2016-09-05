using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.Services
{
    public interface INotificationService
    {
        void Notify(string title, string message);
    }
}
