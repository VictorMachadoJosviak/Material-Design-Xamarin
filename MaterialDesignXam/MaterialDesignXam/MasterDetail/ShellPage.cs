using Naylah.Xamarin.Controls.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialDesignXam.MasterDetail
{
    public class ShellPage : MasterDetailNavigationPage
    {
        MenuPage MasterAsMenuPage { get { return Master as MenuPage; } }
        public ShellViewModel Vm => this.BindingContext as ShellViewModel;
        public ShellPage()
        {
            BindingContext = new ShellViewModel(); //Replace.....


            ((NavigationPage)Detail).BarBackgroundColor = App.StyleKit.PrimaryColor;
            ((NavigationPage)Detail).BarTextColor = Color.White;

            Master = new MenuPage();

            IsGestureEnabled = true;

            MasterAsMenuPage.MenusItemTapped += async (s, i) =>
            {
                await Vm.NavigateToSelectedMenuItem(i.Item as NavMenuItem);
            };
        }

        public void NavigationService_Navigating(object sender, EventArgs e)
        {
            try
            {
                IsPresented = false;
            }
            catch (Exception)
            {
            }

        }

        public void NavigationService_Navigated(object sender, EventArgs e)
        {
            try
            {
                MasterAsMenuPage.SelectByPage(Vm.NavigationService.CurrentPage);
            }
            catch (Exception)
            {
            }

        }
    }
}
