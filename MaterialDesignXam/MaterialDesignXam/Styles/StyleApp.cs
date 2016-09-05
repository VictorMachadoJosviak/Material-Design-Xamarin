using Naylah.Xamarin.Controls.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.Styles
{
    public class StyleApp : StyleKit
    {
        public Color TextColorPrimaryLight { get; set; }

        public StyleApp()
        {
            PrimaryColor = Color.Red;
            PrimaryDarkColor = Color.FromHex("#D32F2F");
            PrimaryLightColor = Color.FromHex("#FFCDD2");
            AccentColor = Color.FromHex("#FFC107");
            PrimaryTextColor = Color.FromHex("#212121");
            SecondaryTextColor = Color.FromHex("#727272");
            DividerColor = Color.FromHex("#B6B6B6");
            WindowColor = Color.Red;
            TextColorPrimaryLight = Color.White;
        }
    }
}
