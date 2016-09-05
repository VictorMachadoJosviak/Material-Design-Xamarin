using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.ViewModel
{
    public class PickersViewModel : AppViewModelBase
    {
        public PickersViewModel()
        {
            PopulateList();
        }

        private void PopulateList()
        {
            PickerIst = new List<string>();
            PickerIst.Add("Bacon");
            PickerIst.Add("Hamburger");
            PickerIst.Add("Cheddar");
        }

        private List<string> _pickerList;
        public List<string> PickerIst
        {
            get { return _pickerList; }
            set { _pickerList = value; }
        }
    }
}
