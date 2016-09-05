using MaterialDesignXam.ViewModel;
using Naylah.Xamarin.Controls.Entrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            Title = "Calculator";
            BindingContext = new CalculatorViewModel();
            CreateLayout();
        }

        private void CreateLayout()
        {
            var num1 = new EntryBase
            {
                Placeholder = "First Number",
                Keyboard = Keyboard.Numeric
            };
            num1.SetBinding(Entry.TextProperty, Binding.Create<CalculatorViewModel>(o => o.Num1));


            var num2 = new EntryBase
            {
                Placeholder = "Second Number",
                Keyboard = Keyboard.Numeric
            };
            num2.SetBinding(Entry.TextProperty, Binding.Create<CalculatorViewModel>(o => o.Num2));


            var result = new EntryBase
            {
                Placeholder = "Result",
                Keyboard = Keyboard.Numeric,
                IsEnabled = false,
                PlaceholderColor = App.StyleKit.SecondaryTextColor                
            };
            result.SetBinding(Entry.TextProperty, Binding.Create<CalculatorViewModel>(o => o.Result));


            var btnResult = new Button
            {
                Text = "Calcualate!",
                BackgroundColor = App.StyleKit.PrimaryColor,
                TextColor = App.StyleKit.TextColorPrimaryLight
            };
            btnResult.SetBinding(Button.CommandProperty, Binding.Create<CalculatorViewModel>(x => x.CalculateCommand));


            var btnClear = new Button
            {
                Text = "Clear",
                BackgroundColor = App.StyleKit.AccentColor,
                TextColor = App.StyleKit.TextColorPrimaryLight
            };
            btnClear.SetBinding(Button.CommandProperty, Binding.Create<CalculatorViewModel>(x => x.ClearCommand));


            Content = new StackLayout
            {
                Padding = 8,
                Spacing = 10,
                Children =
                {
                    num1,
                    num2,
                    result,
                    btnResult,
                    btnClear
                }
            };
        }
    }
}
