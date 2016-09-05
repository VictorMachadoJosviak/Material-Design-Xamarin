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
using Naylah.Xamarin.Controls.Entrys;
using Xamarin.Forms;
using Naylah.Xamarin.Android.Renderers;

[assembly: ExportRenderer(typeof(EntryBase), typeof(EntryRenderer))]
[assembly: ExportRenderer(typeof(FloatLabeledEntry), typeof(FloatLabeledEntryRenderer))]
namespace MaterialDesignXam.Droid.Renderers
{
    class ExternalDeclarations
    {
    }
}