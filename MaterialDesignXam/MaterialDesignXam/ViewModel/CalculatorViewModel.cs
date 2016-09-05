using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.ViewModel
{
    public class CalculatorViewModel : AppViewModelBase
    {

        private string _num1;
        public string Num1
        {
            get { return _num1; }
            set {Set(ref _num1 , value); }
        }

        private string _num2;
        public string Num2
        {
            get { return _num2; }
            set { Set(ref _num2, value); }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { Set(ref _result, value); }
        }

        public RelayCommand CalculateCommand => new RelayCommand(async () => await Calculate());
        private async Task Calculate()
        {
            try
            {

                double a = Convert.ToDouble(Num1);
                double b = Convert.ToDouble(Num2);
               

                var res = a + b;
                Result = res.ToString();
            }
            catch (Exception e)
            {
                
            }
        }

        public RelayCommand ClearCommand => new RelayCommand(async () => await Clear());
        private async Task Clear()
        {
            Num1 = "";
            Num2 = "";
            Result = "";
        }
    }
}
