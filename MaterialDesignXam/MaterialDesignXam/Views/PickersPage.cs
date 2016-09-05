using MaterialDesignXam.ViewModel;
using Naylah.Xamarin.Controls.Pickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Views
{
    public class PickersPage : ContentPage
    {
        public PickersPage()
        {
            Title = "Pickers";
            BindingContext = new PickersViewModel();
            CreateLayout();
        }

        private void CreateLayout()
        {
            var date = new DatePicker()
            {
                Date = DateTime.Now
            };

            var time = new TimePicker
            {
                Time = DateTime.Now.TimeOfDay,
                
            };

            var swich = new Switch();

            var picker = new BindablePicker()
            {
                Title = "Picker",
            };
            picker.SetBinding(BindablePicker.ItemsSourceProperty, Binding.Create<PickersViewModel>(o => o.PickerIst));
          
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                Padding = 8,
                Spacing = 10,
                Children =
                {
                    date,
                    time,
                    swich,
                    picker
                }
            };
        }

      
    }
}
