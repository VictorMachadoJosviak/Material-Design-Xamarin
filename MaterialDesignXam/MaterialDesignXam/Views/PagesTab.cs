using MaterialDesignXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class PagesTab : TabbedPage
    {
        public PagesTab()
        {
            Title = "Tabbed Page";

            BindingContext = new CalculatorViewModel();

            Children.Add(new EntryPage());
            Children.Add(new CalculatorPage());
            Children.Add(new PickersPage());
        }
    }
}
