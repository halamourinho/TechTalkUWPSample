using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestSample.Models.Enum;
using TestSample.Views;

namespace TestSample.Models.UI
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public string Symbol { get; set; }
        public Type PageType { get; set; }

        internal NavigationItem(string title, string symbol, Type page)
        {
            this.Title = title;
            this.Symbol = symbol;
            this.PageType = page;
        }

        public static List<NavigationItem> GetNavigationItems()
        {
            return new List<NavigationItem>
            {
                new NavigationItem(App.localeHelper.GetString(LocaleStringType.Tip_PageInstance),"\uE74C",typeof(InstancePage)),
                new NavigationItem(App.localeHelper.GetString(LocaleStringType.Tip_Locale),"\uE164",typeof(LocalePage))
            };
        }
    }
}
