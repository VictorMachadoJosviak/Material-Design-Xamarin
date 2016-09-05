using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MaterialDesignXam.Model;

namespace MaterialDesignXam.Droid
{
    [Activity(Label = "MaterialDesignXam", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public App CurrentApp { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //   LoadApplication(new App());


            string parameterValue = this.Intent.GetStringExtra("title");
            string parameterValuemessage = this.Intent.GetStringExtra("message");

            App.ItemsNotification = new NotificationModel
            {
                Title = parameterValue,
                Message = parameterValuemessage
            };

            CurrentApp = new App();

            LoadApplication(CurrentApp);


        }

        protected override async void OnStart()
        {
            base.OnStart();

            if (!CurrentApp.Initialized)
            {
                await CurrentApp.InitializeApp();
            }

        }
    }
}

