using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using MaterialDesignXam.MasterDetail;
using MaterialDesignXam.Model;
using MaterialDesignXam.Services;
using MaterialDesignXam.Styles;
using MaterialDesignXam.Views;
using Naylah.Xamarin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam
{
    public class App : BootStrapper
    {
        public static App CurrentApp { get; set; }
        public static new StyleApp StyleKit { get; set; } //take your custom colors
        public static NotificationModel ItemsNotification { get; set; }

        public App()
        {
            DependencyService.Register<IMessageService, DialogService>();
            CurrentApp = this;
            StyleKit = new StyleApp();

            
            SplashPageNavigate();
            
            
        }

        private void SplashPageNavigate()
        {
            NavigationServiceFactory(new NavigationPage(new SplashPage()));
        }

   

        private void entranceInApp()
        {
            var shellPage = new ShellPage();
            NavigationServiceFactory(shellPage);

            NavigationService.Navigating += shellPage.NavigationService_Navigating;
            NavigationService.Navigated += shellPage.NavigationService_Navigated;
        }


        public override async Task InitializeApp()
        {
            await base.InitializeApp();
            await LoadApp();
        }

        public override async Task LoadApp()
        {


            await Task.Delay(3000); //Some load

            if (ItemsNotification != null)
            {
                entranceInApp();
            }
            else
            {
                entranceInApp();
            }

        }                
    }
}
