using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MaterialDesignXam.Services;
using Android.Media;
using MaterialDesignXam.Droid.Extras;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationService))]
namespace MaterialDesignXam.Droid.Extras
{
    public class NotificationService : INotificationService
    {
        public void Notify(string title, string message)
        {
           
        
            Intent startupIntent = new Intent(Android.App.Application.Context, typeof(MainActivity));

            startupIntent.PutExtra("title", title.ToString());
            startupIntent.PutExtra("message", message.ToString());


            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(Android.App.Application.Context);

            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));

            stackBuilder.AddNextIntent(startupIntent);

            const int pendingIntentId = 0;
            PendingIntent pendingIntent =
                stackBuilder.GetPendingIntent(pendingIntentId, PendingIntentFlags.OneShot);


            Notification.Builder builder = new Notification.Builder(Android.App.Application.Context)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetContentIntent(pendingIntent)
            .SetSmallIcon(Resource.Drawable.icon);
            // Build the notification:
            Notification notification = builder.Build();
            notification.Vibrate = new long[] { 150, 300, 150, 600 };
            notification.Flags = NotificationFlags.AutoCancel;

            try
            {
                Android.Net.Uri song = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
                var play = RingtoneManager.GetRingtone(Android.App.Application.Context, song);
                play.Play();
            }
            catch (Exception ex)
            {

            }

   


            // Get the notification manager:
            NotificationManager notificationManager =
            Android.App.Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;



            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }
    }
}