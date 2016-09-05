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
using Xamarin.Forms;
using MaterialDesignXam.Controls;
using MaterialDesignXam.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.Text;

[assembly: ExportRenderer(typeof(StyledSearchBar), typeof(StyledSearchBarRenderer))]
namespace MaterialDesignXam.Droid.Renderers
{
    public class StyledSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> args)
        {
            base.OnElementChanged(args);

            // Get native control (background set in shared code, but can use SetBackgroundColor here)
            SearchView searchView = (base.Control as SearchView);
            searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);
            searchView.Iconified = true;
            searchView.SetIconifiedByDefault(false);

            int searchIconId = Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
            var icon = searchView.FindViewById(searchIconId);
            (icon as ImageView).SetImageResource(Resource.Drawable.ic_search_white_24dp);

        }
    }
}