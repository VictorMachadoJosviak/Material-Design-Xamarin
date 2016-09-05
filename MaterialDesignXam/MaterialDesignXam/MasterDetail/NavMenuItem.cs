using System;
using Xamarin.Forms;

namespace MaterialDesignXam.MasterDetail
{
    public class NavMenuItem : MenuItem
    {

        public string Title { get; set; }
                
        public Type TargetType { get; set; }

    }
}