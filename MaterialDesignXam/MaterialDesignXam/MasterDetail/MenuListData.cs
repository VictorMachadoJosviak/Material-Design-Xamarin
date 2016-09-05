using MaterialDesignXam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.MasterDetail
{
    public class MenuListData
    {

        public static List<NavMenuItem> TopItems { get; set; }
        public static List<NavMenuItem> BottomItems { get; set; }

        public static NavMenuItem Dashboard { get; }
        public static NavMenuItem WebService { get; }

        //public static NavMenuItem Settings { get; }

        static MenuListData()
        {

            Dashboard = new NavMenuItem()
                {
                    Title = "Dashboard",
                    Icon = "ic_action_action_home",
                    TargetType = typeof(HomePage),
                };

            WebService = new NavMenuItem()
            {
                Title = "WebService",
                Icon = "ic_action_action_web",
                TargetType = typeof(WebServicePage),
            };

            TopItems = new List<NavMenuItem>()
            {
                Dashboard,WebService
            };

            BottomItems = new List<NavMenuItem>()
            {
                //Settings
            };

        }

    }
}
