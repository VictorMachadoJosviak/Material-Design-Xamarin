using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Controls
{
    public enum FloatingActionButtonSize
    {
        Normal,
        Mini
    }
    
    public class FloatingActionButtonView : View
    {
        public static readonly BindableProperty IconProperty = BindableProperty.Create<FloatingActionButtonView, string>(p => p.Icon, string.Empty);
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty FabColor = BindableProperty.Create<FloatingActionButtonView, Color>(p => p.FabBackgroundColor, Color.White);
        public Color FabBackgroundColor
        {
            get { return (Color)GetValue(FabColor); }
            set { SetValue(FabColor, value); }
        }

        public static readonly BindableProperty SizeProperty = BindableProperty.Create<FloatingActionButtonView, FloatingActionButtonSize>(p => p.Size, FloatingActionButtonSize.Normal);
        public FloatingActionButtonSize Size
        {
            get { return (FloatingActionButtonSize)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        public delegate void AttachToListViewDelegate(ListView listView);

        public delegate void ShowHideDelegate();

        public ShowHideDelegate Show { get; set; }
        public ShowHideDelegate Hide { get; set; }

        public Action<object, EventArgs> Clicked { get; set; }
    }
}
