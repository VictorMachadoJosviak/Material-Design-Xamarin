using Naylah.Xamarin.Controls.Entrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class EntryPage : ContentPage
    {
        public EntryPage()
        {
            Title = "Entrys";
            CreateLayout();
        }

        private void CreateLayout()
        {
            var entrybase = new EntryBase
            {
                Placeholder = "EntryBase",
                Theme = Naylah.Xamarin.Controls.Style.BasicTheme.Dark
            };

            var textinputlayout = new FloatLabeledEntry
            {
                Placeholder = "FloatLabeledEntry",
                Theme = Naylah.Xamarin.Controls.Style.BasicTheme.Dark
            };

            Content = new StackLayout
            {
                Padding = 8,
                Spacing =10,
                Children =
                {
                    entrybase,
                    textinputlayout
                }
            };
        }
    }
}
